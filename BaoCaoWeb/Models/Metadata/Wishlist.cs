using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace BaoCaoWeb.Models
{
    [MetadataTypeAttribute(typeof(WishlistMetadata))]
    public partial class Wishlist
    {
        internal sealed class WishlistMetadata
        {
            public int id { get; set; }
            public Nullable<int> customer_id { get; set; }
            public Nullable<int> productId { get; set; }
            public string productName { get; set; }
            public string price { get; set; }
            public string image { get; set; }

        }
    }
  
    }