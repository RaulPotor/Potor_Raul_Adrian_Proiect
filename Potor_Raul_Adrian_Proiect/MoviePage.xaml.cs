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
    public partial class MoviePage : ContentPage
    {
        WatchList wl;
        public MoviePage(WatchList watchList)
        {
            InitializeComponent();
            wl = watchList;
        }


        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var movie = (Movie)BindingContext;
            await App.Database.SaveMovieAsync(movie);
            listView.ItemsSource = await App.Database.GetMoviesAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var movie = (Movie)BindingContext;
            await App.Database.DeleteMovieAsync(movie);
            listView.ItemsSource = await App.Database.GetMoviesAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetMoviesAsync();
        }

        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MoviePage((WatchList)
           this.BindingContext)
            {
                BindingContext = new Movie()
            });

        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            Movie m;
            if (e.SelectedItem != null)
            {
                m = e.SelectedItem as Movie;
                var lp = new ListMovie()
                {
                    WatchListID = wl.ID,
                    MovieID = m.ID
                };
                await App.Database.SaveListMovieAsync(lp);
                m.ListMovies = new List<ListMovie> { lp };

                BindingContext = e.SelectedItem as Movie;

               // await Navigation.PopAsync();
            }
        }


        public async void onStergeButtonClicked(object sender, EventArgs e)
        {
            var todoItem = (Movie)BindingContext;
            await App.Database.DeleteMovieAsync(todoItem);
            await Navigation.PopAsync();
        }



    }
}