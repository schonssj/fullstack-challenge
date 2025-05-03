using TakeHomeTest.API.DTO;
using TakeHomeTest.API.Models;
using TakeHomeTest.API.Repositories;

namespace TakeHomeTest.API.Services
{
    public class LegislatorService
    {
        private readonly LegislatorRepository _legislatorRepository;
        private readonly VoteResultRepository _voteResultRepository;

        public LegislatorService(LegislatorRepository legislatorRepository, VoteResultRepository voteResultRepository)
        {
            _legislatorRepository = legislatorRepository;
            _voteResultRepository = voteResultRepository;
        }

        public IEnumerable<LegislatorVotesDTO> GetLegislatorsVotes()
        {
            var legislators = _legislatorRepository.GetAll();
            foreach (var legislator in legislators)
            {
                var voteResults = _voteResultRepository.GetByLegislatorId(legislator.Id);

                yield return new LegislatorVotesDTO
                (
                    legislator.Id,
                    legislator.Name,
                    voteResults.Where(vr => vr.VoteType.Equals(VoteType.YEA)).Count(),
                    voteResults.Where(vr => vr.VoteType.Equals(VoteType.NAY)).Count()
                );
            }
        }
    }
}