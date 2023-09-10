
using System.Diagnostics;

namespace MovieBookingsApp
{
    public class Account_ViewModel : BaseViewModel
    {
        private UserInfo _userinfo;

       // public Command GetAccountInfoCommand { get; }

        public Account_ViewModel() 
        {
            Title = "Account";

          //  GetAccountInfoCommand = new Command(async () => await GetAccountInfoAsync());
        }

        private async Task GetAccountInfoAsync()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;

                if(!Model.IsSignedIn()) 
                {
                    // TODO : ask user to sign in

                    return;
                }

                _userinfo = Model.GetUserInfo();

                // TODO : Display user info 
            }
            catch (Exception ex)
            { 
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error", "Unable to display account info", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
