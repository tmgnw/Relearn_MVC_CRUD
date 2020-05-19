using Relearn_MVC_CRUD.Context;
using Relearn_MVC_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Relearn_MVC_CRUD.Controllers
{
    public class ItemsController : Controller
    {
        MyContext conn = new MyContext();

        // GET: Items
        public ActionResult Index()
        {
            return View(conn.Items.Include(s => s.Supplier).ToList());
        }

        // GET: Item/Details
        public ActionResult Details(int id)
        {
            return View(conn.Items.Where(x => x.Id == id).FirstOrDefault());
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            PopulateSuppliersDropDownList();
            return View();
        }

        public void PopulateSuppliersDropDownList(object selectedSupplier = null)
        {
            var supplierQuery = from s in conn.Suppliers
                                orderby s.Name
                                select s;
            ViewBag.Id = new SelectList(supplierQuery, "Id", "Name", selectedSupplier);
        }

        // POST: Item/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Price,Stock,SupplierID")] Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    conn.Items.Add(item);
                    conn.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            PopulateSuppliersDropDownList();

            return View(item);
        }

        // GET: Item/Edit
        public ActionResult Edit(int id)
        {
            PopulateSuppliersDropDownList();
            return View(conn.Items.Where(X => X.Id == id).FirstOrDefault());
        }

        // POST: Item/Edit
        [HttpPost]
        public ActionResult Edit(int id, Item item)
        {
            try
            {
                // TODO: Add update logic here
                conn.Entry(item).State = EntityState.Modified;
                conn.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Delete
        public ActionResult Delete(int id)
        {
            return View(conn.Items.Where(x => x.Id == id).FirstOrDefault());
        }

        // POST: Item/Delete
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Item item = conn.Items.Where(x => x.Id == id).FirstOrDefault();
                conn.Items.Remove(item);
                conn.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ModalCreate()
        {
            //myContext conn = new myContext();
            return View();
        }

        // POST: Supplier/Delete
        [HttpPost]
        public ActionResult ModalCreate(Item item)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}