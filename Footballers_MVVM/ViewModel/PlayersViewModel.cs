using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Footballers_MVVM.Model;
using Footballers_MVVM.ViewModel.BaseClass;


namespace Footballers_MVVM.ViewModel
{
    internal class PlayersViewModel : ViewModelBase
    {
        private Players _players = new Players();
        public ObservableCollection<Player> ListOfPlayers
        {
            get => _players.ListOfPlayers;
            set
            {
                _players.ListOfPlayers = value;
                OnPropertyChanged(nameof(ListOfPlayers));
            }
        }

        private string _firstName = "Wprowadź imię";
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string _lastName = "Wprowadź nazwisko";
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private int _age = 15;
        public int Age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        private int _weight = 55;
        public int Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }

        private int _id = -1;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public IEnumerable<string> AgeRange
        {
            get
            {
                for (int i = 15; i <= 55; i++)
                {
                    yield return i.ToString();
                }
            }
        }

        private ICommand _add;
        public ICommand Add
        {
            get
            {
                if (_add == null)
                {
                    _add = new RelayCommand(x => { _players.AddPlayer(_firstName, _lastName, _age, _weight); Reset(); }, x => (!string.IsNullOrEmpty(_firstName) && !_firstName.Equals("Wprowadź imię") && !string.IsNullOrEmpty(_lastName) && !_lastName.Equals("Wprowadź nazwisko")));
                }
                return _add;
            }
        }

        private ICommand _edit;
        public ICommand Edit
        {
            get
            {
                if (_edit == null)
                {
                    _edit = new RelayCommand(x => { _players.EditPlayer(_firstName, _lastName, _age, _weight, _id); Reset(); }, x => (!string.IsNullOrEmpty(_firstName) && !_firstName.Equals("Wprowadź imię") && !string.IsNullOrEmpty(_lastName) && !_lastName.Equals("Wprowadź nazwisko") && _id >= 0));
                }
                return _edit;
            }
        }

        private ICommand _loadData;
        public ICommand LoadData
        {
            get
            {
                if (_loadData == null)
                {
                    _loadData = new RelayCommand(x => { FirstName = ListOfPlayers[Id].FirstName; LastName = ListOfPlayers[Id].LastName; Age = ListOfPlayers[Id].Age; Weight = ListOfPlayers[Id].Weight; }, x => _id >= 0);
                }
                return _loadData;
            }
        }

        private ICommand _remove;
        public ICommand Remove
        {
            get
            {
                if (_remove == null)
                {
                    _remove = new RelayCommand(x => { _players.RemovePlayer(_id); Reset(); }, x => _id >= 0);
                }
                return _remove;
            }
        }

        private ICommand _clearFirstName;
        public ICommand ClearFirstName
        {
            get
            {
                if (_clearFirstName == null)
                {
                    _clearFirstName = new RelayCommand(x => { if (FirstName.Equals("Wprowadź imię")) FirstName = ""; });
                }
                return _clearFirstName;
            }
        }

        private ICommand _clearLastName;
        public ICommand ClearLastName
        {
            get
            {
                if (_clearLastName == null)
                {
                    _clearLastName = new RelayCommand(x => { if (LastName.Equals("Wprowadź nazwisko")) LastName = ""; });
                }
                return _clearLastName;
            }
        }

        private ICommand _save;
        public ICommand Save
        {
            get
            {
                if (_save == null)
                {
                    _save = new RelayCommand(x => _players.Save());
                }
                return _save;
            }
        }

        private void Reset()
        {
            FirstName = "Wprowadź imię";
            LastName = "Wprowadź nazwisko";
            Age = 15;
            Weight = 55;
            Id = -1;
        }
    }
}
