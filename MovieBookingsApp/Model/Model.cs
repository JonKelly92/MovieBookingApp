﻿
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
            if(_httpClient == null)
                _httpClient = new HttpClient();

            if (_movieList.Count != 0)
                _movieList.Clear();

            var response = await _httpClient.GetAsync("https://raw.githubusercontent.com/JonKelly92/MovieBookingApp/Development_1/Movies.json");
            if (response.IsSuccessStatusCode)
            {
                _movieList = await response.Content.ReadFromJsonAsync(MovieContext.Default.ListMovie);
            }

            // TODO call database 

            //string baseURI = "https://raw.githubusercontent.com/JonKelly92/MovieBookingApp/Development_1/.github/images/";

            //var movie = new Movie();
            //movie.Name = "After Everything";
            //movie.LengthMin = 0;
            //movie.ImageURI = baseURI + "AfterEverything.png";
            //_movieList.Add(movie);

            //movie.Name = "A Haunting in Venice";
            //movie.LengthMin = 0;
            //movie.ImageURI = baseURI + "AHauntingInVenice.png";
            //_movieList.Add(movie);

            //movie.Name = "Barbie";
            //movie.LengthMin = 0;
            //movie.ImageURI = baseURI + "Barbie.png";
            //_movieList.Add(movie);

            //movie.Name = "Demeter";
            //movie.LengthMin = 0;
            //movie.ImageURI = baseURI + "Demeter.png";
            //_movieList.Add(movie);

            //movie.Name = "Grand Turismo";
            //movie.LengthMin = 0;
            //movie.ImageURI = baseURI + "GrandTurismo.png";
            //_movieList.Add(movie);

            //movie.Name = "My Big Fat Greek Wedding 3";
            //movie.LengthMin = 0;
            //movie.ImageURI = baseURI + "GreekWedding.png";
            //_movieList.Add(movie);

            //movie.Name = "The Meg 2";
            //movie.LengthMin = 0;
            //movie.ImageURI = baseURI + "Meg2.png";
            //_movieList.Add(movie);

            //movie.Name = "The Nun 2";
            //movie.LengthMin = 0;
            //movie.ImageURI = baseURI + "Nun.png";
            //_movieList.Add(movie);

            //movie.Name = "Oppenheimer";
            //movie.LengthMin = 0;
            //movie.ImageURI = baseURI + "Oppenheimer.png";
            //_movieList.Add(movie);

            //movie.Name = "The Equalizer 3";
            //movie.LengthMin = 0;
            //movie.ImageURI = baseURI + "TheEqualizer3.png";
            //_movieList.Add(movie);

            //movie.Name = "TMNT";
            //movie.LengthMin = 0;
            //movie.ImageURI = baseURI + "TMNT.png";
            //_movieList.Add(movie);

            return _movieList;
        }

        /// <summary>
        /// Returns a list of Screening objects containing details about each screening.
        /// </summary>
        /// <returns></returns>
        public static List<Screening> GetScreeningList()
        {
            if (_screeningList.Count == 0)
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
