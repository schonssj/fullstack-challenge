using CsvHelper;
using System.Globalization;
using TakeHomeTest.API.Models;

namespace TakeHomeTest.API.Repositories
{
    public class LegislatorRepository
    {
        private readonly IConfiguration _configuration;

        public LegislatorRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IEnumerable<Legislator> GetLegislatorsFromCSV()
        {
            var path = _configuration.GetValue<string>("Settings:PathToLegislatorsCSV");
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<Legislator>()
                          .ToList();
            }
        }

        public Legislator? GetById(int id)
        {
            return GetLegislatorsFromCSV().FirstOrDefault(l => l.Id.Equals(id));
        }

        public IEnumerable<Legislator> GetAll()
        {
            return GetLegislatorsFromCSV();
        }
    }
}