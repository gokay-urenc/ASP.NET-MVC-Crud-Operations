using MVC_10_CRUD_Islemlerı.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_10_CRUD_Islemlerı.Controllers
{
    public class HomeController : Controller
    {
        NORTHWND db = new NORTHWND();
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        public ActionResult KategoriUrunleri(int id)
        {
            List<Product> katUrunlerim = db.Products.Where(x => x.CategoryID == id).ToList();
            return View(katUrunlerim);
        }
    }
}