using Cellar.Api.DataAccess.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cellar.Api.DataAccess.Api.Repository
{
    /// <summary>
    /// Base repository form MongoDb providing basic CRUD operations
    /// </summary>
    /// <typeparam name="TMongoObject">MongoObjectBase</typeparam>
    public interface IMongoRepositoryBase<TMongoObject> where TMongoObject : MongoObjectBase
    {
        /// <summary>
        /// (C) Add new item to collection
        /// </summary>
        /// <param name="item">item to add</param>
        bool Add(TMongoObject item);
        Task<bool> AddAsync(TMongoObject item);

        /// <summary>
        /// (R) Get all items in Mongo collection
        /// </summary>
        IList<TMongoObject> GetAll();
        Task<IList<TMongoObject>> GetAllAsync();

        /// <summary>
        /// (R) Get one item by its _id field
        /// </summary>
        /// <param name="id">_id</param>
        TMongoObject GetById(string id);
        Task<TMongoObject> GetByIdAsync(string id);

        /// <summary>
        /// (U) Update the given item
        /// Method is ABSTRACT. Concrete repository implementation has to implement it
        /// </summary>
        /// <param name="item">item for update</param>
        bool Update(TMongoObject item);
        Task<bool> UpdateAsync(TMongoObject item);

        /// <summary>
        /// (D) Delete item from collection
        /// </summary>
        /// <param name="item">item to delete</param>
        bool Delete(TMongoObject item);
        Task<bool> DeleteAsync(TMongoObject item);
    }
}
