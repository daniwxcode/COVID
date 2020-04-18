using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID.Models
{
    public class Details
    {
        public Stats Stat { get; set; }
        public string Date { get; set; }
        public string Histoire { get; set; }

         public string ActiveCases { get{ return Stat.ActiveCases.ToString();} }
        public string Cured { get{ return Stat.Cured.ToString();} }
        public string  Deaths { get{ return Stat.Deaths.ToString();} }
        public string  Total { get { return Stat.Total.ToString();} }
    }
}
