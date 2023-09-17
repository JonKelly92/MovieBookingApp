namespace MovieBookingsApp;

public partial class GetTickets : ContentPage
{
    private GetTickets_ViewModel _viewModel;

    public GetTickets()
	{
		InitializeComponent();

        // Links the view and viewmodel
        _viewModel = new GetTickets_ViewModel();
        BindingContext = _viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        // TODO : find a way to use binding instead? 
        _viewModel.OnNavigatedTo();
    }
}
