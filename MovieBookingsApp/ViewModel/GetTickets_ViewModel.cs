

using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MovieBookingsApp
{
    public class GetTickets_ViewModel : BaseViewModel
    {
        public ObservableCollection<Movie> Movies { get; }

        public Movie SelectedMovie { get; set; }

        public Command SelectMovieCommand { get; }

        public GetTickets_ViewModel()
        {
            Title = "Get Tickets";

            Movies = new ObservableCollection<Movie>();

            SelectMovieCommand = new Command(SelectMovie);
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

        private async void SelectMovie()
        {
            Console.WriteLine("Select Movie: " + SelectedMovie.Name);

            // TODO : when using the actual data base only pass the ID 
            await Shell.Current.GoToAsync($"{nameof(MovieInfo)}?movieID={SelectedMovie.id}", true);
        }
    }
}
