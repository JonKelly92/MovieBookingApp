namespace MovieBookingsApp;

public partial class MovieInfo : ContentPage
{
	private MovieInfo_ViewModel _viewModel;

	public MovieInfo(MovieInfo_ViewModel viewModel)
	{
		InitializeComponent();

       _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}