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
            var client = new MongoClient(IotMongoDb.Connection);
            var database = client.GetDatabase(IotMongoDb.DataBase);
            
            var filter = Builders<Person>.Filter.Eq("Id", person.Id);

            var update = Builders<Person>.Update.Set("Name", person.Name)
                                                .Set("Email", person.Email)
                                                .Set("BirthDate", person.BirthDate)
                                                .Set("IsFitness", person.IsFitness)
                                                .Set("IsSmoker", person.IsSmoker)
                                                .Set("HasCardiovascularDisease", person.HasCardiovascularDisease)
                                                .Set("HasHighCholesterol", person.HasHighCholesterol)
                                                .Set("HasDiabetes", person.HasDiabetes)
                                                .Set("AlterDate", person.AlterDate)
                                                .Set("DeleteDate", person.DeleteDate)
                                                .Set("Active", person.Active);

            var collection = database.GetCollection<Person>("People");
            collection.UpdateOne(filter, update);
        }

        public void Delete(Person person)
        {
            var client = new MongoClient(IotMongoDb.Connection);
            var database = client.GetDatabase(IotMongoDb.DataBase);

            var filter = Builders<Person>.Filter.Eq("Id", person.Id);

            var collection = database.GetCollection<Person>("People");
            collection.DeleteOne(filter);
        }
    }
}
