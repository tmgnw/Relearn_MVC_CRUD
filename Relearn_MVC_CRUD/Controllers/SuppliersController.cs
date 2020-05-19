using Relearn_MVC_CRUD.Context;
using Relearn_MVC_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Relearn_MVC_CRUD.Controllers
{
    public class SuppliersController : Controller
    {
        MyContext conn = new MyContext();

        // GET: Suppliers
        public ActionResult Index()
        {
            return View(conn.Suppliers.ToList());
        }

        // GET: Supplier/Details/
        public ActionResult Details(int id)
        {
            //myContext conn = new myContext();
            return View(conn.Suppliers.Where(x => x.Id == id).FirstOrDefault());
        }

        // GET: Supplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create
        [HttpPost]
        public ActionResult Create(Supplier supplier)
        {
            try
            {
                //myContext conn = new myContext();
                conn.Suppliers.Add(supplier);
                conn.SaveChanges();
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Supplier/Edit
        public ActionResult Edit(int id)
        {
            //myContext conn = new myContext();
            return View(conn.Suppliers.Where(x => x.Id == id).FirstOrDefault());
        }

        // POST: Supplier/Edit
        [HttpPost]
        public ActionResult Edit(int id, Supplier supplier)
        {
            try
            {
                //myContext conn = new myContext();
                conn.Entry(supplier).State = EntityState.Modified;
                conn.SaveChanges();
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Supplier/Delete
        public ActionResult Delete(int id)
        {
            //myContext conn = new myContext();
            return View(conn.Suppliers.Where(x => x.Id == id).FirstOrDefault());
        }

        // POST: Supplier/Delete
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                //myContext conn = new myContext();
                Supplier supplier = conn.Suppliers.Where(x => x.Id == id).FirstOrDefault();
                conn.Suppliers.Remove(supplier);
                conn.SaveChanges();
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}