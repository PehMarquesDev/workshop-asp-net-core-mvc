using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        //Dependência necessária
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public Seller FindById(int id)
        {
            //Eager loading, ele carrega outros objetos que estejam associados ao objeto principal
            //Necessário incluir os objetos que devem ser inclusos
            return _context.Seller.Include(d => d.Department).FirstOrDefault(s => s.Id == id);
        }

        public void Remove(int id)
        {
            var seller = _context.Seller.Find(id);
            _context.Seller.Remove(seller);
            _context.SaveChanges();
        }

        public bool Insert(Seller seller)
        {
            try
            {
                _context.Add(seller);
                var a = _context.SaveChanges();
                if (a > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Update(Seller seller)
        {
            if (!_context.Seller.Any(x => x.Id == seller.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(seller);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
            
        }
    }
}
