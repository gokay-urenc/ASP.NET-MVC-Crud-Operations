using MVC_10_CRUD_Islemlerı.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_10_CRUD_Islemlerı.Controllers
{
    public class ProductController : Controller
    {
        NORTHWND db = new NORTHWND();
        public ActionResult Index() // Ürünleri listelemek için kullanılacak.
        {
            return View(db.Products.ToList());
        }

        // [HttpGet] // Yazılmasa bile her actionun başında vardır.
        public ActionResult Ekle() // Ekle sayfasını göstermek için kullanılacak.
        {
            // Yeni ürün ekleme sırasında veritabanında kategoriler gösterilmeli seçimi yapılmalıdır.
            List<Category> katList = db.Categories.ToList();
            return View(katList);
        }

        [HttpPost] // Sadece post olduğunda.
        public ActionResult Ekle(Product yeniUrun)
        {
            db.Products.Add(yeniUrun);
            db.SaveChanges();
            // return RedirectToAction("Index", "Product");
            return Redirect("/Product/Index"); // RedirectToAction methodu ile Redirect arasındaki tek fark budur.
        }

        public ActionResult Duzenle(int id)
        {
            // Product duzenlenecekUrun = db.Products.Where(x => x.ProductID == id).FirstOrDefault();
            // Ya da Find methodu ile yapabiliriz. Find methodu aldığı parametreyi ilgili tablonun primary key kolononda arar.
            Product duzenlenecekUrun = db.Products.Find(id);
            ProductViewModel vm = new ProductViewModel();
            vm.Urun = duzenlenecekUrun;
            vm.KatListesi = db.Categories.ToList();
            return View(vm);
        }
        
        [HttpPost]
        public ActionResult Duzenle(Product model)
        {
            Product orjinalUrun = db.Products.Find(model.ProductID); // Eski halini bulduk.
            orjinalUrun.CategoryID = model.CategoryID;
            orjinalUrun.ProductName = model.ProductName;
            orjinalUrun.UnitPrice = model.UnitPrice;
            orjinalUrun.UnitsInStock = model.UnitsInStock;
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

        public ActionResult Sil(int id)
        {
            Product silinecekUrun = db.Products.Find(id);
            db.SaveChanges();
            return Redirect("/Product/Index");
        }
    }
}