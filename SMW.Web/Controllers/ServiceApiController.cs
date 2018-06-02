using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SMW.BAL.Interface;
using log4net;
using SMW.Models;

namespace SMW.Web.Controllers
{
    public class ServiceApiController : ApiController
    {
        private IServiceService _serviceService;
        private IUserService _userService;
        ILog logger = log4net.LogManager.GetLogger(typeof(ServiceApiController));
        private string userId = string.Empty;

        public ServiceApiController()
        {
        }

        public ServiceApiController(IServiceService serviceService, IUserService userService)
        {
            this._serviceService = serviceService;
            this._userService = userService;
            userId = Microsoft.AspNet.Identity.IdentityExtensions.GetUserId(RequestContext.Principal.Identity);
        }

        [HttpGet]
        [ActionName("GetService")]
        public Service GetService(long serviceId)
        {
            return _serviceService.GetService(serviceId);
        }

        [HttpGet]
        [ActionName("GetAllServices")]
        public IEnumerable<Service> GetAllServices()
        {
            return _serviceService.GetAllServices();
        }



       
    }
}
