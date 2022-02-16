using Microsoft.AspNetCore.Components;
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
        protected SakuriContext _context;
        public ApplicationUser User {get; private set;}
        
        public AccountService(SakuriContext context)
        {
            _context = context;
        }

        public List<Users> GetAllUsers()
        {
            return _context.Users.ToList();
        }
        public bool InsertInfo(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }
        public bool AddItem(Items item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return true;
        }
        
        public bool DeleteInfo(ApplicationUser userDelete)
        {
            var deleteUser = _context.Users.FirstOrDefault(u=>u.userid == userDelete.userid);
            if (deleteUser != null)
            {
                _context.Remove(deleteUser);
                _context.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }   
    }
}


