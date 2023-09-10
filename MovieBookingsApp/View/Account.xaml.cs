using AndroidX.Lifecycle;

namespace MovieBookingsApp;

public partial class Account : ContentPage
{
	private Account_ViewModel _viewModel;

	public Account()
	{
		InitializeComponent();

        // Links the view and viewmodel
        _viewModel = new Account_ViewModel();
        BindingContext = _viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        // TODO : find a way to use binding instead? 
        _viewModel.LoadAccountInfo();
    }
}