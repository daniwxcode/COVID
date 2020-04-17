using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp.Dom;

namespace COVID.Controls
{
    public static class Services
    {
        public static uint ReadInteger(this IDocument doc, string value)
        {
            return doc.QuerySelector(value).TextContent.GetInt();
        }
        public static uint GetInt(this string nombre)
        {
            MatchCollection regxMatches = Regex.Matches(nombre, @"\d+");
            uint.TryParse(string.Join("", regxMatches), out uint n);
            return n;
        }
        public static uint ReadInteger(this IElement doc, string value)
        {
            MatchCollection regxMatches = Regex.Matches(doc.QuerySelector(value).InnerHtml, @"\d+");
            uint.TryParse(string.Join("", regxMatches), out uint n);
            return n;
        }

    }
}
