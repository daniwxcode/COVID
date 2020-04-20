using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID.Api.Models
{
    public class Stats
    {
        public uint ActiveCases { get; set; }

        public uint Cured { get; set; }

        public uint Deaths { get; set; }

        public uint Total => ActiveCases + Cured + Deaths;



        public override string ToString()

        {

            return $"\n Actifs= {ActiveCases} -Guéris={Cured} - Décès ={Deaths} - Total ={Total}";

        }
    }
}
