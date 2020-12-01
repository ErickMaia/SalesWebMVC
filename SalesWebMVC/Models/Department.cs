﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        {
        }

        public Department(int iD, string name)
        {
            ID = iD;
            Name = name;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initialDate, DateTime finalDate)
        {
            return (from s in Sellers select s.TotalSales(initialDate, finalDate)).DefaultIfEmpty().Sum();
        }

    }
}
