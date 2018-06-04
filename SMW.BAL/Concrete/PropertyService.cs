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
   public class PropertyService : IPropertyService
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(PropertyService));
        private IPropertyDataService _dataService;
        private IUserService _userService;
       
        

        public PropertyService(IPropertyDataService dataService,IUserService userService)
        {
            this._dataService = dataService;
            this._userService = userService;
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PropertyId"></param>
        /// <returns></returns>
        public Property GetProperty(long propertyId)
        {
            var result = this._dataService.GetProperty(propertyId);
            return MapEFToModel(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Property> GetAllProperties()
        {
            var results = this._dataService.GetAllProperties();
            return MapEFToModel(results);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Property> GetAllPropertiesForAParticularPropertyType(long propertyTypeId)
        {
            var results = this._dataService.GetAllPropertiesForAParticularPropertyType(propertyTypeId);
            return MapEFToModel(results);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PropertyType> GetAllPropertyTypes()
        {
            var results = this._dataService.GetAllPropertyTypes();
            return MapEFToModel(results);
        }

        public IEnumerable<Property> GetLatestProperties()
        {
            var results = GetAllProperties().OrderByDescending(p => p.CreatedOn).Take(6);
            return results;
        }

        /// <summary>
        /// Gets four Properties randomly
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.Property> GetFeaturedProperties()
        {
            var featuredProperties = new List<Property>();
            for (int i = 0; i <= 20; i++)
            {
                var property = GetRandomProperty();
                featuredProperties.Add(property);
            }

            return featuredProperties.GroupBy(p => p.PropertyId).Select(p => p.First()).ToList().Take(4);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Property GetRandomProperty()
        {
            var results = _dataService.GetAllProperties().ToList();

            int count = results.Count();
            int index = new Random().Next(count);
            return MapEFToModel(results.Skip(index).FirstOrDefault());
        }

        public long SaveProperty(Property property, string userId)
        {
            var propertyDTO = new DTO.PropertyDTO()
            {
                PropertyId = property.PropertyId,
                Location = property.Location,
                PropertyFee = property.PropertyFee,
                MediaFolderId = property.MediaFolderId,
                Description = property.Description,
                PropertyTypeId = property.PropertyTypeId,
                
                    

            };

           var propertyId = this._dataService.SaveProperty(propertyDTO, userId);

           return propertyId;
                      
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PropertyId"></param>
        /// <param name="userId"></param>
        public void MarkAsDeleted(long propertyId, string userId)
        {
            _dataService.MarkAsDeleted(propertyId, userId);
        }

      
        #region Mapping Methods

        private IEnumerable<Property> MapEFToModel(IEnumerable<EF.Models.Property> data)
        {
            var list = new List<Property>();
            foreach (var result in data)
            {
                list.Add(MapEFToModel(result));
            }
            return list;
        }


        public PropertyType MapEFToModel(EF.Models.PropertyType data)
        {


            var propertyType = new PropertyType()
            {
                PropertyTypeId = data.PropertyTypeId,
                Name = data.Name,


            };
            return propertyType;
        }

        private IEnumerable<PropertyType> MapEFToModel(IEnumerable<EF.Models.PropertyType> data)
        {
            var list = new List<PropertyType>();
            foreach (var result in data)
            {
                list.Add(MapEFToModel(result));
            }
            return list;
        }
        /// <summary>
        /// Maps Property EF object to Property Model Object and
        /// returns the Property model object.
        /// </summary>
        /// <param name="result">EF Property object to be mapped.</param>
        /// <returns>Property Model Object.</returns>
        public Property MapEFToModel(EF.Models.Property data)
        {
            var propertyTypeName = string.Empty;

            if (data.PropertyId != 0)
            {

               
                if (data.PropertyType != null)
                {
                    propertyTypeName = data.PropertyType.Name;
                }
                

            }
            var property = new Property()
            {
                PropertyId = data.PropertyId,
                Location = data.Location,
                Description = data.Description,
                PropertyFee = data.PropertyFee,
                PropertyTypeId = data.PropertyTypeId,
                MediaFolderId = data.MediaFolderId,
                CreatedOn = data.CreatedOn,
                Timestamp = data.Timestamp,
                CreatedBy = _userService.GetUserFullName(data.AspNetUser),
                UpdatedBy = _userService.GetUserFullName(data.AspNetUser1),
                PropertyTypeName = propertyTypeName,

            };
            return property;
        }



       #endregion
    }
}
