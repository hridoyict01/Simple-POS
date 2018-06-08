using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Pos.Models;

namespace Pos.Controllers.Api
{
    public class SuppliersController : ApiController
    {
        private ApplicationDbContext _context;

        public SuppliersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET/api/suppliers
        public IEnumerable<Supplier> GetSuppliers()
        {
            return _context.Suppliers.ToList();
        }

        //GET/api/suppliers/5
        public Supplier GetSupplier(int id)
        {
            var supplier = _context.Suppliers.SingleOrDefault(s => s.Id == id);

            if (supplier == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return supplier;
        }

        //POST/api/suppliers
        [HttpPost]
        public Supplier CreateSupplier(Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            return supplier;
        }

        //PUT/api/suppliers
        [HttpPut]
        public void UpdateSupplier(int id, Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var supplierInDb = _context.Suppliers.SingleOrDefault(s => s.Id == id);
            if (supplierInDb == null)
            {
                throw  new HttpResponseException(HttpStatusCode.NotFound);
            }




            _context.SaveChanges();

        }

        //DELETE/api/supplier
        [HttpDelete]
        public void DeleteSupplier(int id)
        {
            var supplierInDb = _context.Suppliers.SingleOrDefault(s => s.Id == id);

            if (supplierInDb == null)
            {
                throw  new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Suppliers.Remove(supplierInDb);
            _context.SaveChanges();
        }
    }
}
