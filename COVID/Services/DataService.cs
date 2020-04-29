using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TgCovidStats.Model;
using Xamarin.Forms;

namespace COVID.Services
{
    public static class DataService
    {
        public static void Save(this List<Details> json)
        {
            Application.Current.Properties["post_data"] = JsonConvert.SerializeObject(json);
        }
         public static void Save(this Stats json)
        {
            Application.Current.Properties["stats"] = JsonConvert.SerializeObject(json);
        }
        private static string ReadData()
        {
            return Application.Current.Properties["post_data"].ToString();
           
        }
            private static string ReadStats()
        {
            return Application.Current.Properties["stats"].ToString();
           
        }
        public static async Task<Stats> GetStats()
        {
              if (Application.Current.Properties.ContainsKey("stats"))
            {
                  var returnValue = JsonConvert.DeserializeObject<Stats>(ReadStats());
                  return returnValue;
            }
            else
            {
              var  returnValue = await TgCovidStats.Get.StatAsync();
              returnValue.Save();
              return  returnValue;
            }
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
              var  returnValue = await TgCovidStats.Get.DetailsAsync();
               returnValue.Save();
                return  returnValue;
            }

        }
    }
}
