using MvcStocks.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStocks.Controllers
{
    public class CategoryController : Controller
    {
        StocksEntities ent = new StocksEntities();

        public ActionResult Index()
        {
            List<Categories> list = ent.Categories.ToList();
            return View(list);
        }

        public ActionResult Edit(int ID)
        {
            var degisen = (from kategori in ent.Categories
                           where kategori.id == ID
                           select kategori).First();
            return View(degisen);
        }
        [HttpPost]
        public ActionResult Edit(Categories model)
        {
            var degisen = (from kategori in ent.Categories
                           where kategori.id == model.id
                           select kategori).First();
            degisen.name = model.name;
            degisen.description = model.description;
            ent.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int ID)
        {
            var silinecek = (from kategori in ent.Categories
                           where kategori.id == ID
                           select kategori).First();
            //return View(silinecek);
            ent.Categories.Remove(silinecek);
            ent.SaveChanges();
            return RedirectToAction("Index");
        }
        //[HttpPost]
        //public ActionResult Delete(Categories model)
        //{
        //    var silinen = (from kategori in ent.Categories
        //                   where kategori.id == model.id
        //                   select kategori).First();
        //    ent.Categories.Remove(silinen);
        //    ent.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Categories model)
        {
            Categories c = new Categories();
            c.name = model.name;
            c.description = model.description;
            ent.Categories.Add(c);
            ent.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
