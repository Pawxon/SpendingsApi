﻿using Microsoft.EntityFrameworkCore;
using SpendingsApi.Data;
using SpendingsApi.IServices;
using SpendingsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendingsApi.Services
{
    public class SpendingsService : ISpendingsService

    {
        ApplicationDbContext dbContext;
        public SpendingsService(ApplicationDbContext _db)
        {
            dbContext = _db;
        }  

        public async Task<string> AddSpendings(Spendings spendings)
        {
            dbContext.Spendings.Add(spendings);
            await dbContext.SaveChangesAsync();

            return await Task.FromResult("");
           
        }

        public async Task<string> DeleteSpendings(int id)
        {

            var car = dbContext.Spendings.FirstOrDefault(x => x.idSpendings == id);
            dbContext.Entry(car).State = EntityState.Deleted;

            dbContext.SaveChanges();
            return await Task.FromResult("");
        }

        public async Task<Spendings> GetSpendingsByIdAsync(int id)
        {
            var spendings = await dbContext.Spendings.FindAsync(id);

            if (spendings == null)
            {

            }

            return spendings;
        }

        public async Task<IEnumerable<Spendings>> GetSpendings()
        {
            return await dbContext.Spendings.ToListAsync();
        }  

        public Spendings UpdateSpendings(Spendings spendings)
        {
            dbContext.Entry(spendings).State = EntityState.Modified;
            dbContext.SaveChanges();
            return spendings;
        }

       

    }
}
