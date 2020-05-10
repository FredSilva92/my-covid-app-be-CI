namespace MyCovidApp_core.Dtos
{
    public class TotalCasesDto
    {
        public int Confirmed { get; set; }
        public int Recovered { get; set; }
        public int Deaths { get; set; }
        public int Active { get; set; }
    }
}