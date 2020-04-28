using System.Threading.Tasks;
using System.Windows.Input;
using COVID.Services;
using Xamarin.Essentials;
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
            var infos = await TgCovidStats.Get.LocalStatAsync();
            CasActifs = infos.ActiveCases.ToString();
            CasGueris = infos.Cured.ToString();
            Deces = infos.Deaths.ToString();
            CasConfirmes = infos.Total.ToString();
            DateUpdate = infos.TimeInfo.ToString();
        }

        private void Appeler()
        {
            PhoneDialer.Open("111");
        }
    }
}