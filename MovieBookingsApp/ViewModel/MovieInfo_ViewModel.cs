

namespace MovieBookingsApp
{
    [QueryProperty(nameof(MovieObj), "Movie")]
    public class MovieInfo_ViewModel : BaseViewModel
    {
        private Movie _movie;
        private string _wideImage;
        private string _description;
        private string _title;
        private string _runtime;
        private IList<Screening> _screenings;

        public Movie MovieObj
        {
            get => _movie;
            set
            {
                if (_movie == value) return;

                _movie = value;

                WideImage = value.WideImageURI;
                Description = value.Description;
                MovieTitle = value.Name;
                RunTime = ConvertMovieLengthToString(value.LengthMin);

                GetMovieInfoAsync(value.id);
            }
        }

        public string WideImage
        {
            get => _wideImage;
            set
            {
                if (_wideImage == value) return;

                _wideImage = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (_description == value) return;

                _description = value;
                OnPropertyChanged();
            }
        }

        public string MovieTitle
        {
            get => _title;
            set
            {
                if (_title == value) return;

                _title = value;
                OnPropertyChanged();
            }
        }

        public string RunTime
        {
            get => _runtime;
            set
            {
                if (_runtime == value) return;

                _runtime = value;
                OnPropertyChanged();
            }
        }

        public IList<Screening> Screenings
        {
            get => _screenings;
            set
            {
                _screenings = value;
                OnPropertyChanged();
            }
        }

        public MovieInfo_ViewModel()
        {
            Title = "";
        }

        private void GetMovieInfoAsync(int movieID)
        {
            /*

            - Call the Screenings table using this id to get the day and times for screenings
             
            TODO : make this async && add try catch
             
            - Get the Screening info for this movie
            - update picker with days the movie is playing
            - show times for the day selected in the picker 
             
             */

            Screenings = Model.GetScreeningList();

            // Need to pick days using the picker and then display times for that day 
        }

        private string ConvertMovieLengthToString(int value)
        {
            var time = TimeSpan.FromMinutes(value);

            return time.Hours + "H " + time.Minutes + "M";
        }
    }
}
