using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using COVID.Services;
using NScrape;
using NScrape.Forms;
using Xamarin.Forms;

namespace COVID.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ICommand Appel { get; private set; }

        private string _casactifs;

        public string CasActifs
        {
            get { return _casactifs; }

            set { SetProperty(ref _casactifs, value); }
        }

        private string _casgueris;

        public string CasGueris
        {
            get { return _casgueris; }

            set { SetProperty(ref _casgueris, value); }
        }

        private string _deces;

        public string Deces
        {
            get { return _deces; }

            set { SetProperty(ref _deces, value); }
        }

        private string _casconfirmes;

        public string CasConfirmes
        {
            get { return _casconfirmes; }

            set { SetProperty(ref _casconfirmes, value); }
        }
        private string _date;

        public string DateUpdate
        {
            get { return _date; }

            set { SetProperty(ref _date, value); }
        }


        public HomeViewModel()
        {

            _ = GetDetails();

            Appel = new Command(() => Appeler());
        }

        async Task GetDetails()
        {

            //var stat =  await Covid19TgService.GetAsync();
       
            Covid19TgService.InfosCovid= await Covid19TgService.GetDetailsAsync();

            CasActifs = Covid19TgService.InfosCovid.InfosduJour.ActiveCases.ToString();
            CasGueris = Covid19TgService.InfosCovid.InfosduJour.Cured.ToString();
            Deces = Covid19TgService.InfosCovid.InfosduJour.Deaths.ToString();
            CasConfirmes = Covid19TgService.InfosCovid.InfosduJour.Total.ToString();
            DateUpdate = Covid19TgService.InfosCovid.Details.FirstOrDefault()?.Date;

        }

        private void Appeler()
        {
            Covid19TgService.AppelNumeroVert();
        }
    }
}