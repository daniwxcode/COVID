using System;
using System.Threading.Tasks;
using COVID.Services;
using Xamarin.Forms;

namespace COVID.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
            GetDetails();
        }

        async Task GetDetails()
        {
            var stats = await Covid19TgService.GetDetailsAsync();
            CasActifs = stats.InfosduJour.ActiveCases.ToString();
            CasGueris = stats.InfosduJour.Cured.ToString();
            Deces = stats.InfosduJour.Deaths.ToString();
            CasConfirmes = stats.InfosduJour.Total.ToString();
        }

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

    }
}