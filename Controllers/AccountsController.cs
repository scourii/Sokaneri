using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.EntityFrameworkCore;

namespace Sakuri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AccountsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
        
}