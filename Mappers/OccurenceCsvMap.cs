using System.Globalization;
using CsvHelper.Configuration;
using MyCovidApp_core.Models;

namespace MyCovidApp_core.Mappers
{
    public sealed class OccurenceCsvMap : ClassMap<Occurence>
    {
        public OccurenceCsvMap() {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.CombinedKey).Name("Combined_Key");
            Map(m => m.Country).Name("Country_Region");
            Map(m => m.IsoData.Iso2).Ignore();
            Map(m => m.IsoData.Iso3).Ignore();
            Map(m => m.IsoData.CountryName).Ignore();
            Map(m => m.IsoData.Continent).Ignore();
            Map(m => m.IsoData.Population).Ignore();
        }
        
    }
}