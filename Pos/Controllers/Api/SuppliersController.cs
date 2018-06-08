using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Pos.Dtos;
using Pos.Models;
using AutoMapper;


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
        public IHttpActionResult GetSuppliers()
        {
            return Ok(_context.Suppliers.ToList().Select(Mapper.Map<Supplier, SupplierDto>));
        }

        //GET/api/suppliers/5
        public IHttpActionResult GetSupplier(int id)
        {
            var supplier = _context.Suppliers.SingleOrDefault(s => s.Id == id);

            if (supplier == null)
            {
                return NotFound();
            }

            return Ok( Mapper.Map<Supplier,SupplierDto>(supplier) );
        }

        //POST/api/suppliers
        [HttpPost]
        public IHttpActionResult CreateSupplier(SupplierDto supplierDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var supplier = Mapper.Map<SupplierDto, Supplier>(supplierDto);

            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            supplierDto.Id = supplier.Id;
            return Created(new Uri(Request.RequestUri+ "/" + supplier.Id),supplierDto );
        }

        //PUT/api/suppliers
        [HttpPut]
        public IHttpActionResult UpdateSupplier(int id, SupplierDto supplierDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var supplierInDb = _context.Suppliers.SingleOrDefault(s => s.Id == id);
            if (supplierInDb == null)
            {
                return NotFound();
            }

            Mapper.Map<SupplierDto, Supplier>(supplierDto, supplierInDb);
            _context.SaveChanges();
            return Ok();
        }

        //DELETE/api/supplierDto
        [HttpDelete]
        public IHttpActionResult DeleteSupplier(int id)
        {
            var supplierInDb = _context.Suppliers.SingleOrDefault(s => s.Id == id);

            if (supplierInDb == null)
            {
                return NotFound();
            }

            _context.Suppliers.Remove(supplierInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}


