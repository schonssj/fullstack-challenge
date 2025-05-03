using CsvHelper.Configuration.Attributes;

namespace TakeHomeTest.API.Models
{
    public class VoteResult
    {
        [Name("id")]
        public int Id { get; set; }

        [Name("legislator_id")]
        public int LegislatorId { get; set; }

        [Name("vote_id")]
        public int VoteId { get; set; }

        [Name("vote_type")]
        public VoteType VoteType { get; set; }
    }

    public enum VoteType
    {
        YEA = 1,
        NAY = 2
    }
}