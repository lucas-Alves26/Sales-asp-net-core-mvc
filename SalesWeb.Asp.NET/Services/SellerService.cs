using SalesWeb.Asp.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWeb.Asp.NET.Services
{
    public class SellerService
    {
        private readonly SalesWebAspNETContext _Context;

        public SellerService(SalesWebAspNETContext context)
        {
            _Context = context;
        }

        //Retorna uma lista de vendedores
        public List<Seller> FindAll()
        {
            return _Context.Seller.ToList();
        }
    }
}
