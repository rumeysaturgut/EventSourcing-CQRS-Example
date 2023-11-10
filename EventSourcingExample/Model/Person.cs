using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingExample.Model
{
    record Person
    {
        public int Id { get; init; }
        public string Name { get; private set; }
        public int Age { get; private set; }

        public Person(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public void ChangeName(string name)
        => Name = name;
        public void ChangeAge(int age)
        => Age = age;
    }

    class PersonSource
    {
        public static List<Person> PersonList { get; } = new()
        {
            new(1, "Rumeysa", 26),
            new(2, "Şevval", 27),
            new(3, "Mehmet", 29),
            new(4, "Oğuzhan", 18)
        };
    }
}
