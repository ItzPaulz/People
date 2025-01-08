using People.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace People.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private PersonRepository _paullarreaRepo;
        private string _nameInput;
        private string _feedbackMessage;
        private ObservableCollection<Person> _personList;

        public string NameInput
        {
            get => _nameInput;
            set
            {
                _nameInput = value;
                OnPropertyChanged(nameof(NameInput));
            }
        }

       
        public string FeedbackMessage
        {
            get => _feedbackMessage;
            set
            {
                _feedbackMessage = value;
                OnPropertyChanged(nameof(FeedbackMessage));
            }
        }

        public ObservableCollection<Person> PersonList
        {
            get => _personList;
            set
            {
                _personList = value;
                OnPropertyChanged(nameof(PersonList));
            }
        }

        public ICommand AddPersonCommand { get; }
        public ICommand LoadPeopleCommand { get; }
        public ICommand RemovePersonCommand { get; }

        public MainPageViewModel()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "paullarrea_people.db");
            _paullarreaRepo = new PersonRepository(dbPath);
            PersonList = new ObservableCollection<Person>();

            AddPersonCommand = new Command(AddPerson);
            LoadPeopleCommand = new Command(LoadPeople);
            RemovePersonCommand = new Command<Person>(RemovePerson);

            LoadPeople();
        }

        private void AddPerson()
        {
            _paullarreaRepo.AddNewPerson(NameInput);
            FeedbackMessage = _paullarreaRepo.StatusMessage;
            LoadPeople();
        }

        private void LoadPeople()
        {
            PersonList.Clear();
            var people = _paullarreaRepo.GetAllPeople();
            foreach (var person in people)
            {
                PersonList.Add(person);
            }
        }

        private void RemovePerson(Person person)
        {
            _paullarreaRepo.DeletePerson(person.Id);
            FeedbackMessage = _paullarreaRepo.StatusMessage;
            LoadPeople();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
       
    }
}