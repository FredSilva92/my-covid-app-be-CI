using System.Globalization;
using CsvHelper.Configuration;
using MyCovidApp_core.Models;

namespace MyCovidApp_core.Mappers
{
    public class IsoFipsCsvMap : ClassMap<ISOFIPSData>
    {
        public IsoFipsCsvMap() {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Iso2).Name("iso2");
            Map(m => m.Iso3).Name("iso3");
            Map(m => m.CountryName).Name("Country_Region");
            Map(m => m.Continent).Ignore();
        }
    }
}