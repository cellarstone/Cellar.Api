using Cellar.Api.DataAccess.Api.Repository;
using Cellar.Api.DataAccess.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cellar.Api.DataAccess.Implementation.Repository
{
    public abstract class MongoRepositoryBase<TMongoObject> : IMongoRepositoryBase<TMongoObject> where TMongoObject : MongoObjectBase
    {
        #region abstract members
        public abstract string CollectionName
        {
            get;
        }
        #endregion

        #region privates
        private readonly MongoClient client;
        private readonly IMongoDatabase db;
        #endregion

        #region ctor
        public MongoRepositoryBase()
        {
            client = new MongoClient("mongodb://localhost:27017");
            db = client.GetDatabase("CellarApiDb");
        }
        #endregion

        #region interface members
        public bool Add(TMongoObject item)
        {
            try
            {
                var collection = GetCollection();
                item.CreatedDateTime = DateTime.Now;

                collection.InsertOne(item);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> AddAsync(TMongoObject item)
        {
            try
            {
                var collection = GetCollection();
                item.CreatedDateTime = DateTime.Now;

                await collection.InsertOneAsync(item);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public IList<TMongoObject> GetAll()
        {
            var collection = GetCollection();
            var result = collection.Find(x => true).ToList();

            return result;
        }

        public async Task<IList<TMongoObject>> GetAllAsync()
        {
            var collection = GetCollection();
            var result = await collection.FindAsync(x => true);

            return result.ToList();
        }

        public TMongoObject GetById(string id)
        {
            var objectId = new ObjectId(id);
            var collection = GetCollection();
            var result = collection.Find(x => x._id == objectId).FirstOrDefault();

            return result;
        }

        public abstract bool Update(TMongoObject item);

        public bool Delete(TMongoObject item)
        {
            try
            {
                var collection = GetCollection();
                var filter = Builders<TMongoObject>.Filter.Eq("_id", item._id);
                collection.DeleteOne(filter);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region protected methods
        /// <summary>
        /// Reurns collection which comes from concrete repositor implementation.
        /// If collection does not exits, it will creates new and return it.
        /// </summary>
        /// <returns>IMongoCollection</returns>
        protected IMongoCollection<TMongoObject> GetCollection()
        {
            var collection = db.GetCollection<TMongoObject>(CollectionName);
            if (collection == null)
            {
                db.CreateCollection(CollectionName);
                collection = db.GetCollection<TMongoObject>(CollectionName);
            }
            return collection;
        }

        

        public Task<TMongoObject> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(TMongoObject item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(TMongoObject item)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
