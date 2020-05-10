namespace MyCovidApp_core.Models
{
    public class Occurence
    {
        public string CombinedKey { get; set; }
        public string Country { get; set; }
        public int Confirmed { get; set; }
        public int Deaths { get; set; }
        public int Recovered { get; set; }
        public int Active { get; set; }
        public ISOFIPSData IsoData { get; set; }
    }
}