using SalesWeb.Asp.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWeb.Asp.NET.Services
{
    public class SellerService
    {
        private readonly SalesWebAspNETContext _context;

        public SellerService(SalesWebAspNETContext context)
        {
            _context = context;
        }

        //Retorna uma lista de vendedores
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        //retorna o vendedor com pelo id dele.
        public Seller FindById(int id)
        {
            return _context.Seller.FirstOrDefault(obj => obj.Id == id);
        }

        //remove o vendedor
        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
    }
}
