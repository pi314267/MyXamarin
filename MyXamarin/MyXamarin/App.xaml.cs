using MyXamarin.Service;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyXamarin
{
    public partial class App : Application
    {
        public App()
        {
            DependencyService.Register<MockDataStore>();

            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
