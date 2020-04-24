using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;
using COVID.Models;
using Xamarin.Essentials;

namespace COVID.Services
{
    public static class Covid19TgService
    {
        public static void AppelNumeroVert()
        {
             PhoneDialer.Open(Covid19TgService.NumeroVert);
        }
        public static string NumeroVert{get;set;}="111";
        public static List<Details> InfosCovid{get;set;}
        public static async Task<List<Details>> GetDetailsAsync()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync("http://covid19.gouv.tg/situation-au-togo/");
            var details = new List<Details>();

            var sections = document.QuerySelectorAll(".ee-loop__item>article>div>div>div");
            string xt = string.Empty;

            foreach (var item in sections.Skip(1))
            {
                var itemDetails = new Details();
                xt += "\n\n";
                var itemsections = item.QuerySelectorAll("section");
                var itemHtmlDetails = itemsections.FirstOrDefault().QuerySelectorAll("h2");
                itemDetails.Date = $"{itemHtmlDetails[0].InnerHtml} à { itemHtmlDetails[1].InnerHtml}";

              
                Stats itemStats = new Stats();
                itemStats.ActiveCases = itemHtmlDetails[3].InnerHtml.GetInt();
                itemStats.Cured = itemHtmlDetails[4].InnerHtml.GetInt();
                itemStats.Deaths = itemHtmlDetails[5].InnerHtml.GetInt();
                itemDetails.Stat = itemStats;
                foreach (var history in itemsections[1].QuerySelectorAll("p"))
                {
                    itemDetails.Histoire += $"\n{history.InnerHtml}";
                }
                details.Add(itemDetails);

            }

            return details;
        }

    }
}
