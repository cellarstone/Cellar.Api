using Cellar.Api.Models;
using Cellar.Api.Models.Requests.Reception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cellar.Api.Business.Reception.Api
{
    public interface IReceptionManagement
    {
        bool CallForClean(string roomId, string cleanType);

        bool CallReception(string roomId);

        bool SomethingElse(string roomId, string message);

        List<SortimentItem> GetSortiment(string roomId);

        bool PlaceOrder(string roomId, PlaceOrderRequest order);

        bool ValidatePin(string pin);
    }
}
