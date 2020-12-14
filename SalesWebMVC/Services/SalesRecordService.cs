﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Data;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Models;

namespace SalesWebMVC.Services
{
    public class SalesRecordService
    {
        SalesWebMVCContext _context;

        public SalesRecordService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? initial, DateTime? final)
        {
            var result = from obj in _context.SalesRecord select obj;

            if (initial.HasValue)
            {
                result = result.Where(x => x.Date >= initial);
            }

            if (final.HasValue)
            {
                result = result.Where(x => x.Date <= final);
            }

            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();

        }

        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? initial, DateTime? final)
        {
            var result = from obj in _context.SalesRecord select obj;

            if (initial.HasValue)
            {
                result = result.Where(x => x.Date >= initial);
            }

            if (final.HasValue)
            {
                result = result.Where(x => x.Date <= final);
            }

            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Seller.Department)
                .ToListAsync();

        }
    }
}
