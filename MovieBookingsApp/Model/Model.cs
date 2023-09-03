
namespace MovieBookingsApp
{
    public struct UserInfo
    {
        public string FirstName;
        public string LastName;
        public string Email;

        public UserInfo()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
        }
    }

    public struct Movie
    {
        public string Name;
        public int LengthMin;
        public string ImageURI;
    }

    public struct Screening
    {
        public Movie Movie;
        public DateTime StartTime;
    }

    public static class Model
    {
        private static UserInfo _userInfo = new UserInfo();
        private static bool _isSignedIn;

        private static List<Movie> _movieList = new List<Movie>();
        private static List<Screening> _screeningList = new List<Screening>();
        private static List<Screening> _bookings = new List<Screening>();


        /// <summary>
        /// Checks the database to see if the email already exists. If not created a new account. If it does then logs in the user. Returns true on success
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool SignUp(string firstName, string lastName, string email)
        {
            _userInfo.FirstName = firstName;
            _userInfo.LastName = lastName;
            _userInfo.Email = email;

            // currently it's not possible to fail signing up but in the future this will be interacting with a database and will be able to fail 
            _isSignedIn = true;
            return true;
        }

        /// <summary>
        /// Checks if the user is signed in.
        /// </summary>
        /// <returns></returns>
        public static bool IsSignedIn() { return _isSignedIn; }

        /// <summary>
        /// returns a UserInfo object, if user is not logged in strings will be empty. 
        /// </summary>
        /// <returns></returns>
        public static UserInfo GetUserInfo() { return _userInfo; }

        /// <summary>
        /// Returns a list of Movie objects containing details about each movie. 
        /// </summary>
        /// <returns></returns>
        public static List<Movie> GetMovies()
        {
            if (_movieList.Count == 0)
            {
                // TODO : Fill up the list 
            }

            return _movieList;
        }

        /// <summary>
        /// Returns a list of Screening objects containing details about each screening.
        /// </summary>
        /// <returns></returns>
        public static List<Screening> GetScreeningList()
        {
            if( _screeningList.Count == 0)
            {
                // TODO : Fill up the list 
            }

            return _screeningList;
        }

        /// <summary>
        /// Attempts to create a new booking using the Screening passed in. Returns false if the user is not logged in or if the booking has already been created.
        /// </summary>
        /// <param name="screening"></param>
        /// <returns></returns>
        public static bool CreateBooking(Screening screening)
        {
            if (!_isSignedIn)
            {
                // TODO : Notify the user they should log in 
                return false;
            }

            if (_bookings.Contains(screening))
            {
                // TODO : Notifiy the user they already created this booking
                return false;
            }

            _bookings.Add(screening);

            return true;
        }

        /// <summary>
        /// Returns a list of Screenings the user has booked. 
        /// </summary>
        /// <returns></returns>
        public static List<Screening> GetBookings()
        {
            return _bookings;
        }
    }
}
