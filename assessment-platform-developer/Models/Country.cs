using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace assessment_platform_developer.Models
{
    public interface ICountry
    {
        int CountryID { get; set; }
        string CountryName { get; set; }
    }
    public class Country : ICountry
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public List<Country> countryList()
        {
            List<Country> countries = new List<Country>();
            countries = Enum.GetValues(typeof(Countries))
                .Cast<Countries>()
                .Select(c => new Country
                {
                    CountryID = (int)c,
                    CountryName = c.ToString()
                }).ToList();
            return countries;
        }
    }

    public enum Countries
    {
        Canada,
        [Description("United States")]
        UnitedStates
    }
}