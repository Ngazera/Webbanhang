using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaoCaoWeb.Models
{
    [MetadataTypeAttribute(typeof(ProductMetadata))]
    public partial class Product
    {
        internal sealed class ProductMetadata {
            [DisplayName("ID")]
            public int productId { get; set; }
            [DisplayName("Tên Sản Phẩm")]
            public string productName { get; set; }
            [DisplayName("ID Loại Sản Phẩm")]
            public Nullable<int> catId { get; set; }
            [DisplayName("Giá")]
            public string price { get; set; }
            [DisplayName("Hình Ảnh")]
            public string image { get; set; }
            [DisplayName("Trạng Thái")]
            public Nullable<int> status { get; set; }
            [DisplayName("Số Lượng")]
            public Nullable<int> quantity { get; set; }
            [DisplayName("Mô tả")]
            public string description { get; set; }
            

        }
    }

}