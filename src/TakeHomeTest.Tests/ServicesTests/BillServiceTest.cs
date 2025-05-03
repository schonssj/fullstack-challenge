using Microsoft.Extensions.Configuration;
using TakeHomeTest.API.Repositories;
using TakeHomeTest.API.Services;

namespace TakeHomeTest.Tests.ServicesTests
{
    [TestClass]
    public class BillServiceTest
    {
        private BillService _billService;
        private BillRepository _billRepository;
        private LegislatorRepository _legislatorRepository;
        private VoteRepository _voteRepository;
        private VoteResultRepository _voteResultRepository;

        [TestInitialize]
        public void Initialize()
        {
            var appSettingsValues = new Dictionary<string, string>
            {
                {"Settings:PathToBillsCSV", "C:\\fullstack-challenge\\src\\TakeHomeTest\\Data\\bills.csv"},
                {"Settings:PathToLegislatorsCSV", "C:\\fullstack-challenge\\src\\TakeHomeTest\\Data\\legislators.csv"},
                {"Settings:PathToVotesCSV", "C:\\fullstack-challenge\\src\\TakeHomeTest\\Data\\votes.csv"},
                {"Settings:PathToVoteResultsCSV", "C:\\fullstack-challenge\\src\\TakeHomeTest\\Data\\vote_results.csv"},
            };

            var configuration = new ConfigurationBuilder().AddInMemoryCollection(appSettingsValues).Build();

            _billRepository = new BillRepository(configuration);
            _legislatorRepository = new LegislatorRepository(configuration);
            _voteRepository = new VoteRepository(configuration);
            _voteResultRepository = new VoteResultRepository(configuration);
            _billService = new BillService(_billRepository, _legislatorRepository, _voteRepository, _voteResultRepository);
        }

        [TestMethod]
        public void GetBillsResults_ReturnsData()
        {
            var result = _billService.GetBillsResults();
            Assert.IsNotNull(result);
        }
    }
}