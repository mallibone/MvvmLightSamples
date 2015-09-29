using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using MvvmLightListBindings.Droid.Models;
using MvvmLightListBindings.Droid.Services;

namespace MvvmLightListBindings.Droid.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            People = new ObservableCollection<Person>();
        }

        public ObservableCollection<Person> People { get; }

        public async Task InitAsync()
        {
            if (People.Any()) return;

            var people = await InitPeopleList();
            People.Clear();
            foreach (var person in people)
            {
                People.Add(person);
            }
        }

        private async Task<IEnumerable<Person>> InitPeopleList()
        {
            const int personCount = 50;
            var people = new List<Person>(personCount);

            await Task.Run(() =>
            {
                for (int i = 0; i < personCount; ++i)
                {
                    var firstName = NameGenerator.GenRandomFirstName();
                    var lastName = NameGenerator.GenRandomLastName();
                    people.Add(new Person(firstName, lastName));
                }
            });

            return people;
        }
    }
}