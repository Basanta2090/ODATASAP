using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TenaNetSAPTest.Models
{
    public class SAPModels
    {
        public class SAPModel
        {
            public int ID { get; set; }
            public string ModuleName { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime ModifiedOn { get; set; }
            public string ModifiedBy { get; set; }
        }
    }
}
