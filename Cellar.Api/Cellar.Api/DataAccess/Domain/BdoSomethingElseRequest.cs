using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cellar.Api.DataAccess.Domain
{
    public class BdoSomethingElseRequest : MongoObjectBase
    {
        [BsonElement("RoomId")]
        public string RoomId { get; set; }

        [BsonElement("Message")]
        public string Message { get; set; }

        [BsonElement("HandledByReception")]
        public bool HandledByReception { get; set; }
    }
}
