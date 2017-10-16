using Cellar.Api.Business.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cellar.Api.Business.Implementation
{
    public class ReceptionManagement : IReceptionManagement
    {
        public bool CallForClean(string roomId, string cleanType)
        {

            return true;
        }

        public bool CallReception(string roomId)
        {

            return true;
        }

        public bool SomethingElse(string roomId, string message)
        {
            throw new NotImplementedException();
        }
    }
}
