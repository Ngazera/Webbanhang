using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaoCaoWeb.Models
{
    [MetadataTypeAttribute(typeof(OrderMetadata))]
    public partial class Order
    {
        internal sealed class OrderMetadata
        {
            [DisplayName("ID")]
            public int id { get; set; }
            [DisplayName("ID Sản Phẩm")]
            public Nullable<int> productId { get; set; }
            [DisplayName("Tên Sản Phẩm")]
            public string productName { get; set; }
            [DisplayName("ID Khách Hàng")]
            public Nullable<int> customer_id { get; set; }
            [DisplayName("Số lượng")]
            public Nullable<int> quantity { get; set; }
            [DisplayName("Giá")]
            public string price { get; set; }
            [DisplayName("Ảnh")]
            public string image { get; set; }
            [DisplayName("Ngày mua")]
            public Nullable<System.DateTime> date_order { get; set; }
            [DisplayName("Trạng thái")]
            public Nullable<int> status { get; set; }
            [DisplayName("Tổng Tiền")]
            public string total { get; set; }
        }
    }
}