using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sakuri.Data
{
    public class MoneyInformationService
    {
        private static readonly string[] Summaries = new[]
        {
            "Entertainment", "Bills", "Utilities", "Food", "Shopping", "Travel", "Electronics", "Healthcare", "Groceries", "Education"
        };

        public Task<MoneyInformation[]> GetMoneyAsync(DateTime startDate)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new MoneyInformation
            {
                Date = startDate.AddDays(index),
                Price = rng.Next(0, 400),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }
    }
}
