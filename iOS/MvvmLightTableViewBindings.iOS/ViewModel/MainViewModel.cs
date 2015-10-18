using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmLightTableViewBindings.iOS.Models;
using MvvmLightTableViewBindings.iOS.Services;

namespace MvvmLightTableViewBindings.iOS.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            AddPersonCommand = new RelayCommand(AddPerson);
            RemovePersonCommand = new RelayCommand(RemovePerson);
        }

        public RelayCommand AddPersonCommand { get; set; }
        public RelayCommand RemovePersonCommand { get; set; }
        public ObservableCollection<Person> People { get; private set; }

        public async Task InitAsync()
        {
            if (People != null) return;

            People = new ObservableCollection<Person>();
            var people = await InitPeopleList();
            foreach (var person in people)
            {
                People.Add(person);
            }
        }

        private async Task<IEnumerable<Person>> InitPeopleList()
        {
            const int personCount = 5;
            var people = new List<Person>(personCount);

            await Task.Run(() =>
            {
                for (int i = 0; i < personCount; ++i)
                {
                    people.Add(GeneratePerson());
                }
            });

            return people;
        }

        private void AddPerson()
        {
            People.Add(GeneratePerson());
        }

        private Person GeneratePerson()
        {
            var firstName = NameGenerator.GenRandomFirstName();
            var lastName = NameGenerator.GenRandomLastName();
            return new Person(firstName, lastName);
        }

        private void RemovePerson()
        {
            if (!People.Any()) return;
            People.Remove(People.Last());
        }
    }
}