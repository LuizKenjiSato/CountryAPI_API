using CountryAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryAPI.Services
{
    public class CountryRepository : ICountryRepository
    {
        private CountryDBContext _context;
        public CountryRepository(CountryDBContext context)
        {
            _context = context;
        }

        // Get a list with all countries names
        public async Task<IEnumerable<String>> GetAllCountriesName()
        {
            var list_names = _context.Country.OrderBy(r => r.id).Select(r => r.CountryName);
            return await list_names.ToListAsync(); ;
        }
        public async Task<IEnumerable<CountryEntity>> GetAllCountryInfo()
        {
            var all_info = _context.Country.OrderBy(r => r.id);
            return await all_info.ToListAsync();
        }

        public async Task<CountryEntity> GetCountryInfo(string country)
        {
            var country_info = _context.Country.Where(r => r.CountryName == country);
            return await country_info.FirstOrDefaultAsync();
        }

        public async Task AddCountryInfo(CountryEntity countryEntity)
        {
            await _context.AddAsync(countryEntity);
        }

        public CountryEntity UpdateCountryInfo(CountryEntity countryEntity)
        {
            var countryUpdate = _context.Country.Where(r => r.CountryName == countryEntity.CountryName).FirstOrDefault();

            countryUpdate.CapitalCity = countryEntity.CapitalCity;
            countryUpdate.Continent = countryEntity.Continent;
            countryUpdate.Currency = countryEntity.Currency;
            countryUpdate.Population = countryEntity.Population;
            countryUpdate.PrimaryLanguage = countryEntity.PrimaryLanguage;
            countryUpdate.SecondaryLanguage = countryEntity.SecondaryLanguage;
            countryUpdate.ValueToUSD = countryEntity.ValueToUSD;

            return countryUpdate;
        }

        public void DeleteCountryInfo(string country)
        {
            var countryDelete = _context.Country.Where(r => r.CountryName == country).FirstOrDefault();
            _context.Remove(countryDelete);
        }

        public async Task<Double> ConvertCurrency(string fromCountry, string toCountry, double value)
        {
            var fromCountryUSD = await _context.Country.Where(r => r.CountryName == fromCountry).Select(r => r.ValueToUSD).FirstOrDefaultAsync();
            var toCountryUSD = await _context.Country.Where(r => r.CountryName == toCountry).Select(r => r.ValueToUSD).FirstOrDefaultAsync();

            double USD = fromCountryUSD * value;
            double finalValue = USD / toCountryUSD;
            return finalValue;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

    }
}
