
using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.IdGenerators;

namespace helloworldapi.Models
{
    [BsonIgnoreExtraElements]
    public class HelloWorldMessage 
    {
         [BsonId] // the _id field
        [BsonRepresentation(BsonType.ObjectId)]
       // [BsonId(IdGenerator = typeof(MongoDB.Bson.Serialization.IdGenerators.GuidGenerator))]
        public string ID { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Message")]
        public string Message { get; set; }
        [BsonElement("Created_By")]
        public string CreatedBy { get; set; }

        [BsonElement("Created_Date")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedDate { get; set; }
    }
}