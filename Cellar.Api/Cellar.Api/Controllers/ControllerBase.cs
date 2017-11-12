using Cellar.Api.Business.Dummy.Api;
using Cellar.Api.Business.Dummy.Implementation;
using Cellar.Api.DataAccess.Implementation.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cellar.Api.Controllers
{
    public class ControllerBase : Controller
    {
        /// <summary>
        /// Unique http request id. Request and response logs are paired by this id
        /// </summary>
        public string RequestId { get; }

        protected readonly IDummyDataProvider DummyDataProvider;

        public ControllerBase()
        {
            DummyDataProvider = new DummyDataProvider(new SortimentItemsRepository());
            RequestId = Guid.NewGuid().ToString("N");
        }
    }
}
