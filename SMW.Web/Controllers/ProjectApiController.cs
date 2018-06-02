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
    public class ProjectApiController : ApiController
    {
        private IProjectService _projectService;
        private IUserService _userService;
        ILog logger = log4net.LogManager.GetLogger(typeof(ProjectApiController));
        private string userId = string.Empty;

        public ProjectApiController()
        {
        }

        public ProjectApiController(IProjectService projectService, IUserService userService)
        {
            this._projectService = projectService;
            this._userService = userService;
            userId = Microsoft.AspNet.Identity.IdentityExtensions.GetUserId(RequestContext.Principal.Identity);
        }

        [HttpGet]
        [ActionName("GetProject")]
        public Project GetProject(long projectId)
        {
            return _projectService.GetProject(projectId);
        }

        [HttpGet]
        [ActionName("GetLatestProjects")]
        public IEnumerable<Project> GetLatestProjects()
        {
   //      not yet implemented.   
            return _projectService.GetAllProjects();
        }

    }
}
