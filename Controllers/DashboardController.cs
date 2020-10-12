using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCovidApp_core.Data;
using System.Linq;
using MyCovidApp_core.Dtos;
using System.Collections;
using System.Collections.Generic;
using MyCovidApp_core.Models;
using System;

namespace MyCovidApp_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ICovid19Repo _repo;
        public DashboardController(ICovid19Repo repo) {
            _repo = repo;
        }


        [HttpGet("totalCases")]
        public IActionResult getTotalCases(string reportDate, string continent) {
            IEnumerable<Occurence> totalCases;

            try {
                totalCases = _repo.getTotalCases(reportDate);
            } catch (Exception ex) {
                return NotFound(ex.Message);
            }
            
            IEnumerable<Occurence> casesToMap = null;

            if (string.IsNullOrEmpty(continent)) {
                casesToMap = totalCases;
            } else {
                casesToMap = totalCases.Where(item => 
                    item.IsoData.Continent.Equals(continent)).ToList();
            }
            
            TotalCasesDto totalCasesDto = new TotalCasesDto {
                Confirmed = casesToMap.Sum(item => item.Confirmed),
                Recovered = casesToMap.Sum(item => item.Recovered),
                Deaths = casesToMap.Sum(item => item.Deaths),
                Active = casesToMap.Sum(item => item.Active) 
            };

            return Ok(totalCasesDto);
        }
        
    }
}