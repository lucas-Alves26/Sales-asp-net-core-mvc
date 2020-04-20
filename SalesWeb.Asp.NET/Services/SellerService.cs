﻿using SalesWeb.Asp.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWeb.Asp.NET.Services.Exceptions;

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
        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
              await _context.SaveChangesAsync();
        }

        //retorna o vendedor com pelo id dele.
        public async Task<Seller> FindByIdAsync(int id)
        {
            //Include(obj => obj.Department) expressão lambida para trazer o departamento junto
            return  await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        //remove o vendedor
        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException("Não pode deletar o vendedor porque ele/ela tem vendas!");
            }
    
        }

        //Atualizar dados do vendedor
        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await  _context.Seller.AnyAsync(x => x.Id == obj.Id);

            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
