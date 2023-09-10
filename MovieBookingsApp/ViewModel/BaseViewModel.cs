using System.ComponentModel;

namespace MovieBookingsApp
{
    public class BaseViewModel : BindableObject
    {
        private bool _isBusy;
        private string _title;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if(_isBusy == value) return;

                _isBusy = value;
                OnPropertyChanged(nameof(_isBusy));
                OnPropertyChanged(nameof(IsNotBusy));
            }
        }

        public bool IsNotBusy => !_isBusy;

        public string Title
        {
            get => _title;
            set
            {
                if(_title == value) return;
                _title = value;
                OnPropertyChanged(nameof(_title));
            }
        }
    }
}
