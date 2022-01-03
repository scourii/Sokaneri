using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sakuri.Data;
using System.Linq;
using System;

namespace Sakuri.Services
{
    public class AccountService 
    {
        protected SakuriContext _context;
        public User User {get; private set;}
        
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
        public Users EditInfo(long UserId)
        {
            User user = new User();
            return _context.Users.FirstOrDefault(u =>u.userid == UserId);
        }
        public bool UpdateInfo(User user)
        {
            var userUpdate = _context.Users.FirstOrDefault(u=>u.userid == user.userid);
            if (userUpdate != null)
            {
                userUpdate.password = user.password;
                _context.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }
        public bool DeleteInfo(User userDelete)
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
