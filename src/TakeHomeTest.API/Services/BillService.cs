using TakeHomeTest.API.DTO;
using TakeHomeTest.API.Models;
using TakeHomeTest.API.Repositories;

namespace TakeHomeTest.API.Services
{
    public class BillService
    {
        private readonly BillRepository _billRepository;
        private readonly LegislatorRepository _legislatorRepository;
        private readonly VoteRepository _voteRepository;
        private readonly VoteResultRepository _voteResultRepository;

        public BillService(BillRepository billRepository, LegislatorRepository legislatorRepository, VoteRepository voteRepository, VoteResultRepository voteResultRepository)
        {
            _billRepository = billRepository;
            _legislatorRepository = legislatorRepository;
            _voteRepository = voteRepository;
            _voteResultRepository = voteResultRepository;
        }

        public IEnumerable<BillResultsDTO> GetBillsResults()
        {
            var bills = _billRepository.GetAll();
            foreach (var bill in bills)
            {
                var primarySponsor = _legislatorRepository.GetById(bill.PrimarySponsor);
                var vote = _voteRepository.GetByBillId(bill.Id);
                var voteResults = _voteResultRepository.GetByVoteId(vote.Id);

                yield return new BillResultsDTO
                (
                    bill.Id,
                    bill.Title,
                    voteResults.Where(vr => vr.VoteType.Equals(VoteType.YEA)).Count(),
                    voteResults.Where(vr => vr.VoteType.Equals(VoteType.NAY)).Count(),
                    primarySponsor?.Name ?? ""
                );
            }
        }
    }
}