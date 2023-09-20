﻿

using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MovieBookingsApp
{
    public class GetTickets_ViewModel : BaseViewModel
    {
        public ObservableCollection<Movie> Movies { get; }

        public GetTickets_ViewModel()
        {
            Title = "Get Tickets";

            Movies = new ObservableCollection<Movie>();
        }

        public void OnNavigatedTo()
        {
            RunMethodWithTryCatch(GetMoviesAsync, "Unable to display movies.");
        }

        private async void GetMoviesAsync()
        {
            var moviesList = await Model.GetMovies();

            if (Movies.Count != 0)
                Movies.Clear();

            foreach (Movie movie in moviesList)
            {
                Movies.Add(movie);
            }
        }
    }
}
