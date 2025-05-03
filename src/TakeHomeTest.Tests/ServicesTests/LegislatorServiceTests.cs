using Microsoft.Extensions.Configuration;
using TakeHomeTest.API.Repositories;
using TakeHomeTest.API.Services;

namespace TakeHomeTest.Tests.ServicesTests
{
    [TestClass]
    public class LegislatorServiceTests
    {
        private LegislatorService _legislatorService;
        private LegislatorRepository _legislatorRepository;
        private VoteResultRepository _voteResultRepository;

        [TestInitialize]
        public void Initialize()
        {
            var appSettingsValues = new Dictionary<string, string>
            {
                {"Settings:PathToBillsCSV", "C:\\fullstack-challenge\\TakeHomeTest\\Data\\bills.csv"},
                {"Settings:PathToLegislatorsCSV", "C:\\fullstack-challenge\\TakeHomeTest\\Data\\legislators.csv"},
                {"Settings:PathToVotesCSV", "C:\\fullstack-challenge\\TakeHomeTest\\Data\\votes.csv"},
                {"Settings:PathToVoteResultsCSV", "C:\\fullstack-challenge\\TakeHomeTest\\Data\\vote_results.csv"},
            };

            var configuration = new ConfigurationBuilder().AddInMemoryCollection(appSettingsValues).Build();

            _legislatorRepository = new LegislatorRepository(configuration);
            _voteResultRepository = new VoteResultRepository(configuration);
            _legislatorService = new LegislatorService(_legislatorRepository, _voteResultRepository);
        }

        [TestMethod]
        public void GetLegislatorsVotes_ReturnsData()
        {
            var result = _legislatorService.GetLegislatorsVotes();
            Assert.IsNotNull(result);
        }
    }
}