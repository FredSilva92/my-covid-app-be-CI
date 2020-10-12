using System.Collections.Generic;
using MyCovidApp_core.Models;

namespace MyCovidApp_core.Data
{
    public interface ICountryRepo
    {
        IEnumerable<ISOFIPSData> getISOCodes();
        IEnumerable<ISOCode> getContinentCode();
    }
}