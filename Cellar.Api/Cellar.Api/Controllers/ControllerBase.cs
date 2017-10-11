using Cellar.Api.Business.Api;
using Cellar.Api.Business.Implementation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cellar.Api.Controllers
{
    public class ControllerBase : Controller
    {
        protected IDummyDataProvider DummyDataProvider { get; set; }

        public ControllerBase()
        {
            DummyDataProvider = new DummyDataProvider();
        }
    }
}
