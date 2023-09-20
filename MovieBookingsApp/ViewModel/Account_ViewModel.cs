
using System.Diagnostics;

namespace MovieBookingsApp
{
    public class Account_ViewModel : BaseViewModel
    {
        private UserInfo _userinfo;

        private string _firstName;
        private string _lastName;
        private string _email;

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName == value) return;

                _firstName = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName == value) return;

                _lastName = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                if (_email == value) return;

                _email = value;
                OnPropertyChanged();
            }
        }

        // public Command GetAccountInfoCommand { get; }

        public Account_ViewModel()
        {
            Title = "Account";

            //  GetAccountInfoCommand = new Command(async () => await GetAccountInfoAsync());
        }

        public void OnNavigatedTo()
        {
            RunMethodWithTryCatch(GetAccountInfoAsync, "Unable to display account info.");
        }

        private async void GetAccountInfoAsync()
        {
            if (!Model.IsSignedIn())
            {
                // TODO : ask user to sign in
            }

            _userinfo = await Model.GetUserInfo();

            if (!string.IsNullOrEmpty(_userinfo.FirstName))
                FirstName = _userinfo.FirstName;
            else
                FirstName = "None";

            if (!string.IsNullOrEmpty(_userinfo.LastName))
                LastName = _userinfo.LastName;
            else
                LastName = "None";

            if (!string.IsNullOrEmpty(_userinfo.Email))
                Email = _userinfo.Email;
            else
                Email = "None";
        }
    }
}
