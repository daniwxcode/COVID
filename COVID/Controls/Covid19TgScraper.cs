using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NScrape;

namespace COVID.Controls
{
    class Covid19TgScraper : Scraper
    {
        public Covid19TgScraper(string html) : base(html)
        {

        }
        public string GetConditions()
        {
            var node = HtmlDocument.DocumentNode.Descendants().SingleOrDefault(n => n.Attributes.Contains("id") && n.Attributes["id"].Value == "active-cases");

            if (node != null)
            {
                return node.InnerText;
            }

            throw new ScrapeException("Could not scrape conditions.", Html);
        }
    }
}
