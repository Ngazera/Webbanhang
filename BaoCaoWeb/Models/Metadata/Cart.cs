using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaoCaoWeb.Models
{
    [MetadataTypeAttribute(typeof(CartMetadata))]
    public partial class Cart {
        [DisplayName("Thành tiền")]
        public double money
        {
            get
            {
                return (Double)quantity * int.Parse(price);
            }
        }
       


        internal sealed class CartMetadata
        {
            public int cartId { get; set; }

            public Nullable<int> productId { get; set; }
            [DisplayName("Tên Sản Phẩm")]
            public string productName { get; set; }

            [DisplayName("Giá")]
            [DisplayFormat (DataFormatString = "{0:N}") ]
            public string price { get; set; }

            [DisplayName("Số lượng")]
            public Nullable<int> quantity { get; set; }
            [DisplayName("Hình ảnh")]
            public string image { get; set; }
           
           

        }
    }
}