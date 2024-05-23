using InventoryManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagmentSystem.Controllers
{


	public class SaleController : Controller
    {
		// GET: Sale	INVENTORY_MANEntities db = new INVENTORY_MANEntities();
		INVENTORY_MANEntities db = new INVENTORY_MANEntities();


		public ActionResult Index()
        {
            return View();
        }
		[HttpGet]
		public ActionResult DisplaySale()
		{
			List<Sale> list = db.Sales.OrderByDescending(x => x.id).ToList();
			return View(list);
		}
		[HttpGet]
		public ActionResult SaleProduct()
		{
			List<string> list = db.Products.Select(x => x.Product_name).ToList();
			ViewBag.ProductName = new SelectList(list);
			return View();
		}
		[HttpPost]
		public ActionResult SaleProduct(Sale S)

		{
			db.Sales.Add(S);
			db.SaveChanges();
			return RedirectToAction("DisplaySale");
		}

	}
}
