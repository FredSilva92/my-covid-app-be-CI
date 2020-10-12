using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using MyCovidApp_core.Mappers;
using MyCovidApp_core.Models;
using MyCovidApp_core.Utils;

namespace MyCovidApp_core.Data
{
    public class Covid19RepoImpl : ICovid19Repo
    {
        private readonly ICountryRepo _countryRepo;
        public Covid19RepoImpl(ICountryRepo countryRepo) {
            _countryRepo = countryRepo;
        }
        public IEnumerable<Occurence> getTotalCases(string reportDate)
        {
            IEnumerable<Occurence> occurences;
            
            string url = $"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_daily_reports/{reportDate}.csv";

            HttpWebResponse response = WebUtilities.getHttpResponse(url);

            using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
            using (CsvReader csv = new CsvReader(streamReader, CultureInfo.InvariantCulture))
            {     
                csv.Configuration.RegisterClassMap<OccurenceCsvMap>();
                occurences = csv.GetRecords<Occurence>().ToList();

                var isoCodes = _countryRepo.getISOCodes();
                var countryContinentCodes = _countryRepo.getContinentCode();

                foreach (var occurence in occurences)
                {
                    var isoDataOccurence = occurence.IsoData;
                    var isoCode = isoCodes.FirstOrDefault(item => item.Iso2.Equals(occurence.Country)
                        || item.Iso3.Equals(occurence.Country)
                        || item.CountryName.Equals(occurence.Country));
                    
                    if (isoCode == null) {
                        continue;
                    }

                    isoDataOccurence.Iso2 = isoCode.Iso2;
                    isoDataOccurence.Iso3 = isoCode.Iso3;
                    isoDataOccurence.CountryName = isoCode.CountryName;
                    isoDataOccurence.Population = isoCode.Population;

                    var countryContinentCode = countryContinentCodes
                        .FirstOrDefault(item => item.Country.Equals(isoDataOccurence.Iso2));
                    
                    if (countryContinentCode == null) {
                        isoDataOccurence.Continent = "";
                        continue;
                    }

                    isoDataOccurence.Continent = countryContinentCode.Continent;
                }
            }

            return occurences;
        }
    }
}