namespace MovieBookingsApp;

public partial class Account : ContentPage
{
	public Account()
	{
		InitializeComponent();

		// Links the view and viewmodel
		BindingContext = new Account_ViewModel();
	}
}