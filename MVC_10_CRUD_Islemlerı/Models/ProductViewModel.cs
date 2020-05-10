using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_10_CRUD_Islemlerı.Models
{
    public class ProductViewModel
    {
        public List<Category> KatListesi { get; set; }
        public Product Urun { get; set; }
    }
}