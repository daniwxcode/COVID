using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using COVID.Api.Models;

namespace COVID.Api.Data
{
    public class InfosCovidProvider
    {
        public static void Add(InfosCovid infosCovid)
        {
            using var db = new SqLiteDbContext();
            db.Add(infosCovid);
            db.SaveChanges();
        }

        public static async Task<InfosCovid> GetLastAsync()
        {
//            await using var db = new SqLiteDbContext();
//            var infos = db.InfosCovids?.AsEnumerable().LastOrDefault();
//            if (infos?.InfosOfDay == null)
//            {
//                infos = await LoadInfosCovidAsync();
//            }
//
//            return infos ;

            return await LoadInfosCovidAsync();
        }

        public static bool HaveDiff(InfosCovid oldInfos, InfosCovid newInfos )
        {
            return !(
                oldInfos.InfosOfDay.ActiveCases == newInfos.InfosOfDay.ActiveCases &&
                oldInfos.InfosOfDay.Cured == newInfos.InfosOfDay.Cured &&
                oldInfos.InfosOfDay.Deaths == newInfos.InfosOfDay.Deaths &&
                oldInfos.InfosOfDay.Total == newInfos.InfosOfDay.Total
            );
        }

        public static async Task<InfosCovid> LoadInfosCovidAsync()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync("http://covid19.gouv.tg/situation-au-togo/");
            var details = new List<CovidTgResume>();

            var sections = document.QuerySelectorAll(".ee-loop__item>article>div>div>div");

            foreach (var item in sections.Skip(1))
            {
                var itemDetails = new CovidTgResume();
                var itemSections = item.QuerySelectorAll("section");
                var itemHtmlDetails = itemSections.FirstOrDefault()?.QuerySelectorAll("h2");
                if (itemHtmlDetails != null)
                {
                    itemDetails.Date = $"{itemHtmlDetails[0].InnerHtml} à {itemHtmlDetails[1].InnerHtml}";

                    Stats itemStats = new Stats
                    {
                        ActiveCases = uint.Parse(itemHtmlDetails[3].InnerHtml.Replace("cas", "").Trim()),
                        Cured = uint.Parse(itemHtmlDetails[4].InnerHtml.Replace("cas", "").Trim()),
                        Deaths = uint.Parse(itemHtmlDetails[5].InnerHtml.Replace("cas", "").Trim())
                    };
                    itemDetails.Stat = itemStats;
                }

                foreach (var history in itemSections[1].QuerySelectorAll("p"))
                {
                    itemDetails.History += $"\n\n{history.InnerHtml}";
                }
                details.Add(itemDetails);

            }
            var infos = new InfosCovid()
            {
                Details = details
            };

           // Add(infos);

            return infos;
        }
    }
}
