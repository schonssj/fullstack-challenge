namespace TakeHomeTest.API.DTO
{
    public record BillResultsDTO
    (
        int Id, 
        string BillTitle, 
        int Supporters, 
        int Opposers, 
        string PrimarySponsor
    );
}