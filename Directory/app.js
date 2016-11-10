var app = angular.module('app', ['ngMaterial', 'ngMessages', 'ngRoute', 'ngFileUpload']);

/* Process REST requests */
app.factory('personFactory', ['$http', function ($http) {

    var urlBase = '/api/person';
    var person = {
        Id: 0,
        FirstName: "",
        LastName: "",
        Dob: new Date()
    };

    person.load = function (page, search) {
        var url = urlBase + '/?page=' + page;
        if (search != null && !angular.isUndefined(search)) {
            url = url + '&search=' + search;
        }
        return $http.get(url);
    };

    person.get = function (id) {
        return $http.get(urlBase + '/' + id);
    };

    person.delete = function (id) {
        return $http.delete(urlBase + '/' + id);
    };

    person.insert = function (person) {
        return $http.post(urlBase, person);
    };

    person.update = function (person) {
        return $http.put(urlBase + '/' + person.Id, person);
    };

    return person;
}]);


/* Configure Routes */
app.config(['$routeProvider', '$locationProvider',
            function ($routeProvider, $locationProvider) {

                $routeProvider

                // route for the home page
                .when('/default.htm', {
                    templateUrl: 'default.htm',
                    controller: 'mainController',
                    reloadOnSearch: false
                })
				.otherwise({
				    templateUrl: 'default.htm',
				    controller: 'mainController',
				    reloadOnSearch: false
				});

                // use the HTML5 History API
                $locationProvider.html5Mode(true);
            }]);


/* Main controller */

app.controller('mainController', ['$scope', '$http', '$timeout', '$mdDialog', '$mdMedia', '$window', '$route', '$routeParams', '$location', 'personFactory', 'Upload',
    function ($scope, $http, $timeout, $mdDialog, $mdMedia, $window, $route, $routeParams, $location, personFactory, Upload) {

        /* Set scope variables */
        $scope.page = 1;
        $scope.people;
        $scope.isLoading = true;

        /* Routing variables */
        this.$route = $route;
        this.$location = $location;
        this.$routeParams = $routeParams;

        /* Hide or show search dialog depending on screen size */
        $scope.$watch(function () {
            return $mdMedia('xs') || $mdMedia('sm');
        }, function (isSearchOpen) {
            $scope.isSearchOpen = (isSearchOpen === false);
        });

        /* Methods */
        function getPeople() {
            $scope.isLoading = true;
            console.log('Getting people');
            personFactory.load($scope.page, $scope.search)
                .then(function (response) {
                    console.log('Getting people - response');
                    if ($scope.page > 1) {
                        $scope.people = $scope.people.concat(response.data);
                    } else {
                        $scope.people = response.data;
                    }
                    $scope.isLoading = false;
                }, function (error) {
                    console.log('Unable to load person data: ' + error.message);
                });
        }

        $scope.getPerson = function (id) {
            personFactory.get(id)
                .then(function (response) {
                    return response.data;
                }, function (error) {
                    console.log('Unable to load single person: ' + error.message);
                });
        }

        $scope.loadMore = function (ev) {
            $scope.page = $scope.page + 1;
            getPeople($scope.page);
        };

        $scope.searchPeople = function (ev) {
            $scope.page = 1;
            getPeople($scope.page);
        }

        $scope.insertPerson = function (person) {
            // set the active flag
            person.ActiveFlag = true;
            person.Age = $scope.calcuateAge(person.Dob);
            person.Photo = "R0lGODlhAQABAIAAAP///wAAACH5BAEAAAAALAAAAAABAAEAAAICRAEAOw==";

            personFactory.insert(person)
                .then(function (response) {
                    // update ID in case there's a desire to delete or edit
                    person.Id = response.data.Id;
                    console.log('Inserted person, refreshing');
                    $scope.people.splice(0, 0, person);
                }, function (error) {
                    console.log('Unable to insert person: ' + error.message);
                });
        };

        $scope.updatePerson = function (person) {
            person.Age = $scope.calcuateAge(person.Dob);

            personFactory.update(person)
                .then(function (response) {
                    console.log('Updated person, refreshing');
                }, function (error) {
                    console.log('Unable to update person: ' + error.message);
                });
        };

        $scope.deletePerson = function (id) {
            personFactory.delete(id)
            .then(function (response) {
                console.log('Deleted person, refreshing');
                for (var i = 0; i < $scope.people.length; i++) {
                    var person = $scope.people[i];
                    if (person.Id === id) {
                        $scope.people.splice(i, 1);
                        break;
                    }
                }
            }, function (error) {
                console.log('Unable to delete person: ' + error.message);
            });
        };

        $scope.uploadFile = function (event, scope, person, file) {
            Upload.upload({
                url: '/api/files/' + person.Id,
                data: { file: file, 'Id': person.Id }
            }).then(function (resp) {
                console.log('Success ' + resp.config.data.file.name + 'uploaded. Response: ' + resp.data);
                posting.Body = resp.data.Body;
            }, function (resp) {
                console.log('Error status: ' + resp.status);
            }, function (evt) {
                var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
                console.log('progress: ' + progressPercentage + '% ' + evt.config.data.file.name);
            });
        };

        $scope.calcuateAge = function (dob) {
            // calculate age for display purposes
            var d = new Date();
            var n = d.getTime();
            var c = Date.parse(dob);
            var a = (d - c) / (1000 * 60 * 60 * 24 * 365);
            var result = Math.round(a * 100) / 100;
            return Math.floor(result);
        };


        /* Get people by default - check url after route data is loaded */
        $scope.$on('$routeChangeSuccess', function ($routeParams) {
            getPeople();
        });


        /* Dialog management */
        $scope.showAdd = function (ev, textAngularManager, scope) {
            var useFullScreen = ($mdMedia('sm') || $mdMedia('xs')) && $scope.customFullscreen;

            // Firefox has an issue where some data has to be passed
            // otherwise no data will be returned
            $scope.person = {
                Id: 0,
                FirstName: "",
                LastName: "",
                Interests: "",
                Age: 0
            };

            $mdDialog.show({
                controller: PersonDialogController,
                templateUrl: '/pages/PersonDialog.tmpl.html',
                parent: angular.element(document.body),
                targetEvent: ev,
                // pass person data
                locals: { person: $scope.person },
                clickOutsideToClose: false,
                fullscreen: useFullScreen
            })
            .then(function (person) {
                $scope.insertPerson(person);

            }, function () {
                console.log('Dialog cancelled.');
            });
            // resize dialog box on the fly
            $scope.$watch(function () {
                return $mdMedia('xs') || $mdMedia('sm');
            }, function (wantsFullScreen) {
                $scope.customFullscreen = (wantsFullScreen === true);
            });
        };


        $scope.showUpdate = function (ev, scope, person) {
            var useFullScreen = ($mdMedia('sm') || $mdMedia('xs')) && $scope.customFullscreen;

            $mdDialog.show({
                controller: PersonDialogController,
                templateUrl: '/pages/PersonDialog.tmpl.html',
                parent: angular.element(document.body),
                targetEvent: ev,
                // pass person data
                locals: { person: person },
                clickOutsideToClose: false,
                fullscreen: useFullScreen
            })
            .then(function (person) {
                $scope.updatePerson(person);
            }, function () {
                console.log('Dialog cancelled.');
            });
            // resize dialog box on the fly
            $scope.$watch(function () {
                return $mdMedia('xs') || $mdMedia('sm');
            }, function (wantsFullScreen) {
                $scope.customFullscreen = (wantsFullScreen === true);
            });
        };

        function PersonDialogController($scope, $mdDialog, person) {
            $scope.person = person;
            // create the dob variable in order to convert an ISO date to a true date
            if (person.Dob) {
                $scope.dob = new Date(person.Dob);
            }
            $scope.hide = function () {
                $mdDialog.hide();
            };
            $scope.cancel = function () {
                $mdDialog.cancel();
            };
            $scope.answer = function (person) {
                $mdDialog.hide(person);
            };
        }

        // Delete person confirmation
        $scope.deletePersonConfirm = function (ev, id, scope) {
            var confirm = $mdDialog.confirm(id)
                  .title('Would you like to delete this person?')
                  .textContent('This will mark the person as being deleted.')
                  .ariaLabel('Delete Person')
                  .targetEvent(ev)
                  .ok('Delete Person')
                  .cancel('Nevermind');
            $mdDialog.show(confirm).then(function () {
                console.log('Delete confirmed for Person.Id ' + id);
                $scope.deletePerson(id);
            }, function () {
                console.log('Delete canceled.');
            });
        };

        // display dialogs in full screen for small displays
        $scope.customFullscreen = $mdMedia('xs') || $mdMedia('sm');

    }]);

// theme
app.config(function ($mdThemingProvider, $mdIconProvider) {

    $mdThemingProvider.theme('default')
        .primaryPalette('indigo')
        .accentPalette('purple');

    $mdThemingProvider.theme('search')
          .primaryPalette('blue')
          .accentPalette('pink')
          .dark();
});

/* This will load more people at the bottom of the page */
app.directive('scrollCheck', function () {
    return {
        restrict: 'A',
        scope: true,
        compile: function () {
            return function (scope, element) {
                var elm = element[0];
                var check = function () {
                    if (elm.offsetHeight + elm.scrollTop >= elm.scrollHeight) {
                        if (!scope.isLoading) {
                            scope.loadMore();
                        }
                    }

                };
                element.bind('scroll', function () {
                    scope.$apply(check);
                });
                check();
            }; // end of link 
        }
    };
});