using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cellar.Api.DataAccess.Domain
{
    [BsonIgnoreExtraElements]
    public class BdoSortimentItem : MongoObjectBase
    {
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Path")]
        public string Path { get; set; }

        //[BsonElement("IconSvg")]
        //public string IconSvg { get; set; }
    }
}
