using CsvHelper.Configuration.Attributes;

namespace TakeHomeTest.API.Models
{
    public class Legislator
    {
        [Name("id")]
        public int Id { get; set; }

        [Name("name")]
        public string Name { get; set; }
    }
}