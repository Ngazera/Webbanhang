using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace BaoCaoWeb.Models
{
    public class ShopDbContext:DbContext
    {
        public ShopDbContext(): base()
        {

        }
    }
}