using CsvHelper.Configuration.Attributes;

namespace TakeHomeTest.API.Models
{
    public class Bill
    {
        [Name("id")]
        public int Id { get; set; }

        [Name("title")]
        public string Title { get; set; }

        [Name("sponsor_id")]
        public int PrimarySponsor { get; set; }
    }
}