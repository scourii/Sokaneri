using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sakuri;
using Sakuri.Models;
using System.Linq;
using System;
using Sakuri.Areas.Identity.Data;
namespace Sakuri.Services
{
    public class AccountService 
    {
        protected ApplicationDbContext _context;
        private DateOnly CurrentDate = DateOnly.FromDateTime(DateTime.Today);
        
        public AccountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Items> GetAllItems(string userName)
        {
            return _context.Items.Where(c => c.UserName == userName).ToList();
        }
        public List<Items> GetYearlyItems(string userName)
        {
            return _context.Items.Where(c => c.UserName == userName).Where(c => c.Time.Year == CurrentDate.Year).ToList();
        }
        public List<Items> GetMonthlyItems(string userName)
        {
            return _context.Items.Where(c => c.UserName == userName).Where(c => c.Time.Month == CurrentDate.Month).ToList();
        }


        public bool InsertItem(Items items)
        {
            var Item = new Items
            {
                ItemName = items.ItemName,
                ItemCategory = items.ItemCategory,
                ItemPrice = items.ItemPrice,
                Time = items.Time,
                UserName = items.UserName
            };
            _context.Items.Add(items);
            _context.SaveChanges();
            return true;
        }
           
    }
}
