using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using helloworldapi.Models;

namespace helloworldapi.Controllers
{
    [Route("api/mongodb")]
    public class MongodbController : Controller
    {
        MongoClient _client;
        IMongoDatabase _database;
        IMongoCollection<HelloWorldMessage> _collection;
        private string _collectionname = "helloworldcollection";
        private bool _isInitiliased = false;

        public MongodbController()
        {

            //InitializeDB();
        }

        private void InitializeDB()
        {
            string username = "devadmin";
            string password = "devadmin";
            string mongoDbAuthMechanism = "SCRAM-SHA-1";
            MongoInternalIdentity internalIdentity =
                      new MongoInternalIdentity("admin", username);

            PasswordEvidence passwordEvidence = new PasswordEvidence(password);
            MongoCredential credential =
                 new MongoCredential(mongoDbAuthMechanism,
                         internalIdentity, passwordEvidence);

            string connectionString = "mongodb://mongodb:27017";
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.Credential = credential;

            _client = new MongoClient(settings);

            _database = _client.GetDatabase("helloworld");
            _collection = _database.GetCollection<HelloWorldMessage>(_collectionname);
            _isInitiliased = true;
        }

        private void WriteData(HelloWorldMessage document)
        {
            _collection.InsertOne(document);
        }

        private void WriteData(string id, HelloWorldMessage document)
        {
            document.ID = id;
            _collection.InsertOne(document);
        }

        private IList<HelloWorldMessage> ReadData()
        {
            var query = from messages in _collection.AsQueryable<HelloWorldMessage>()
                        select messages;

            return query.ToList();
        }

        private HelloWorldMessage ReadData(string id)
        {
            var query = from messages in _collection.AsQueryable<HelloWorldMessage>()
                        .Where(m => m.ID.Equals(id))
                        select messages;

            return query.FirstOrDefault();
        }

        private void DeleteData(string id)
        {
            _collection.DeleteOne(m => m.ID == id);
        }

        // GET api/values
        [HttpGet]
        public IList<HelloWorldMessage> Get()
        {
            if (!_isInitiliased) { InitializeDB(); }
            return ReadData();
        }

        // GET api/values/523
        [HttpGet("{id}")]
        public HelloWorldMessage Get(string id)
        {
            if (!_isInitiliased) { InitializeDB(); }
            return ReadData(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]HelloWorldMessage value)
        {
            if (!_isInitiliased) { InitializeDB(); }
            WriteData(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]HelloWorldMessage value)
        {
            if (!_isInitiliased) { InitializeDB(); }
            WriteData(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            if (!_isInitiliased) { InitializeDB(); }
            DeleteData(id);
        }
    }
}
