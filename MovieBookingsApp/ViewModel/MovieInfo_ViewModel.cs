

namespace MovieBookingsApp
{
    public class ScreeningDate
    {
        public DateTime Date { get; set; }
        public string DateString 
        { 
            get => Date.ToString("dddd MMMM dd");
        }
        public IList<DateTime> Times { get; set;}
    }

    [QueryProperty(nameof(MovieObj), "Movie")]
    public class MovieInfo_ViewModel : BaseViewModel
    {
        private Movie _movie;
        private string _wideImage;
        private string _description;
        private string _title;
        private string _runtime;
        private IList<Screening> _screenings;
        private IList<ScreeningDate> _screeningDates;
        private IList<DateTime> _screeningTimes;
        private ScreeningDate _selectedScreeningDate;

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

        public IList<DateTime> ScreeningTimes
        {
            get => _screeningTimes;
            set
            {
                // TODO : Bind this to a list of something that the user can select 

                _screeningTimes = value;
                OnPropertyChanged();
            }
        }

        public ScreeningDate SelectedScreeningDate
        {
            get => _selectedScreeningDate;
            set
            {
                if(value == _selectedScreeningDate) return;

                _selectedScreeningDate = value;
                OnPropertyChanged();

                ScreeningTimes = value.Times;
            }
        }

        public MovieInfo_ViewModel()
        {
            Title = "";
        }

        private void GetMovieInfoAsync(int movieID)
        {
            _screenings = Model.GetScreeningList();

            List<DateTime> screeningDates = new List<DateTime>();

            foreach (var date in _screenings)
            {
                screeningDates.Add(date.StartTime);
            }

            var sortedList = screeningDates.OrderBy(dt => dt.Date).ToList();

            ScreeningDates = sortedList.GroupBy(dt => dt.Date)
                     .Select(g => new ScreeningDate { Date = g.Key, Times = g.ToList() })
                     .ToList();
        }

        private string ConvertMovieLengthToString(int value)
        {
            var time = TimeSpan.FromMinutes(value);

            return time.Hours + "H " + time.Minutes + "M";
        }
    }
}
