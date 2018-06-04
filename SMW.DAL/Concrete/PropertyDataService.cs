using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMW.EF.Models;
using SMW.DAL.Concrete;
using SMW.DAL.Interface;
using SMW.EF.UnitOfWork;
using SMW.DTO;
using log4net;

namespace SMW.DAL.Concrete
{
  public  class PropertyDataService : DataServiceBase,IPropertyDataService
    {
      ILog logger = log4net.LogManager.GetLogger(typeof(PropertyDataService));

       public PropertyDataService(IUnitOfWork<SMWEntities> unitOfWork)
            : base(unitOfWork)
        {

        }

      
        public IEnumerable<Property> GetAllProperties()
        {
            return this.UnitOfWork.Get<Property>().AsQueryable().Where(e => e.Deleted == false); 
        }

        public IEnumerable<PropertyType> GetAllPropertyTypes()
        {
            return this.UnitOfWork.Get<PropertyType>().AsQueryable();
        }

        public IEnumerable<Property> GetAllPropertiesForAParticularPropertyType(long propertyTypeId)
        {
            return this.UnitOfWork.Get<Property>().AsQueryable().Where(e => e.Deleted == false && e.PropertyTypeId == propertyTypeId);
        }
        public Property GetProperty(long propertyId)
        {
            return this.UnitOfWork.Get<Property>().AsQueryable()
                 .FirstOrDefault(c =>
                    c.PropertyId == propertyId &&
                    c.Deleted == false
                );
        }

        /// <summary>
        /// Saves a new Property or updates an already existing Property.
        /// </summary>
        /// <param name="Property">Property to be saved or updated.</param>
        /// <param name="PropertyId">propertyId of the Property creating or updating</param>
        /// <returns>PropertyId</returns>
        public long SaveProperty(PropertyDTO propertyDTO, string userId)
        {
            long propertyId = 0;
            
            if (propertyDTO.PropertyId == 0)
            {
                long mediaFolderId = 0;

                var media = new Media
                {
                    MediaGuid = Guid.NewGuid(),
                    //ParentId = rootGalleryId,
                    Name = propertyDTO.Description,
                    MediaTypeId = (long)SMW.Library.EnumTypes.MediaType.Folder,
                    CreatedOn = DateTime.Now,
                    TimeStamp = DateTime.Now,
                    Deleted = false
                };

                this.UnitOfWork.Get<Media>().AddNew(media);
                this.UnitOfWork.SaveChanges();
                mediaFolderId = media.MediaId;
           
                var property = new Property()
                {
                   
                    PropertyTypeId = propertyDTO.PropertyTypeId,
                    MediaFolderId = mediaFolderId,
                    Location = propertyDTO.Location,
                    PropertyFee = propertyDTO.PropertyFee,
                    Description = propertyDTO.Description,
                    CreatedOn = DateTime.Now,
                    Timestamp = DateTime.Now,
                    CreatedBy = userId,
                    Deleted = false,
 

                };

                this.UnitOfWork.Get<Property>().AddNew(property);
                this.UnitOfWork.SaveChanges();
                propertyId = property.PropertyId;
                return propertyId;
            }

            else
            {
                var result = this.UnitOfWork.Get<Property>().AsQueryable()
                    .FirstOrDefault(e => e.PropertyId == propertyDTO.PropertyId);
                if (result != null)
                {
                    result.PropertyTypeId = propertyDTO.PropertyTypeId; 
                    result.Location = propertyDTO.Location;
                    result.PropertyFee = propertyDTO.PropertyFee;
                    result.Description = propertyDTO.Description;
                    result.Timestamp = DateTime.Now;
                    result.MediaFolderId = propertyDTO.MediaFolderId;
                    result.Deleted = propertyDTO.Deleted;
                    result.DeletedBy = propertyDTO.DeletedBy;
                    result.DeletedOn = propertyDTO.DeletedOn;
                    result.UpdatedBy = userId;
                    result.CreatedBy = propertyDTO.CreatedBy;
 
                    this.UnitOfWork.Get<Property>().Update(result);
                    this.UnitOfWork.SaveChanges();
                }
                return propertyDTO.PropertyId;
            }
            return propertyId;
        }

        public void MarkAsDeleted(long propertyId,string userId)
        {
            var result = this.UnitOfWork.Get<Property>().AsQueryable().Where(e => e.Deleted == false && e.PropertyId == propertyId);
            if (result != null)
            {

                using (var dbContext = new SMWEntities())
                {
                    dbContext.Mark_Property_And_Related_DataAs_Deleted(propertyId, userId);
                }
            }
        }
    }
}
