using Microsoft.EntityFrameworkCore;

namespace CountryWorldApi
{
    [Index(nameof(Alpha2Code), IsUnique = true)]
    public class Country
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public string Alpha2Code { get; set; } = string.Empty;

        public Country() { }
    }
}
