namespace MovieBookingsApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(Account), typeof(Account));
        Routing.RegisterRoute(nameof(Bookings), typeof(Bookings));
        Routing.RegisterRoute(nameof(GetTickets), typeof(GetTickets));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(MovieInfo), typeof(MovieInfo));
        Routing.RegisterRoute(nameof(SignUp), typeof(SignUp));
    }
}
