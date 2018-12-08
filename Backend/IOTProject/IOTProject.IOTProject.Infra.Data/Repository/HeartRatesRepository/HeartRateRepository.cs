using System;
using System.Collections.Generic;
using IOTProject.IOTProject.Domain.HeartRates;
using IOTProject.IOTProject.Domain.HeartRates.HeartRateInterfaces.Repositories;
using MongoDB.Driver;

namespace IOTProject.IOTProject.Infra.Data.Repository.HeartRatesRepository
{
    public class HeartRateRepository : IHeartRateRepository
    {
        public HeartRate GetById(Guid id)
        {
            var client = new MongoClient(IotMongoDb.Connection);
            var database = client.GetDatabase(IotMongoDb.DataBase);

            var filter = Builders<HeartRate>.Filter.Eq("Id", id);

            return database.GetCollection<HeartRate>("HeartRates").Find(filter).FirstOrDefault();
        }

        public IEnumerable<HeartRate> GetByPersonId(Guid personId)
        {
            var client = new MongoClient(IotMongoDb.Connection);
            var database = client.GetDatabase(IotMongoDb.DataBase);

            return database.GetCollection<HeartRate>("HeartRates").AsQueryable();
        }

        public IEnumerable<HeartRate> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Create(HeartRate person)
        {
            var client = new MongoClient(IotMongoDb.Connection);
            var database = client.GetDatabase(IotMongoDb.DataBase);

            var collection = database.GetCollection<HeartRate>("HeartRates");

            collection.InsertOne(person);
        }

        public void Delete(HeartRate person)
        {
            throw new NotImplementedException();
        }
    }
}
