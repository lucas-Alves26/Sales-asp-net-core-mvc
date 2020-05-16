using Microsoft.EntityFrameworkCore;
using SalesWeb.Asp.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWeb.Asp.NET.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebAspNETContext _context;

        public SalesRecordService(SalesWebAspNETContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return await result
                //faz o join entre as tabelas
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                //Ordena por data
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }


        public async Task<List<IGrouping<Department,SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
              
            return await result
                //faz o join entre as tabelas
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                //Ordena por data
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Seller.Department)
                .ToListAsync();
        }

    }
}