

using System.Diagnostics;

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
                OnPropertyChanged();
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
                OnPropertyChanged();
            }
        }

        protected async void RunMethodWithTryCatch(Action method, string message = "An error occurred.")
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;

                method();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error", message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
