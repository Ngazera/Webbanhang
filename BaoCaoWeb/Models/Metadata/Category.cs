using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaoCaoWeb.Models
{
    [MetadataTypeAttribute(typeof(CategoryMetadata))]
    public partial class Category
    {
        internal sealed class CategoryMetadata
        {
            [DisplayName("ID")]
            public int catId { get; set; }
            [DisplayName("Tên Danh Mục")]
            public string catName { get; set; }
        }
    }
}