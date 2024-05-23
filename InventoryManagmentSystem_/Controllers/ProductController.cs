using InventoryManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagmentSystem.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        INVENTORY_MANEntities db = new INVENTORY_MANEntities(); 
        public ActionResult Index()
        {
            return View();
        }

		[HttpGet]
		public ActionResult Displayaparoduct()
		{
			List < Product > list = db.Products.OrderByDescending(x => x.id).ToList();
			return View(list);
		}

		[HttpGet]
		public ActionResult CreateProduct()
		{
			return View();
		}

		[HttpPost]
		public ActionResult CreateProduct( Product pro)
		{
			  db.Products.Add(pro);
			  db.SaveChanges();
			  return RedirectToAction("Displayaparoduct");
		}
		[HttpGet]
		public ActionResult UpdateProduct(int id)
		{
			Product pr = db.Products.Where(x=>x.id ==id).SingleOrDefault();
			return View(pr);
		}
		[HttpPost]
		public ActionResult UpdateProduct(int id , Product pro)
		{
			Product pr = db.Products.Where(x => x.id == id).SingleOrDefault();
			pr.Product_name= pro.Product_name;
			pr.Product_qnty= pro.Product_qnty;
			db.SaveChanges();
			return RedirectToAction("Displayaparoduct");
		}
		[HttpGet]
		public ActionResult ProductDetail(int id)
		{
			Product pro = db.Products.Where(x => x.id == id).SingleOrDefault();
			
			return View(pro);
		}
		[HttpGet]
		public ActionResult DeleteProduct(int id)
		{
			Product pro = db.Products.Where(x => x.id == id).SingleOrDefault();

			return View(pro);
		}
		[HttpPost]

		public ActionResult DeleteProduct( int id ,Product pro)
		{
			Product p = db.Products.Where(x => x.id == id).SingleOrDefault();


			db.Products.Remove(db.Products.Where(x => x.id == id).SingleOrDefault());
			db.SaveChanges();
			return View("Displayaparoduct");
		}
	}
}