using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cellar.Api.Business.Api
{
    interface IReceptionManagement
    {
        bool CallForClean(string roomId, string cleanType);

        bool CallReception(string roomId);

        bool SomethingElse(string roomId, string message);


    }
}
