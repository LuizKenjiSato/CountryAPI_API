using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CountryAPI.Entities;
using CountryAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CountryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        //private CountryDBContext _context = new CountryDBContext();
        private CountryDBContext _context;
        private ICountryRepository _countryRepository;
        private readonly IMapper _mapper;


        public CountryController(ICountryRepository countryRepository, IMapper mapper, CountryDBContext context)
        {
            _context = context;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet("AllCountriesName/")]
        public async Task<ActionResult<List<String>>> GetCountriesName()
        {
            //var countryName = _context.Country.OrderBy(r => r.id).Select(r => r.CountryName).ToList();
            var countryName = await _countryRepository.GetAllCountriesName();
            return Ok(countryName);
        }

        [HttpGet("AllCountryInfo/")]
        public async Task<ActionResult<IEnumerable<CountryEntity>>> GetAllCountriesInfo()
        {
            //var countryInfo = _context.Country.OrderBy(r => r.id).ToList();
            var countryInfo = await _countryRepository.GetAllCountryInfo();
            return Ok(countryInfo);
        }

        [HttpGet("CountryInfo/{country}")]
        public async Task<ActionResult<CountryEntity>> GetCountryInfo(string country)
        {
            //var countryInfo = _context.Country.Where(r => r.CountryName == country).FirstOrDefault();
            var countryInfo = await _countryRepository.GetCountryInfo(country);
            return Ok(countryInfo);
        }

        [HttpPost("AddCountry")]
        public async Task<ActionResult> AddCountryInfo([FromBody] CountryEntity countryEntity)
        {
            try
            {
                //_context.Add(countryEntity);
                //_context.SaveChanges();
                await _countryRepository.AddCountryInfo(countryEntity);
                await _countryRepository.Save();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
            
        }
        [HttpPut("UpdateCountry")]
        public async Task<ActionResult> UpdateCountryInfo([FromBody] CountryEntity countryEntity)
        {
            try
            {
                CountryEntity updatedCountry = _countryRepository.UpdateCountryInfo(countryEntity);
                _context.Update(updatedCountry);
                await _countryRepository.Save();
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteCountry/{country}")]
        public async Task<ActionResult> DeleteCountryInfo(string country)
        {
            try
            {
                _countryRepository.DeleteCountryInfo(country);
                await _countryRepository.Save();
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet("CurrencyExchange/{fromCountry}/{toCountry}/{value}")]
        public async Task<ActionResult> ConvertCurrency(string fromCountry, string toCountry, double value)
        {

            double final_price = await _countryRepository.ConvertCurrency(fromCountry, toCountry, value);

            return Ok(final_price);
        }
























        //[HttpGet("AllCountriesName/")]
        //public async Task<ActionResult<IEnumerable<String>>> GetCountriesName()
        //{
        //    var countryNames = await _countryRepository.GetAllCountriesName();
        //    return Ok("Luiz");
        //}


        //[HttpGet("AllCountryNames/")]
        //public async Task<ActionResult<IEnumerable<String>>> GetListNames()
        //{

        //    var conditions = new List<ScanCondition>();
        //    // you can add scan conditions, or leave empty
        //    var allDocs = await context.ScanAsync<Country>(conditions).GetRemainingAsync();

        //    var countries = allDocs.ToArray();
        //    List<string> country_names = new List<string>();
        //    foreach (var names in countries)
        //    {
        //        country_names.Add(names.CountryName);

        //    }
        //    return country_names;
        //}

        //[HttpGet("AllCountryInfo/")]
        //public async Task<ActionResult<IEnumerable<Country>>> GetAll()
        //{

        //    var conditions = new List<ScanCondition>();
        //    // you can add scan conditions, or leave empty
        //    var allDocs = await context.ScanAsync<Country>(conditions).GetRemainingAsync();

        //    return allDocs.ToArray();
        //}

        //[HttpGet("CountryInfo/{country}")]
        //public async Task<ActionResult<IEnumerable<Country>>> GetAll(string country)
        //{
        //    var conditions = new List<ScanCondition>();
        //    conditions.Add(new ScanCondition("CountryName", ScanOperator.Equal, country));

        //    var allDocs = await context.ScanAsync<Country>(conditions).GetRemainingAsync();

        //    return allDocs.ToArray();
        //}


        //[HttpPost]
        //public async Task<ActionResult<IEnumerable<Country>>> PostCountry()
        //{

        //}
    }
}
