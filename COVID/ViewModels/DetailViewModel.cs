﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using TgCovidStats.Model;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace COVID.ViewModels
{
    class DetailViewModel : BaseViewModel
    {
        public ICommand Appel { get; private set; }



        private List<Details> _details;
        public List<Details> LeDetails
        {
            get { return _details; }

            set { SetProperty(ref _details, value); }
        }


        public Stats Stat
        {
            get { return _stat; }

            set { SetProperty(ref _stat, value); }
        }
        private Stats _stat;



        private string _date;
        public string Date
        {
            get { return _date; }

            set { SetProperty(ref _date, value); }
        }


        private string _histoire;
        public string Histoire
        {
            get { return _histoire; }

            set { SetProperty(ref _histoire, value); }
        }

        public string ActiveCases { get { return Stat.ActiveCases.ToString(); } }
        public string Cured { get { return Stat.Cured.ToString(); } }
        public string Deaths { get { return Stat.Deaths.ToString(); } }
        public string Total { get { return Stat.Total.ToString(); } }

        public DetailViewModel()
        {
            _ = GetDetailsAsync();

            Appel = new Command(() => Appeler());
        }

        private async Task GetDetailsAsync()
        {
         LeDetails = await TgCovidStats.Get.LocalDetailsAsync();
       
        }

        private void Appeler()
        {
             PhoneDialer.Open("111");
        }

    }
}
