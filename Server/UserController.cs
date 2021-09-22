using Sakuri.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace Sakuri.Server
{
    public class UserController : Controller
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public UserController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        [Route("/api/users/Get")]
        public IEnumerable<User> Get()
        {
            return _dataAccessProvider.GetAllUsers();
        }
        [HttpPost]
        [Route("/api/users/Create")]
        public void Create([FromBody] User user)
        {
            if(ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                user.Id = obj.ToString();
                _dataAccessProvider.AddUser(user);
            }
        }
        [HttpGet]
        [Route("/api/users/Details/{id}")]
        public User Details(string id)
        {
            return _dataAccessProvider.GetUserRecord(id);
        }
        [HttpPut]
        [Route("/api/users/Edit")]
        public void Edit([FromBody] User user)
        {
            if(ModelState.IsValid)
            {
                _dataAccessProvider.UpdateUser(user);
            }
        }
        [HttpDelete]
        [Route("/api/users/Delete/{id}")]
        public void DeleteUser(string id)
        {
            _dataAccessProvider.DeleteUser(id);
        }
    }
}
