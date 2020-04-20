using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID.Api.Models
{
    public class CovidTgResume
    {
        public Stats Stat { get; set; }
        public string Date { get; set; }
        public string History { get; set; }

        public string ActiveCases => Stat.ActiveCases.ToString();
        public string Cured => Stat.Cured.ToString();
        public string Deaths => Stat.Deaths.ToString();
        public string Total => Stat.Total.ToString();
    }
}
