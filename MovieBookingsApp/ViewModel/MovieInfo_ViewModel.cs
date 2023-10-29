

namespace MovieBookingsApp
{
    public class ScreeningDate
    {
        public DateTime Date { get; set; }
        public string DateString
        {
            get => Date.ToString("dddd MMMM dd");
        }
        public IList<DateTime> Times { get; set; }
        public IList<Screening> Screenings { get; set; }
    }

    [QueryProperty(nameof(MovieObj), "Movie")]
    public class MovieInfo_ViewModel : BaseViewModel
    {
        private Movie _movie;
        private string _wideImage;
        private string _description;
        private string _title;
        private string _runtime;
        private IList<ScreeningDate> _screeningDates;
        private IList<Screening> _screeningTimes;
        private ScreeningDate _selectedScreeningDate;
        private Screening _selectedScreeningTime;

        #region Properties

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

        public IList<ScreeningDate> ScreeningDates
        {
            get => _screeningDates;
            set
            {
                _screeningDates = value;
                OnPropertyChanged();
            }
        }

        public IList<Screening> ScreeningTimes
        {
            get => _screeningTimes;
            set
            {
                _screeningTimes = value;
                OnPropertyChanged();
            }
        }

        public ScreeningDate SelectedScreeningDate
        {
            get => _selectedScreeningDate;
            set
            {
                if (value == _selectedScreeningDate) return;

                _selectedScreeningDate = value;
                OnPropertyChanged();

                ScreeningTimes = value.Screenings;
            }
        }

        public Screening SelectedScreenTime
        {
            get => _selectedScreeningTime;
            set
            {
                if (value == _selectedScreeningTime) return;

                _selectedScreeningTime = value;
                OnPropertyChanged();

                CreateBookingAsync(_selectedScreeningTime);
            }
        }

        #endregion

        public MovieInfo_ViewModel()
        {
            Title = "";
        }

        private void CreateBookingAsync(Screening screening)
        {
            if (Model.CreateBooking(screening))
            {
                Shell.Current.DisplayAlert("Booked", "Successfully created a booking for " + screening.StartTime.ToString("dddd MMMM dd") + " at " + screening.StartTime.ToString("hh:mm tt"), "OK");
            }
            else 
            {
                Shell.Current.DisplayAlert("Oops", "Failed to create the booking", "OK");
            }
        }

        private void GetMovieInfoAsync(int movieID)
        {
            var rawScreeningList = Model.GetScreeningList();

            var sortedScreeningList = rawScreeningList.OrderBy(dt => dt.StartTime.Date).ToList();

            ScreeningDates = sortedScreeningList.GroupBy(dt => dt.StartTime.Date)
                     .Select(g => new ScreeningDate { Date = g.Key, Screenings = g.ToList() })
                     .ToList();
        }

        private string ConvertMovieLengthToString(int value)
        {
            var time = TimeSpan.FromMinutes(value);

            return time.Hours + "H " + time.Minutes + "M";
        }
    }
}
