﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMW.Models
{
  public  class Property
    {
        public long PropertyId { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public long PropertyTypeId { get; set; }
        public long MediaFolderId { get; set; }
        public double PropertyFee { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime Timestamp { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool Deleted { get; set; }
        public string DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedOn { get; set; }
        public string PropertyTypeName { get; set; }
    
        
    }
}
