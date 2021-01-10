using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Potor_Raul_Adrian_Proiect.Models;

namespace Potor_Raul_Adrian_Proiect
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }


        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var slist = (WatchList)BindingContext;
            slist.Date = DateTime.UtcNow;
            await App.Database.SaveWatchListAsync(slist);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var slist = (WatchList)BindingContext;
            await App.Database.DeleteWatchListAsync(slist);
            await Navigation.PopAsync();
        }

        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MoviePage((WatchList)
           this.BindingContext)
            {
                BindingContext = new Movie()
            });

        }

   
        protected override async void OnAppearing()
        {
            base.OnAppearing(); var shopl = (WatchList)BindingContext;
            listView.ItemsSource = await App.Database.GetListMoviesAsync(shopl.ID);
        }
    }
}