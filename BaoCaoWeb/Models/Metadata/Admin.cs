using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaoCaoWeb.Models
{
    [MetadataTypeAttribute(typeof(AdminMetadata))]
    public partial class Admin
    {
        internal sealed class AdminMetadata
        {
            public int adminId { get; set; }
            public string adminName { get; set; }
            public string adminEmail { get; set; }
            public string adminUser { get; set; }
            public string adminPass { get; set; }
        }
    }
}
   