using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sakuri.Data;
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
        public ApplicationUser ?User {get; private set;}
        
        public AccountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Items> GetAllItems(string userName)
        {
            return _context.Items.Where(c => c.UserName == userName).ToList();
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
