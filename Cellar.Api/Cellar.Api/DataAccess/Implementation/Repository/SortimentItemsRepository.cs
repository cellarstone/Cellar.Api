using Cellar.Api.DataAccess.Api.Repository;
using Cellar.Api.DataAccess.Domain;
using MongoDB.Driver;

namespace Cellar.Api.DataAccess.Implementation.Repository
{
    public class SortimentItemsRepository : MongoRepositoryBase<BdoSortimentItem>, ISortimentItemsRepository
    {
        #region abstract properties
        public override string CollectionName => "SortimentItems";
        #endregion

        #region abstract methods
        public override bool Update(BdoSortimentItem item)
        {
            try
            {
                var collection = GetCollection();
                var filter = Builders<BdoSortimentItem>.Filter.Eq("_id", item._id);
                var update = Builders<BdoSortimentItem>.Update.Set("Name", item.Name);
                collection.UpdateOne(filter, update);

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}