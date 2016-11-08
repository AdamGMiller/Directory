var app = angular.module('app', ['ngMaterial', 'ngFileUpload']);

/* Process REST requests */
app.factory('peopleFactory', ['$http', function ($http) {

    var urlBase = '/api/people';
    var person = {
        Id: 0,
        FirstName: "",
        LastName: " "
    };

    posting.load = function (search) {
        var url = urlBase;
        if (search != null && !angular.isUndefined(search)) {
            url = url + '?search=' + search;
        }
        return $http.get(url);
    };

    posting.get = function (id) {
        return $http.get(urlBase + '/' + id);
    };

    posting.delete = function (id) {
        return $http.delete(urlBase + '/' + id);
    };

    posting.insert = function (person) {
        return $http.post(urlBase, person);
    };

    posting.update = function (person) {
        return $http.put(urlBase + '/' + person.Id, person);
    };

    return person;
}]);

/* Main controller */

app.controller('mainController', ['$scope', '$http', '$timeout', '$mdDialog', '$mdMedia', '$window', 'personFactory', 'Upload',
    function ($scope, $http, $timeout, $mdDialog, $mdMedia, $window, personFactory, Upload) {

        /* Set variables */
        $scope.people;
        $scope.isLoading = true;

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
            postingFactory.load($scope.search)
                .then(function (response) {
					console.log('Getting people - response');
                    if (page > 1) {
                        $scope.postings = $scope.postings.concat(response.data);
                    } else {
                        $scope.postings = response.data;
                    }
                    $scope.isLoading = false;
                }, function (error) {
                    console.log('Unable to load posting data: ' + error.message);
                });
        }

        $scope.getPosting = function (postingID) {
            postingFactory.get(postingID)
                .then(function (response) {
                    return response.data;
                }, function (error) {
                    console.log('Unable to load single posting data: ' + error.message);
                });
        }

        $scope.loadMore = function (ev) {
            $scope.page = $scope.page + 1;
            getPostings($scope.page);
        };

        $scope.searchPostings = function (ev) {
            $scope.page = 1;
            getPostings();
        }

        $scope.loadNews = function (ev, newsID, title, background, url) {
            $scope.newsID = newsID;
            $scope.search = null;
            $scope.year = null;
            if (!angular.isUndefined(url)) {
                $window.location.href = url;
            } else {
                // update the url for SEO
                if (newsID == null || angular.isUndefined(newsID) || newsID == "") {
                    $location.url($location.path());
                } else {
                    $location.search('newsID', newsID);
                }
            }
            // see if local news admin for this page
            if ($scope.postingPerson.Admin == true) {
                $scope.postingPerson.NewsAdmin = true;
            } else {
                $scope.postingPerson.NewsAdmin = false;
                var elementPos = $scope.postingPerson.News.map(function (x) { return x.NewsID; }).indexOf(newsID);
                if (elementPos > -1) {
                    $scope.postingPerson.NewsAdmin = true;
                }
            }

            $scope.page = 1;
            $scope.newsID = newsID;
            $scope.news.title = title;
            $scope.news.image = background;
            getPostings($scope.page);

            $mdSidenav('sideNav').close();
        };

        $scope.insertPosting = function (posting) {
            postingFactory.insert(posting)
                .then(function (response) {
                    // update ID in case there's a desire to delete or edit
                    posting.PostingID = response.data.PostingID;
                    console.log('Inserted posting, refreshing');
                    $scope.postings.splice(0, 0, posting);
                }, function (error) {
                    console.log('Unable to insert posting: ' + error.message);
                });
        };

        $scope.updatePosting = function (posting) {
            postingFactory.update(posting)
                .then(function (response) {
                    console.log('Updated posting, refreshing');
                }, function (error) {
                    console.log('Unable to update posting: ' + error.message);
                });
        };

        $scope.deletePosting = function (id) {
            postingFactory.delete(id)
            .then(function (response) {
                console.log('Deleted posting, refreshing');
                for (var i = 0; i < $scope.postings.length; i++) {
                    var posting = $scope.postings[i];
                    if (posting.PostingID === id) {
                        $scope.postings.splice(i, 1);
                        break;
                    }
                }
            }, function (error) {
                console.log('Unable to delete posting: ' + error.message);
            });
        };

        $scope.getPostingPerson = function (password) {
            if (angular.isUndefined(password))
                return false;

            var url = '/BlogService/api/postingpersons/?password=' + password;
            $http.get(url).then(function (response) {
                if (response) {
                    $scope.postingPerson = response.data;
                    if ($scope.postingPerson.Admin == true) {
                        $scope.postingPerson.NewsAdmin = true;
                    } else {
                        $scope.postingPerson.NewsAdmin = false;
                    }
                }
            });
        };

        $scope.insertComment = function (comment, postingID, answer) {
            var postedDate = new Date();
            postedDate.toISOString();
            var comment = {
                PostingID: postingID,
                CommentText: comment.CommentText,
                PostedBy: $scope.postingPerson.PostingPersonID,
                PostedByName: comment.PostedByName,
                PostedDate: postedDate
            };
            if (!answer)
                answer = "None";
            commentFactory.insert(comment, answer, $scope)
                .then(function (response) {
                    // update ID in case there's a desire to delete or edit
                    comment.CommentID = response.data.CommentID;
                    // update other fields to ensure data integrity
                    comment.PostingPersonID = response.data.PostedBy;
                    comment.PostedByName = response.data.PostedByName;

                    console.log('Inserted comment, refreshing');
                    // find posting by id and append
                    var elementPos = $scope.postings.map(function (x) { return x.PostingID; }).indexOf(comment.PostingID);
                    var posting = $scope.postings[elementPos];

                    posting.Comments = posting.Comments.concat(comment);
                }, function (error) {
                    console.log('Unable to insert comment: ' + error.message);
                });
        };

        $scope.deleteComment = function (id, postingID) {
            commentFactory.delete(id)
            .then(function (response) {
                console.log('Deleted comment, refreshing');
                // find posting by id and remove
                var elementPos = $scope.postings.map(function (x) { return x.PostingID; }).indexOf(postingID);
                var posting = $scope.postings[elementPos];
                var commentElementPos = posting.Comments.map(function (x) { return x.CommentID; }).indexOf(id);
                posting.Comments.splice(commentElementPos, 1);

            }, function (error) {
                console.log('Unable to delete posting: ' + error.message);
            });
        };

        $scope.getCurrentPostingPerson = function () {
            var password = $cookies.get('password');
            if (password !== "") {
                $scope.getPostingPerson(password);
            } else {
                $scope.postingPerson = {
                    PostingPersonID: 0,
                    PostingPersonName: "",
                    Admin: false,
                    NewsAdmin: false,
                    News: [
                        {
                            NewsID: 0
                        }
                    ]
                };
            }
        };

        $scope.uploadFile = function (event, scope, posting, file) {
            Upload.upload({
                url: 'BlogService/api/files/' + posting.PostingID,
                data: { file: file, 'PostingID': posting.PostingID }
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

        $scope.setPassword = function (password) {
            var expireDate = new Date();
            expireDate.setDate(expireDate.getDate() + 30);
            $cookies.put('password', password, { 'expires': expireDate });
            $scope.getPostingPerson(password);
        };

        $scope.logout = function (ev) {
            $scope.setPassword('');
            $scope.getCurrentPostingPerson();
        };

        /* Get user information */
        $scope.getCurrentPostingPerson();

        /* Get postings by default - check url after route data is loaded */
        $scope.$on('$routeChangeSuccess', function ($routeParams) {
            $scope.newsID = $route.current.params.newsID;
            $scope.year = $route.current.params.year;
            getPostings();
        });

        // Full image dialog when image clicked
        // Somewhat messy due to data quality
        $scope.displayFullImage = false;
        $scope.clickThumbnail = function (href, scope) {
            $mdDialog.show({
                template:
                  '<img class="fullscreenImage" src=' + href + ' ng-click="closeDialog()" ng-show="displayFullImage">' +
                  '<md-button class="md-fab md-fab-bottom-right" href="' + href + '">' +
                  '<md-icon md-font-library="material-icons" class="md-light">file_download</md-icon>' +
                  '<md-tooltip md-direction="top">Download File</md-tooltip></md-button>' +
                  '<md-dialog class="fullscreen-dialog">' +
                  '<md-dialog-content ng-click="closeDialog()">' +
                  '<div layout="row" layout-align="end start">' +
                  '<md-button class="md-icon-button" ng-click="closeDialog()">' +
                  '<md-icon md-font-library="material-icons" class="md-light">close</md-icon>' +
                  '</div>' +
                  '</md-dialog-content>' +
                  '</md-dialog>',
                controller: DialogController,
                onComplete: afterShowAnimation,
                locals: { displayFullImage: $scope.displayFullImage }
            });
            function DialogController($scope, $mdDialog) {
                $scope.closeDialog = function () {
                    $scope.displayFullImage = false;
                    $mdDialog.hide();
                };
            }
            function afterShowAnimation($scope, element, options) {
                $scope.displayFullImage = true;
            }
        };

        /* Dialog management */
        $scope.showAdd = function (ev, textAngularManager, scope) {
            var useFullScreen = ($mdMedia('sm') || $mdMedia('xs')) && $scope.customFullscreen;

            // Firefox has an issue where some data has to be passed
            // otherwise no data will be returned
            $scope.posting = {
                PostingID: 0,
                Title: "test",
                Body: " "
            };

            $mdDialog.show({
                controller: DialogController,
                templateUrl: '/pages/PostDialog.tmpl.html',
                parent: angular.element(document.body),
                targetEvent: ev,
                // pass posting data
                locals: { posting: $scope.posting, tinymceOptions: $scope.tinymceOptions },
                clickOutsideToClose: false,
                fullscreen: useFullScreen,
                onComplete: function ($timeout) {
                    tinyMCE.activeEditor.focus();
                }
            })
            .then(function (posting) {
                var postedDate = new Date();
                postedDate.toISOString();
                if ($scope.newsID > 0) {
                    posting.NewsID = $scope.newsID;
                } else {
                    // administrators post in family by default
                    // other users post in their area
                    if ($scope.postingPerson.Admin) {
                        posting.NewsID = 1;
                    } else {
                        posting.NewsID = $scope.postingPerson.News[0].NewsID;
                    }
                }
                posting.PostedBy = 1;
                posting.PostedDate = postedDate;
                $scope.insertPosting(posting);

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


        $scope.showUpdate = function (ev, scope, posting) {
            var useFullScreen = ($mdMedia('sm') || $mdMedia('xs')) && $scope.customFullscreen;
            $mdDialog.show({
                controller: DialogController,
                templateUrl: '/pages/PostDialog.tmpl.html',
                parent: angular.element(document.body),
                targetEvent: ev,
                // pass posting data
                locals: { posting: posting, tinymceOptions: $scope.tinymceOptions },
                clickOutsideToClose: false,
                fullscreen: useFullScreen,
                onComplete: function ($timeout) {
                    tinyMCE.activeEditor.focus();
                }
            })
            .then(function (posting) {
                $scope.updatePosting(posting);
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

        function DialogController($scope, $mdDialog, posting, tinymceOptions) {
            $scope.posting = posting;
            $scope.tinymceOptions = tinymceOptions;
            $scope.hide = function () {
                $mdDialog.hide();
            };
            $scope.cancel = function () {
                $mdDialog.cancel();
            };
            $scope.answer = function (posting) {
                $mdDialog.hide(posting);
            };


        }

        // Delete posting confirmation
        $scope.deletePostConfirm = function (ev, PostingID, scope) {
            var confirm = $mdDialog.confirm(PostingID)
                  .title('Would you like to delete this post?')
                  .textContent('This will mark the post as being deleted.')
                  .ariaLabel('Delete Post')
                  .targetEvent(ev)
                  .ok('Delete Post')
                  .cancel('Nevermind');
            $mdDialog.show(confirm).then(function () {
                console.log('Delete confirmed for PostingID ' + PostingID);
                $scope.deletePosting(PostingID);
            }, function () {
                console.log('Delete canceled.');
            });
        };

        $scope.showPasswordDialog = function (ev, scope) {
            var password = "";
            $mdDialog.show({
                controller: PasswordDialogController,
                templateUrl: '/pages/PasswordDialog.tmpl.html',
                parent: angular.element(document.body),
                targetEvent: ev,
                locals: { password: password },
                clickOutsideToClose: true,
                onComplete: function ($timeout) {
                    // select input - not completely angular, but simple
                    var el = document.querySelector(".passwordTextBox");
                    el.setAttribute("tabindex", "1");
                    el.focus();
                }
            })
            .then(function (password) {
                $scope.setPassword(password);
            }, function () {
                console.log('Password dialog cancelled.');
            });
        };

        function PasswordDialogController($scope, $mdDialog, password) {
            $scope.hide = function () {
                $mdDialog.hide();
            };
            $scope.cancel = function () {
                $mdDialog.cancel();
            };
            $scope.answer = function (password) {
                $mdDialog.hide(password);
            };
        }

        $scope.showCommentDialog = function (ev, posting, postingPerson) {
            var comment = {
                CommentID: 0,
                CommentText: " ",
                PostedBy: postingPerson.PostingPersonID
            };
            $mdDialog.show({
                controller: CommentDialogController,
                templateUrl: '/pages/CommentDialog.tmpl.html',
                parent: angular.element(document.body),
                targetEvent: ev,
                locals: { comment: comment, posting: posting, postingPerson: $scope.postingPerson },
                clickOutsideToClose: true,
                onComplete: function ($timeout) {
                    // adjust focus depending on login status
                    if (postingPerson.PostingPersonID > 0) {
                        var el = document.querySelector(".commentTextBox");
                        el.setAttribute("tabindex", "1");
                        comment.PostedBy = postingPerson.postingPersonID;
                    } else {
                        var el = document.querySelector(".commentAnswer");
                    }
                    el.focus();
                }
            })
            .then(function (comment) {
                if (angular.isUndefined(comment)) {
                    $mdDialog.alert()
                      .clickOutsideToClose(true)
                      .title('No Comment Entered')
                      .textContent('Your comment didn\'t take.')
                      .ariaLabel('No comment?')
                      .ok('Oops')
                      .targetEvent(ev);
                } else {
                    console.log(posting.PostingID);
                    $scope.insertComment(comment, posting.PostingID, comment.Answer);
                    posting = $scope.getPosting(posting.PostingID);
                };
            }, function () {
                console.log('Comment dialog cancelled.');
            });
        };

        function CommentDialogController($scope, $mdDialog, comment, postingPerson) {
            $scope.postingPerson = postingPerson;
            $scope.hide = function () {
                $mdDialog.hide();
            };
            $scope.cancel = function () {
                $mdDialog.cancel();
            };
            $scope.answer = function (comment) {
                $mdDialog.hide(comment);
            };
        }

        // Delete posting confirmation
        $scope.deleteCommentConfirmation = function (ev, comment, posting, admin) {
            // only allow delete for admins
            if (admin == false)
                return;

            var confirm = $mdDialog.confirm(comment.CommentID)
                  .title('Would you like to delete this comment?')
                  .textContent('This will mark the comment as being deleted.')
                  .ariaLabel('Delete Comment')
                  .targetEvent(ev)
                  .ok('Delete Comment')
                  .cancel('Nevermind');
            $mdDialog.show(confirm).then(function () {
                console.log('Delete confirmed for CommentID ' + comment.CommentID + ' on post ' + posting.PostingID);
                $scope.deleteComment(comment.CommentID, posting.PostingID);
                posting = $scope.getPosting(posting.PostingID);
            }, function () {
                console.log('Delete canceled.');
            });
        };

        // display dialogs in full screen for small displays
        $scope.customFullscreen = $mdMedia('xs') || $mdMedia('sm');

        $scope.toggleSideNav = function () {
            $mdSidenav('sideNav').toggle();
        };

        $scope.menu = [
          {
              newsID: '',
              title: 'All Posts',
              icon: '/site/news/1_60.png',
              newsName: 'All Posts',
              image: '/site/news/1.png'
          },
          {
              newsID: 2,
              title: 'Adam\'s News',
              icon: '/site/news/2_60.png',
              image: '/site/news/2.png',
              newsName: 'Adam\'s News'
          },
          {
              newsID: 3,
              title: 'Projects',
              icon: '/site/news/3_60.png',
              image: '/site/news/3.png',
              newsName: 'Adam\'s Projects'
          },
          {
              newsID: 4,
              title: 'Games',
              icon: '/site/news/4_60.png',
              image: '/site/news/4.png',
              newsName: 'Adam\'s Games'
          },
          {
              newsID: 1,
              title: 'Family',
              icon: '/site/news/1_60.png',
              image: '/site/news/1.png',
              newsName: 'Family'
          },
          {
              newsID: 34,
              title: 'Joanna',
              icon: '/site/news/34_60.png',
              image: '/site/news/34.png',
              newsName: 'Joanna'
          },
          {
              newsID: 14,
              title: 'Emma',
              icon: '/site/news/14_60.png',
              image: '/site/news/14.png',
              newsName: 'Emma'
          },
          {
              newsID: 6,
              title: 'Sam',
              icon: '/site/news/6_60.png',
              image: '/site/news/6.png',
              newsName: 'Sam'
          },
          {
              newsID: 36,
              title: 'Berry',
              icon: '/site/news/36_60.png',
              image: '/site/news/36.png',
              newsName: 'Berry'
          },
          {
              newsID: 37,
              title: 'Duncan',
              icon: '/site/news/37_60.png',
              image: '/site/news/37.png',
              newsName: 'Duncan'
          },
          {
              newsID: 9,
              title: 'Sadie & Greg',
              icon: '/site/news/9_60.png',
              image: '/site/news/9.png',
              newsName: 'Sadie, Greg, and Simon'
          },
          {
              newsID: 7,
              title: 'Cortez',
              icon: '/site/news/7_60.png',
              image: '/site/news/7.png',
              newsName: 'Seraph and Robbie'
          },
          {
              newsID: 8,
              title: 'Jenny',
              icon: '/site/news/8_60.png',
              image: '/site/news/8.png',
              newsName: 'Jenny'
          },
          {
              newsID: 10,
              title: 'Wielesek',
              icon: '/site/news/10_60.png',
              image: '/site/news/10.png',
              newsName: 'Mom'
          },
          {
              newsID: 11,
              title: 'Lohring',
              icon: '/site/news/11_60.png',
              image: '/site/news/11.png',
              newsName: 'Dad'
          },
          {
              newsID: 33,
              title: 'Yayoe',
              icon: '/site/news/33_60.png',
              image: '/site/news/33.png',
              newsName: 'Yayoe'
          },
          {
              newsID: 13,
              title: 'Danica',
              icon: '/site/news/13_60.png',
              image: '/site/news/13.png',
              newsName: 'Danica'
          },
          {
              newsID: 32,
              title: 'Robot',
              icon: '/site/news/robot_60.png',
              image: '/site/news/robot.png',
              newsName: 'Robot Dreams'
          },
          {
              title: 'Album',
              icon: '/site/news/album_60.png',
              url: '//familyofadam.com/album.aspx',
              external: true
          },
          {
              title: 'Movies',
              icon: '/site/news/movie_60.png',
              url: 'https://www.youtube.com/user/PIPBoy4000',
              external: true
          },
          {
              newsID: 35,
              title: 'Izzy',
              icon: '/site/news/35_60.png',
              image: '/site/news/35.png',
              newsName: 'Izzy'
          },
          {
              newsID: 23,
              title: 'Betsy',
              icon: '/site/news/23_60.png',
              image: '/site/news/23.png',
              newsName: 'Betsy'
          },
          {
              newsID: 29,
              title: 'Lytton',
              icon: '/site/news/29_60.png',
              image: '/site/news/29.png',
              newsName: 'Lytton'
          },
          {
              newsID: 26,
              title: 'Hanni',
              icon: '/site/news/26_60.png',
              image: '/site/news/26.png',
              newsName: 'Hanni'
          },
        ];

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

/* This will load more posts at the bottom of the page */
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