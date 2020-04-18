
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using COVID.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace COVID.ViewModels
{
    public class BaseViewModel : ObservableObject
    {

        public ICommand Appel { get; set; }
        public BaseViewModel()
        {
            Appel =new Command(async () =>await  Appeler());
        }
        async Task Appeler()
        {
           Covid19TgService.AppelNumeroVert();
        }

    }
}
