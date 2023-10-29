namespace MovieBookingsApp;

public partial class Bookings : ContentPage
{
    private Bookings_ViewModel _viewModel;

    public Bookings()
    {
        InitializeComponent();

        _viewModel = new Bookings_ViewModel();
        BindingContext = _viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        _viewModel.OnNavigatedTo();
    }
}