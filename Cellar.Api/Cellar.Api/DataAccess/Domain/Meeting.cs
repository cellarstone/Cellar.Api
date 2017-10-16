using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cellar.Api.DataAccess.Domain
{
    public class Meeting
    {
        public ObjectId Id { get; set; }

        [BsonElement("Start")]
        public DateTime Start { get; set; }

        [BsonElement("End")]
        public DateTime End { get; set; }

        [BsonElement("RoomId")]
        public string RoomId { get; set; }

        [BsonElement("Author")]
        public string Author { get; set; }
    }
}
