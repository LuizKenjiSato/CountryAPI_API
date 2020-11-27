using CountryAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryAPI.Services
{
    public interface ICountryRepository
    {
        Task<IEnumerable<String>> GetAllCountriesName();

        Task<IEnumerable<CountryEntity>> GetAllCountryInfo();

        Task<CountryEntity> GetCountryInfo(string country);

        Task AddCountryInfo(CountryEntity countryEntity);

        CountryEntity UpdateCountryInfo(CountryEntity countryEntity);

        void DeleteCountryInfo(string country);

        Task<Double> ConvertCurrency(string fromCountry, string toCountry, double value);

        Task Save();
    }
}
