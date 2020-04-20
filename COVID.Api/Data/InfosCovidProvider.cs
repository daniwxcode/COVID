using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp;
using COVID.Api.Models;

namespace COVID.Api.Data
{
    public class InfosCovidProvider
    {
        public static List<CovidTgResume> Details { get; set; }
        public static Timer AutoRefreshTimer { get; set; }

        static InfosCovidProvider()
        {
            Details= new List<CovidTgResume>();
            AutoRefreshTimer = null;
        }

        public static  void AutoRefresh()
        {
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(1);

            AutoRefreshTimer = new Timer(async (e) =>
            {
                Details = await LoadInfosCovidAsync();

            }, null, startTimeSpan, periodTimeSpan);

        }

        public static async Task<List<CovidTgResume>> GetLastAsync()
        {
            if (Details.Count == 0)
            {
                Details = await LoadInfosCovidAsync();
                if (AutoRefreshTimer == null)
                {
                    AutoRefresh();
                }
            }
            
            return Details;
        }

        public static bool HaveDiff(CovidTgResume oldCovidTgResume, CovidTgResume newCovidTgResume )
        {
            return !(
                oldCovidTgResume.ActiveCases == newCovidTgResume.ActiveCases &&
                oldCovidTgResume.Cured == newCovidTgResume.Cured &&
                oldCovidTgResume.Deaths == newCovidTgResume.Deaths &&
                oldCovidTgResume.Total == newCovidTgResume.Total
            );
        }

        public static async Task<List<CovidTgResume>> LoadInfosCovidAsync()
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
          

            return details;
        }
    }
}
