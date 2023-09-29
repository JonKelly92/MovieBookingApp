

namespace MovieBookingsApp
{
    [QueryProperty(nameof(MovieID), "movieID")]
    public class MovieInfo_ViewModel : BaseViewModel
    {
        private int _movieID;
        public int MovieID
        {
            get => _movieID;
            set
            {
                if (_movieID == value) return;

                _movieID = value;
            }
        }

        public MovieInfo_ViewModel()
        {
            Title = "";
        }

        public void OnNavigatedTo()
        {
            RunMethodWithTryCatch(GetMovieInfoAsync, "Unable to display movie info.");
        }

        private void GetMovieInfoAsync()
        {
            /*

            - Use ID to call a seperated table with more info about this movie
            - i.e. landscape image, description, run time, etc

            - Then also call the Screenings table using this id to get the day and times for screenings
             
            TODO :
             
            - Get the Screening info for this movie
            - Display movie specific image
            - Show description
            - update picker with days the movie is playing
            - show times for the day selected in the picker 
             
             */
        }
    }
}
