
using System.Net.Http.Json;

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

    public class Screening
    {
        public string ID { get; set; }
        public string FilmID { get; set; }
        public string RoomID { get; set; }
        public DateTime StartTime { get; set; }
    }

    public static class Model
    {
        private const string Branch = "Development_1";

        private static UserInfo _userInfo = new UserInfo();
        private static bool _isSignedIn;

        private static List<Movie> _movieList = new List<Movie>();
        private static List<Screening> _screeningList = new List<Screening>();
        private static List<Screening> _bookings = new List<Screening>();


        private static HttpClient _httpClient;

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
        public static async Task<UserInfo> GetUserInfo()
        {
            // TODO call database 

            _userInfo.FirstName = "JonTest";
            _userInfo.LastName = "KellyTest";
            _userInfo.Email = "test@gmail.com";

            return _userInfo;
        }

        /// <summary>
        /// Returns a list of Movie objects containing details about each movie. 
        /// </summary>
        /// <returns></returns>
        public static async Task<List<Movie>> GetMovies()
        {
            // TODO call database 

            if (_httpClient == null)
                _httpClient = new HttpClient();

            if (_movieList.Count != 0)
                _movieList.Clear();

            var response = await _httpClient.GetAsync("https://raw.githubusercontent.com/JonKelly92/MovieBookingApp/" + Branch + "/Movies.json");
            if (response.IsSuccessStatusCode)
            {
                _movieList = await response.Content.ReadFromJsonAsync(MovieContext.Default.ListMovie);
            }

            return _movieList;
        }

        /// <summary>
        /// Returns a list of Screening objects containing details about each screening.
        /// </summary>
        /// <returns></returns>
        public static IList<Screening> GetScreeningList()
        {
            if (_screeningList.Count == 0)
            {
                // TODO : Fill up the list 

                var screening = new Screening();

                // 20th
                screening.StartTime = new DateTime(2023, 8, 20, 14, 30, 0);
                _screeningList.Add(screening);

                var screening2 = new Screening();
                screening2.StartTime = new DateTime(2023, 8, 20, 17, 0, 0);
                _screeningList.Add(screening2);

                var screening3 = new Screening();
                screening3.StartTime = new DateTime(2023, 8, 20, 15, 30, 0);
                _screeningList.Add(screening3);

                //21st
                var screening4 = new Screening();
                screening4.StartTime = new DateTime(2023, 8, 21, 14, 0, 0);
                _screeningList.Add(screening4);
                //screening.StartTime = new DateTime(2023, 8, 21, 14, 30, 0);
                //_screeningList.Add(screening);
                //screening.StartTime = new DateTime(2023, 8, 21, 19, 30, 0);
                //_screeningList.Add(screening);

                ////23rd
                var screening5 = new Screening();
                screening5.StartTime = new DateTime(2023, 8, 23, 12, 30, 0);
                _screeningList.Add(screening5);
                //screening.StartTime = new DateTime(2023, 8, 23, 13, 45, 0);
                //_screeningList.Add(screening);
                //screening.StartTime = new DateTime(2023, 8, 23, 14, 30, 0);
                //_screeningList.Add(screening);

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
