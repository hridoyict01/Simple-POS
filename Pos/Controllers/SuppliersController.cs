using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pos.Models;

namespace Pos.Controllers
{
    public class SuppliersController : Controller
    {
        private ApplicationDbContext _context;

        public SuppliersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Suppliers
        public ActionResult Index()
        {

            var supplier = _context.Suppliers.ToList();
            return View(supplier);
        }

        // GET: Suppliers/Details/5
        public ActionResult Details(int id)
        {
            var supplier = _context.Suppliers.Single(s => s.Id == id);
            return View(supplier);
        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Supplier supplier )
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            else
            {
                _context.Suppliers.Add(supplier);
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Suppliers");
        }

        // GET: Suppliers/Edit/5
        public ActionResult Edit(int id)
        {
            var supplier = _context.Suppliers.Single(s => s.Id == id);
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier supplier)
        {
            var id = supplier.Id;
            var supplierInDb = _context.Suppliers.Single(s => s.Id == id);
            supplierInDb.Name = supplier.Name;
            supplierInDb.AccountPayable = supplier.AccountPayable;
            supplierInDb.Address = supplier.Address;
            supplierInDb.Email = supplier.Email;
            supplierInDb.IsManufacturer = supplier.IsManufacturer;
            supplierInDb.PhoneNumber = supplier.PhoneNumber;
            _context.SaveChanges();
            return RedirectToAction("Index", "Suppliers");
        }

        // GET: Suppliers/Delete/5
        public ActionResult Delete(int id)
        {
            var supplier = _context.Suppliers.Single(s => s.Id == id);
            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();
            return RedirectToAction("Index", "Suppliers");
        }

        // POST: Suppliers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
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
