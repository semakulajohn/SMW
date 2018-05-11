﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMW.DTO;
using SMW.BAL.Interface;
using SMW.DAL.Interface;
using SMW.Models;
using SMW.Helpers;
using log4net;

namespace SMW.BAL.Concrete
{
 public   class ProjectService : IProjectService
    {
      ILog logger = log4net.LogManager.GetLogger(typeof(ProjectService));
        private IProjectDataService _dataService;
        private IUserService _userService;
       
        

        public ProjectService(IProjectDataService dataService,IUserService userService)
        {
            this._dataService = dataService;
            this._userService = userService;
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <returns></returns>
        public Project GetProject(long projectId)
        {
            var result = this._dataService.GetProject(projectId);
            return MapEFToModel(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Project> GetAllProjects()
        {
            var results = this._dataService.GetAllProjects();
            return MapEFToModel(results);
        } 

       
        public long SaveProject(Project project, string userId)
        {
            var projectDTO = new DTO.ProjectDTO()
            {
                ProjectId = project.ProjectId,
                Title = project.Title,
                Description = project.Description,
                ClientId = project.ClientId,
                MediaFolderId = project.MediaFolderId,
                    

            };

           var projectId = this._dataService.SaveProject(projectDTO, userId);

           return projectId;
                      
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <param name="userId"></param>
        public void MarkAsDeleted(long projectId, string userId)
        {
            _dataService.MarkAsDeleted(projectId, userId);
        }

      
        #region Mapping Methods

        private IEnumerable<Project> MapEFToModel(IEnumerable<EF.Models.Project> data)
        {
            var list = new List<Project>();
            foreach (var result in data)
            {
                list.Add(MapEFToModel(result));
            }
            return list;
        }

        /// <summary>
        /// Maps Project EF object to Project Model Object and
        /// returns the Project model object.
        /// </summary>
        /// <param name="result">EF Project object to be mapped.</param>
        /// <returns>Project Model Object.</returns>
        public Project MapEFToModel(EF.Models.Project data)
        {
            var clientFullName = string.Empty;
            var client = _userService.GetAspNetUser(data.ClientId);
            if (client != null)
            {
                 clientFullName = client.FirstName + ' ' + client.LastName;
            }
            
          
            var project = new Project()
            {
                ProjectId = data.ProjectId,
                Title = data.Title,
                Description = data.Description,
                ClientId = data.ClientId,
                CreatedOn = data.CreatedOn,
                MediaFolderId = data.MediaFolderId,
                Timestamp = data.Timestamp,
                CreatedBy = _userService.GetUserFullName(data.AspNetUser),
                UpdatedBy = _userService.GetUserFullName(data.AspNetUser1),
                ClientName = clientFullName,
               

            };
            return project;
        }



       #endregion
    }
}