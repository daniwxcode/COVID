using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp.Dom;
using COVID.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace COVID.Services
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
        public static Details InfosduJour(this List<Details> details)
        {
            return details.FirstOrDefault();
        }

        public static string Info (this Details details){
            return $"Nouvelles situation du {details.Date} : {details.Stat.ToString()}";
        }
        public static void Save(this List<Details> json)
        {
            Application.Current.Properties["post_data"] = JsonConvert.SerializeObject(json);
        }
        private static string ReadData()
        {
            var strin = Application.Current.Properties["post_data"].ToString();
            strin = Regex.Replace(strin, @"<[^>]+>|&nbsp;", "").Trim();
            return Regex.Replace(strin, @"\s{2,}", " "); ;
        }
        public static async Task<List<Details>> GetData()
        {
          
            if (Application.Current.Properties.ContainsKey("post_data"))
            {
                  var returnValue = JsonConvert.DeserializeObject<List<Details>>(ReadData());
                  return returnValue;
            }
            else
            {
              var  returnValue = await Covid19TgService.GetDetailsAsync();
               returnValue.Save();
                return  returnValue;
            }

        }
    }
}
