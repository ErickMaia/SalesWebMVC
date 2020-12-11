using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;
using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Data
{
    public class SeedingService
    {
        private SalesWebMVCContext _context;

        public SeedingService(SalesWebMVCContext Context)
        {
            this._context = Context;
        }

        public void Seed()
        {

            if (_context.Department.Any() ||
               _context.Seller.Any() ||
               _context.SalesRecord.Any())
            {
                return; //DB has been seeded
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Historical Weapons");

            Seller s1 = new Seller(1, "Antonio Conselheiro", "antonioconselheiro@hotmail.com", new DateTime(1830, 3, 13) , 1200.00, d2);
            Seller s2 = new Seller(2, "Bill Turing", "billturing@gmail.com", new DateTime(1997, 10, 29), 5000.00, d1);
            Seller s3 = new Seller(2, "Brian Boru", "brianboru@outlook.com", new DateTime(0941, 11, 11), 9500.00, d3);

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2020, 12, 1), 3600.00, SaleStatus.BILLED, s2);

            _context.Department.AddRange(d1, d2, d3);
            _context.Seller.AddRange(s1, s2, s3);
            _context.SalesRecord.AddRange(sr1);
            _context.SaveChanges();

        }
    }
}
