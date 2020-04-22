using System;
using COVID.Services;
using Matcha.BackgroundService;
using MediaManager;
using Xamarin.Forms;
using Xamarin.Forms.Svg;
using Xamarin.Forms.Xaml;

namespace COVID
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // CrossMediaManager.Current.Init();
            SvgImageSource.RegisterAssembly();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            //Register Periodic Tasks
            BackgroundAggregatorService.Add(() => new BackGroundService(1));
            //Start the background service
            BackgroundAggregatorService.StartBackgroundService();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
