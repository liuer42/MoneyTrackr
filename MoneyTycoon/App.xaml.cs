using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MoneyTycoon.Services;
using MoneyTycoon.Views;

namespace MoneyTycoon
{
    public partial class App : Application
    {
        static MoneyDataStore database;

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MoneyDataStore>();
            MainPage = new MainPage();
        }

        public static MoneyDataStore Database
        {
            get
            {
                if(database == null)
                {
                    database = new MoneyDataStore();
                }
                return database;
            }
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
