using System;
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
 public   class WebQueryService : IWebQueryService
    {
      ILog logger = log4net.LogManager.GetLogger(typeof(WebQueryService));
        private IWebQueryDataService _dataService;
       
       
        

        public WebQueryService(IWebQueryDataService dataService)
        {
            this._dataService = dataService;
                       
        }

    

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<WebQuery> GetAllWebQueries()
        {
            var results = this._dataService.GetAllWebQueries();
            return MapEFToModel(results);
        }

        
        public long SaveWebQuery(WebQuery webQuery)
        {
            var webQueryDTO = new DTO.WebQueryDTO()
            {
                WebQueryId = webQuery.WebQueryId,
                Name = webQuery.Name,
                EmailAddress = webQuery.EmailAddress,
                Body = webQuery.Body,
                CreatedOn = webQuery.CreatedOn,
                    

            };

           var webQueryId = this._dataService.SaveWebQuery(webQueryDTO);

           return webQueryId;
                      
        }

       

      
        #region Mapping Methods

        private IEnumerable<WebQuery> MapEFToModel(IEnumerable<EF.Models.WebQuery> data)
        {
            var list = new List<WebQuery>();
            foreach (var result in data)
            {
                list.Add(MapEFToModel(result));
            }
            return list;
        }

        /// <summary>
        /// Maps WebQuery EF object to WebQuery Model Object and
        /// returns the WebQuery model object.
        /// </summary>
        /// <param name="result">EF WebQuery object to be mapped.</param>
        /// <returns>WebQuery Model Object.</returns>
        public WebQuery MapEFToModel(EF.Models.WebQuery data)
        {
                       
          
            var webQuery = new WebQuery()
            {
                WebQueryId = data.WebQueryId,
                Name = data.Name,
                EmailAddress = data.EmailAddress,
                Body = data.Body,
                CreatedOn = data.CreatedOn,

            };
            return webQuery;
        }



       #endregion
    }
}
