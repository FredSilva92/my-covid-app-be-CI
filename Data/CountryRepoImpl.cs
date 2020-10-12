using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Linq;
using CsvHelper;
using MyCovidApp_core.Models;
using MyCovidApp_core.Utils;
using MyCovidApp_core.Mappers;

namespace MyCovidApp_core.Data
{
    public class CountryRepoImpl : ICountryRepo
    {
        public IEnumerable<ISOFIPSData> getISOCodes() {
            IEnumerable<ISOFIPSData> isoCodes;

            string url = "https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/UID_ISO_FIPS_LookUp_Table.csv";

            HttpWebResponse response = WebUtilities.getHttpResponse(url);

            using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
            using (CsvReader csv = new CsvReader(streamReader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<IsoFipsCsvMap>();
                isoCodes = csv.GetRecords<ISOFIPSData>().ToList();
            }
            return isoCodes;
        }
        public IEnumerable<ISOCode> getContinentCode()
        {
            IEnumerable<ISOCode> codes;

            using (var reader = new StreamReader("../MyCovidApp-core/Files/country_continent.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<IsoCsvMap>();
                codes = csv.GetRecords<ISOCode>().ToList();
            }
            return codes;
        }
    }
}