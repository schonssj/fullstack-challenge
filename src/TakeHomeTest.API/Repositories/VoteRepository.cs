using CsvHelper;
using System.Globalization;
using TakeHomeTest.API.Models;

namespace TakeHomeTest.API.Repositories
{
    public class VoteRepository
    {
        private readonly IConfiguration _configuration;

        public VoteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        private IEnumerable<Vote> GetVotesFromCSV()
        {
            var path = _configuration.GetValue<string>("Settings:PathToVotesCSV");
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<Vote>()
                          .ToList();
            }
        }

        public Vote? GetByBillId(int billId)
        {
            return GetVotesFromCSV().FirstOrDefault(v => v.BillId.Equals(billId));
        }
    }
}