using CsvHelper;
using System.Globalization;
using TakeHomeTest.API.Models;

namespace TakeHomeTest.API.Repositories
{
    public class VoteResultRepository
    {
        private readonly IConfiguration _configuration;

        public VoteResultRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IEnumerable<VoteResult> GetVoteResultsFromCSV()
        {
            var path = _configuration.GetValue<string>("Settings:PathToVoteResultsCSV");
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<VoteResult>()
                          .ToList();
            }
        }

        public IEnumerable<VoteResult> GetByVoteId(int voteId)
        {
            return GetVoteResultsFromCSV().Where(v => v.VoteId.Equals(voteId));
        }
        
        public IEnumerable<VoteResult> GetByLegislatorId(int legislatorId)
        {
            return GetVoteResultsFromCSV().Where(vr => vr.LegislatorId.Equals(legislatorId));
        }
    }
}