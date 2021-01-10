using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Potor_Raul_Adrian_Proiect.Data;

namespace Potor_Raul_Adrian_Proiect
{
    public partial class App : Application
    {

        static WatchListDatabase database;
        public static WatchListDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   WatchListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "WatchingList.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListEntryPage());
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
