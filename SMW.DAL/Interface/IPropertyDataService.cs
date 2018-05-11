using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMW.DTO;
using SMW.EF.Models;

namespace SMW.DAL.Interface
{
   public interface IPropertyDataService
    {
        IEnumerable<Property> GetAllProperties();
        Property GetProperty(long propertyId);
        long SaveProperty(PropertyDTO property, string userId);
        void MarkAsDeleted(long propertyId, string userId);
    }
}
