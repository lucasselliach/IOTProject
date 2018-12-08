using System;
using System.Collections.Generic;
using IOTProject.IOTProject.Domain.People;
using IOTProject.IOTProject.Domain.People.PersonInterfaces.Repositories;
using MongoDB.Driver;

namespace IOTProject.IOTProject.Infra.Data.Repository.PeopleRepository
{
    public class PersonRepository : IPersonRepository
    {
        public Person GetById(Guid id)
        {
            var client = new MongoClient(IotMongoDb.Connection);
            var database = client.GetDatabase(IotMongoDb.DataBase);

            var filter = Builders<Person>.Filter.Eq("Id", id);

            return database.GetCollection<Person>("People").Find(filter).FirstOrDefault();
        }

        public IEnumerable<Person> GetAll()
        {
            var client = new MongoClient(IotMongoDb.Connection);
            var database = client.GetDatabase(IotMongoDb.DataBase);

            return database.GetCollection<Person>("People").AsQueryable();
        }

        public void Create(Person person)
        {
            var client = new MongoClient(IotMongoDb.Connection);
            var database = client.GetDatabase(IotMongoDb.DataBase);

            var collection = database.GetCollection<Person>("People");

            collection.InsertOne(person);
        }

        public void Put(Person person)
        {
            throw new NotImplementedException();
        }

        public void Delete(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
