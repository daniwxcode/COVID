using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matcha.BackgroundService;

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
            var localData = await Services.GetData();
            var newData = await Covid19TgService.GetDetailsAsync();
            if (localData.InfosduJour().Date != newData.InfosduJour().Date)
            {
                newData.Reverse();
                foreach(var tmp in newData)
                {
                    if (localData.All(p => p.Date != tmp.Date))
                    {
                        localData.Insert(0,tmp);
                    }

                }
                localData.Save();
            }
            
            return true; //return false when you want to stop or trigger only once
        }
    }
}
