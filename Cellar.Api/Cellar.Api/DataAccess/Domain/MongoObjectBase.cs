using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Cellar.Api.DataAccess.Domain
{
    /// <summary>
    /// Base object for MongoDb row (Document)
    /// </summary>
    public class MongoObjectBase
    {
        /// <summary>
        /// ObjectId provided by MongoDb
        /// </summary>
        public ObjectId _id { get; set; }

        /// <summary>
        /// Timestamp when object has been created
        /// </summary>
        [BsonElement("CreatedDateTime")]
        public DateTime? CreatedDateTime { get; set; }
    }
}
