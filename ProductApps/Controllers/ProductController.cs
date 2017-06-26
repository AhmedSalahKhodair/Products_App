using ProductApps.Context;
using ProductApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProductApps.Controllers
{
    public class ProductController : Controller
    {
        private ProductContext db = new ProductContext();
        // GET: Product
        public ActionResult Index(string Description, string searchText)
        {
            var descriptionList = new List<string>();

            var discriptionQuery = from g in db.products
                             orderby g.Description
                             select g.Description;

            descriptionList.AddRange(discriptionQuery.Distinct());

            ViewBag.Description = new SelectList(descriptionList);


            var products = from p in db.products
                          select p;

            if (!String.IsNullOrEmpty(searchText))
            {
                products = products.Where(s => s.ProductName.Contains(searchText));
            }

            if(!String.IsNullOrEmpty(Description))
            {
                products = products.Where(x => x.Description == Description);
            }

            return View(products);
        }

        public ActionResult _ProductSearch(string query)
        {
            var products = GetProducts(query);
            return PartialView(products);
        }

        private List<Product> GetProducts(string query)
        {
            return db.products
                .Where(b => b.ProductName.Contains(query))
                .ToList();
        }

        public ActionResult BargainProduct()
        {
            var product = GetBargainProduct();
            return PartialView("_BargainProduct", product);
        }

        private Product GetBargainProduct()
        {
            return db.products
                .OrderBy(b => b.Price)
                .First();
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Product product = db.products.Find(id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        // GET: Product/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product_object)
        {
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    db.products.Add(product_object);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Product product = db.products.Find(id);

            if (product == null)
                return HttpNotFound();


            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Product product = db.products.Find(id);
            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int ? id,Product prod)
        {
            try
            {
                // TODO: Add delete logic here

                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                Product product = db.products.Find(id);
                if (product == null)
                    return HttpNotFound();

                if (ModelState.IsValid)
                {
                    db.products.Remove(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch
            {
                return View();
            }
        }
    }
}
