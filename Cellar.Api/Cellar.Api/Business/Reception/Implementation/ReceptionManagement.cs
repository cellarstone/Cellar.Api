using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cellar.Api.Models;
using Cellar.Api.Models.Requests.Reception;
using Cellar.Api.DataAccess.Api.Repository;
using Cellar.Api.DataAccess.Domain;
using Cellar.Api.Business.Reception.Api;
using Cellar.Api.Business.Authentication.Api;

namespace Cellar.Api.Business.Reception.Implementation
{
    public class ReceptionManagement : IReceptionManagement
    {
        #region --- injected resources ------------------------------------------------------------
        private readonly ISortimentItemsRepository sortimentItemsRepository;
        private readonly IAuthenticationManagement authenticationManagement;
        #endregion

        #region --- ctor --------------------------------------------------------------------------
        public ReceptionManagement(ISortimentItemsRepository sortimentItemsRepository, IAuthenticationManagement authenticationManagement)
        {
            this.sortimentItemsRepository = sortimentItemsRepository;
            this.authenticationManagement = authenticationManagement;
        }
        #endregion

        #region --- IReceptionManagement members --------------------------------------------------
        public bool CallForClean(string roomId, string cleanType)
        {

            return true;
        }

        public bool CallReception(string roomId)
        {

            return true;
        }

        public List<SortimentItem> GetSortiment(string roomId)
        {
            var sortiment = sortimentItemsRepository.GetAll();
            var firstLevel = sortiment.Where(x => x.Path.Split('/').Length == 2).ToList();
            var list = firstLevel.Select(y => new SortimentItem { Id = y._id.ToString(), Name = y.Name, Path = y.Path }).ToList();
            firstLevel.ForEach(x => sortiment.Remove(x));

            //do
            //{
            //    var nextLevel = 
            //} while (sortiment.Count > 0);
            

            return null;
        }

        public bool PlaceOrder(string roomId, PlaceOrderRequest order)
        {


            return true;
        }

        public bool SomethingElse(string roomId, string message)
        {


            return true;
        }

        public bool ValidatePin(string pin)
        {
            var result = authenticationManagement.ValidatePin(pin);

            return result;
        }
        #endregion

        #region --- private methods ---------------------------------------------------------------
        private object FillSortimentChildItems(List<BdoSortimentItem> firstLevel)
        {
            return null;
            
        }
        #endregion
    }
}
