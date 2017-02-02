// <copyright file="IPersonRepository.cs" company="Adam Miller">
// Copyright (c) Adam Miller. All rights reserved.
// </copyright>

namespace Directory.Repository
{
    using System.Collections.Generic;

    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll(int page, int pageSize, string search);

        Person Get(int id);

        void Add(Person person);

        void Update(int id, Person person);

        void Delete(int id);

        bool Exists(int id);
    }
}