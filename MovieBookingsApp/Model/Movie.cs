

namespace MovieBookingsApp
{
    public class Movie : BindableObject
    {
        private string _name;
        private int _lengthMin;
        private string _imageURI;

        public string Name
        {
            get => _name;
            set
            {
                if (_name == value) return;

                _name = value;
                OnPropertyChanged();
            }
        }

        public int LengthMin
        {
            get => _lengthMin;
            set
            {
                if (_lengthMin == value) return;

                _lengthMin = value;
                OnPropertyChanged();
            }
        }

        public string ImageURI
        {
            get => _imageURI;
            set
            {
                if (_imageURI == value) return;

                _imageURI = value;
                OnPropertyChanged();
            }
        }
    }
}
