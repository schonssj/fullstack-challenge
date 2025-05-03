namespace TakeHomeTest.API.DTO
{
    public record LegislatorVotesDTO
    (
        int LegislatorId,
        string LegislatorName,
        int SupportedBills,
        int OpposedBills
    );
}