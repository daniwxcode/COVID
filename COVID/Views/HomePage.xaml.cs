using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COVID.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace COVID
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
              InitializeComponent();
           
            var stats =  Covid19TgService.GetAsync();
            CasActifs.Text = "30".ToString();
           
        }
    }
}