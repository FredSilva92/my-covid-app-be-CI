using System.Globalization;
using CsvHelper.Configuration;
using MyCovidApp_core.Models;

namespace MyCovidApp_core.Mappers
{
    public class IsoCsvMap : ClassMap<ISOCode>
    {
        public IsoCsvMap() {
            AutoMap(CultureInfo.InvariantCulture);
        }
    }
}