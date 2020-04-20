using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COVID.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace COVID.Api.Data
{
    public class SqLiteDbContext: DbContext
    {
        public DbSet<InfosCovid> InfosCovids { get; set; }
        public DbSet<CovidTgResume> CovidTgResumes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=covidsqlite.db");
    }
}
