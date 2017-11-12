using MongoDB.Bson.Serialization.Attributes;

namespace Cellar.Api.DataAccess.Domain
{
    public class BdoActionLog : MongoObjectBase
    {
        [BsonElement("RequestId")]
        public string RequestId { get;set; }

        [BsonElement("RequestMethod")]
        public string RequestMethod { get; set; }

        [BsonElement("ActionRoute")]
        public string ActionRoute { get; set; }

        [BsonElement("LogType")]
        public string LogType { get; set; }

        [BsonElement("LogLevel")]
        public string LogLevel { get; set; }

        [BsonElement("LogBody")]
        public string LogBody { get; set; }
    }
}
