using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMW.DTO
{
   public class WebQueryDTO
    {
        public long WebQueryId { get; set; }
        public string Body { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime Timestamp { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool Deleted { get; set; }
        public string DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedOn { get; set; }
    }
}
