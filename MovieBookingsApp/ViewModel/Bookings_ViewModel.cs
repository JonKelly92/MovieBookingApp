

using System.Collections.ObjectModel;

namespace MovieBookingsApp
{
    public class Bookings_ViewModel : BaseViewModel
    {
        private ObservableCollection<Screening> _bookings;

        public ObservableCollection<Screening> Bookings
        {
            get => _bookings;
            set
            {
                _bookings = value;
                OnPropertyChanged();
            }
        }

        public Bookings_ViewModel()
        {
            Title = "Testing the title for Bookings";
        }

        public void OnNavigatedTo()
        {
            GetBookingsAsync();
        }

        private void GetBookingsAsync()
        {
            var bookingsIList = Model.GetBookings();

            if(bookingsIList != null) 
            { 
                Bookings = new ObservableCollection<Screening>(bookingsIList);
            }
        }
    }
}
