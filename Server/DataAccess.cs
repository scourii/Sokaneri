using Sakuri.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Sakuri.Server
{
    public class DataAccess : IDataAccessProvider
    {
        private readonly DomainModelPostgreSqlContext _context;

    }
}
