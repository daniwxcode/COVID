using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace COVID.Api.Models
{
    public class InfosCovid
    {
        public long InfosCovidId { get; set; }

        public Stats InfosOfDay => Details?.FirstOrDefault()?.Stat;

        public List<CovidTgResume> Details { get; set; } = new List<CovidTgResume>();


    }
}
