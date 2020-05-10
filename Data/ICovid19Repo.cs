using System.Collections.Generic;
using System.Threading.Tasks;
using MyCovidApp_core.Models;

namespace MyCovidApp_core.Data
{
    public interface ICovid19Repo
    {
        IEnumerable<Occurence> getTotalCases(string reportDate);
    }
}