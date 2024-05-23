using InventoryManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagmentSystem.Controllers
{
    public class PurchaseController : Controller
    {
		INVENTORY_MANEntities db = new INVENTORY_MANEntities();

		// GET: Purchase
		public ActionResult Index()
        {
            return View();
        }
		[HttpGet]
		public ActionResult DisplayPurchase()
		{
			List<Purchase>list = db.Purchases.OrderByDescending(x=> x.id).ToList();
			return View(list);
		}
		[HttpGet]
		public ActionResult PurchaseProduct()
		{
			List<string> list = db.Products.Select(x => x.Product_name).ToList();
			ViewBag.ProductName =new SelectList(list);
			return View();
		}
		[HttpPost]
		public ActionResult PurchaseProduct(Purchase pur) 

		{
			db.Purchases.Add(pur);
			db.SaveChanges();
			return RedirectToAction("DisplayPurchase");
		}

	}
}