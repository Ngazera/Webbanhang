using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaoCaoWeb.Models
{
    [MetadataTypeAttribute(typeof(CustomerMetadata))]
    public partial class Customer
    {
        internal sealed class CustomerMetadata
        {
            [DisplayName("ID")]
        //    [Required(ErrorMessage = "Yêu cầu nhập email")]
            public int customer_id { get; set; }
            [DisplayName("Họ Và Tên ")]
            [Required(ErrorMessage = "Yêu cầu nhập Họ Và Tên")]
            public string name { get; set; }
            [DisplayName("Địa Chỉ")]
            [Required(ErrorMessage = "Yêu cầu nhập Địa Chỉ")]
            public string address { get; set; }
            [DisplayName("Số Điện Thoại")]
            [Required(ErrorMessage = "Yêu cầu nhập Số Điện Thoại")]
            public string phone { get; set; }
            [DisplayName("Mật Khẩu")]
            [Required(ErrorMessage = "Yêu cầu nhập Mật Khẩu")]
            public string password { get; set; }

            [DisplayName("Email")]
            [Required (ErrorMessage ="Yêu cầu nhập email")]
            public string email { get; set; }
        }
    }
}