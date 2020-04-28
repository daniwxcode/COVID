using System;
using System.Linq;
using System.Threading.Tasks;
using Matcha.BackgroundService;
using Plugin.LocalNotifications;
using TgCovidStats.Data;

namespace COVID.Services
{
    class BackGroundService : IPeriodicTask
    {
        public BackGroundService(int Minutes)
        {
            Interval = TimeSpan.FromSeconds(Minutes * 60);
        }

        public TimeSpan Interval { get; set; }

        public async Task<bool> StartJob()
        { 
            var localData = await TgCovidStats.Get.LocalDetailsAsync();
            var newData = await TgCovidStats.Get.DetailsAsync();
            if (localData.FirstOrDefault().Stat.TimeInfo != newData.FirstOrDefault().Stat.TimeInfo)
            {
                newData.Reverse();
                foreach(var tmp in newData)
                {
                    if (localData.All(p => p.Stat.TimeInfo != tmp.Stat.TimeInfo))
                    {
                        localData.Insert(0,tmp);
                    }

                }
                CrossLocalNotifications.Current.Show("TOGO INFO COVID:", localData.InfosduJour().Info());
                localData.SaveDetails();
            }

         
            return true; //return false when you want to stop or trigger only once
        }
    }
}
