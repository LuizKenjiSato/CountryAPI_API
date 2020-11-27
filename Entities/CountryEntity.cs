using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CountryAPI.Entities
{
    public class CountryEntity
    {
        [Key]
        public int id { get; set; }
        public string CountryName { get; set; }
        public string CapitalCity { get; set; }
        public string Continent { get; set; }
        public string Currency { get; set; }
        public double Population { get; set; }
        public string PrimaryLanguage { get; set; }
        public string SecondaryLanguage { get; set; }
        public double ValueToUSD { get; set; }
    }
}
