using System;
using System.Collections.Generic;
using MongoDB.Driver;
using Timeline.Models;

namespace Timeline.Services
{
    public class HitsService
    {
        private readonly IMongoCollection<Hit> _hits;

        public HitsService(ITimelineDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _hits = database.GetCollection<Hit>(settings.HitsCollectionName);
        }

        public List<Hit> Get() =>
            _hits.Find(hit => true).ToList();

        public Hit Get(string id) =>
            _hits.Find<Hit>(hit => hit.Id == id).FirstOrDefault();

        public Hit Create(Hit hit)
        {
            hit.setId();
            _hits.InsertOne(hit);
            return hit;
        }

        public void Update(string id, Hit hitIn) =>
            _hits.ReplaceOne(hit => hit.Id == id, hitIn);

        public void Remove(string id) =>
            _hits.DeleteOne(hit => hit.Id == id);
    }
}
