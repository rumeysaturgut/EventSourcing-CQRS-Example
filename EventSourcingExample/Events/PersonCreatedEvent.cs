using EventSourcingExample.Events.Interface;
using EventSourcingExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingExample.Events
{
    class PersonCreatedEvent : IEvent
    {
        public Person Person { get; set; }

        public PersonCreatedEvent(Person person)
        {
            Person = person;
        }

        public override string ToString()
        => $"Yeni personel {Person.Id} id değerinde eklenmiştir.";
    }
}
