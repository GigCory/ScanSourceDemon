using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace assessment_platform_developer.Models
{
    public interface IProvince
    {
        int ProvinceID { get; set; }
        string ProvinceName { get; set; }
    }
    public class Province : IProvince
    {
        public int ProvinceID { get; set; }
        public string ProvinceName { get; set; }
        public List<Province> ProvinceList(int countryID)
        {
            List<Province> provinces = new List<Province>();
            if (countryID == 0)
            {
                provinces = Enum.GetValues(typeof(CanadianProvinces)).Cast<CanadianProvinces>().Select(p => new Province
                {
                    ProvinceID = (int)p,
                    ProvinceName = p.ToString()
                }).ToList();
            }
            else if (countryID == 1)
            {
                provinces = Enum.GetValues(typeof(USStates)).Cast<USStates>().Select(p => new Province
                {
                    ProvinceID = (int)p,
                    ProvinceName = p.ToString()
                }).ToList();
            }
            return provinces;
        }
    }
    public enum USStates
    {
        Alabama,
        Alaska,
        Arizona,
        Arkansas,
        California,
        Colorado,
        Connecticut,
        Delaware,
        Florida,
        Georgia,
        Hawaii,
        Idaho,
        Illinois,
        Indiana,
        Iowa,
        Kansas,
        Kentucky,
        Louisiana,
        Maine,
        Maryland,
        Massachusetts,
        Michigan,
        Minnesota,
        Mississippi,
        Missouri,
        Montana,
        Nebraska,
        Nevada,
        [Description("New Hampshire")]
        NewHampshire,
        [Description("New Jersey")]
        NewJersey,
        [Description("New Mexico")]
        NewMexico,
        [Description("New York")]
        NewYork,
        [Description("North Carolina")]
        NorthCarolina,
        [Description("North Dakota")]
        NorthDakota,
        Ohio,
        Oklahoma,
        Oregon,
        Pennsylvania,
        [Description("Rhode Island")]
        RhodeIsland,
        [Description("South Carolina")]
        SouthCarolina,
        [Description("South Dakota")]
        SouthDakota,
        Tennessee,
        Texas,
        Utah,
        Vermont,
        Virginia,
        Washington,
        [Description("West Virginia")]
        WestVirginia,
        Wisconsin,
        Wyoming
    }
    public enum CanadianProvinces
    {
        Alberta,
        [Description("British Columbia")]
        BritishColumbia,
        Manitoba,
        NewBrunswick,
        [Description("Newfoundland and Labrador")]
        NewfoundlandAndLabrador,
        [Description("Northwest Territories")]
        NovaScotia,
        Ontario,
        [Description("Prince Edward Island")]
        PrinceEdwardIsland,
        Quebec,
        Saskatchewan,
        [Description("Yukon")]
        NorthwestTerritories,
        Nunavut,
        Yukon
    }
}