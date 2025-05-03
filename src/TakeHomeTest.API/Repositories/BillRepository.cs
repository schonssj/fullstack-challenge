using CsvHelper;
using System.Globalization;
using TakeHomeTest.API.Models;

namespace TakeHomeTest.API.Repositories
{
    public class BillRepository
    {
        private readonly IConfiguration _configuration;

        public BillRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IEnumerable<Bill> GetBillsFromCSV()
        {
            var path = _configuration.GetValue<string>("Settings:PathToBillsCSV");
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<Bill>()
                          .ToList();
            }
        }

        public IEnumerable<Bill> GetAll()
        {
            return GetBillsFromCSV();
        }
    }
}