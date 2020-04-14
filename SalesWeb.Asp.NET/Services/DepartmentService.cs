using SalesWeb.Asp.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWeb.Asp.NET.Services
{
    public class DepartmentService
    {
        private readonly SalesWebAspNETContext _context;

        public DepartmentService(SalesWebAspNETContext context)
        {
            _context = context;
        }

        //Retorna lista de departamentos
        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
