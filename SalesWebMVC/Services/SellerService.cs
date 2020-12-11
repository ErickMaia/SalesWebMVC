using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMVC.Services
{
    public class SellerService
    {
        private readonly SalesWebMVCContext _context; 

        public SellerService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Seller.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(x => x.Department).SingleOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            //A IMPLEMENTAÇÃO COMENTADA ABAIXO FOI FEITA PELO PROFESSOR NA AULA: 
            //var obj = _context.Seller.Find(id);
            //_context.Seller.Remove(obj);
            //_context.SaveChanges();

            //A IMPLEMENTAÇÃO ABAIXO FOI FEITA POR MIM
            //@ErickMaia
            _context.Seller.Remove(FindById(id));
            _context.SaveChanges();
        }

    }
}
