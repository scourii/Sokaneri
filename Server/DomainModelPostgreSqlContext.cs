using Sakuri.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Sakuri.Server
{
    public class DataAccessPostgreSqlProvider
    {
        private readonly ILogger _logger;
        private readonly DomainModelPostgreSqlContext _context;

        public DataAccessPostgreSqlProvider(ILoggerFactory loggerFactory,  DomainModelPostgreSqlContext context)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("DataAccessPostgreSqlProvider");
        }
        public void AddUser(User user)
        {
            _context.users.Add(user);
            _context.SaveChanges();
        }
        public void UpdateUser(User user)
        {
            _context.users.Update(user);
            _context.SaveChanges();
        }
        public void DeleteUser(string id)
        {
            var entity = _context.users.First(t => t.Id == id);
            _context.users.Remove(entity);
            _context.SaveChanges();
        }
        public User GetUserRecord(string id)
        {
            return _context.users.First(t => t.Id == id);
        }
        public List<User> GetAllUsers()
        {
            return _context.users.ToList();
        }
    }
}
