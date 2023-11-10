using EventSourcingExample.Commands.Request;
using EventSourcingExample.Commands.Response;
using EventSourcingExample.Events.Interface;
using EventSourcingExample.Handlers.CommandHandler;
using EventSourcingExample.Handlers.QueryHandler;
using EventSourcingExample.Queries.Request;
using EventSourcingExample.Queries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingExample.Events
{
    class EventBroker
    {
        //Oluşan event'leri depolayacağımız koleksiyon.
        public List<IEvent> allEvents = new();
        //Uygulamada gelen Command isteklerinde devreye girecek event tanımlanıyor.
        public event EventHandler<object> Commands;
        //Uygulamada gelen Query isteklerinde devreye girecek event tanımlanıyor.
        public event EventHandler<object> Queries;
        public EventBroker()
        {
            //'Commands' isimli 'EventHandler'a aşağıdaki metot tanımlanıyor.
            this.Commands += (sender, command) =>
            {
                //Eğer gelen Command 'ChangeAgePersonCommandRequest' türündense
                if (command is ChangePersonAgeCommandRequest req1)
                {
                    ChangePersonAgeCommandHandler handler = new ChangePersonAgeCommandHandler();
                    ChangePersonAgeCommandResponse response = handler.ChangeAge(req1);
                    //İlgili isteğe uygun event olan 'AgeChangedEvent' nesnesi event deposuna atılıyor.
                    this.allEvents.Add(new AgeChangedEvent(response.Person, response.OldAge, req1.Age));
                }
                //Eğer gelen Command 'ChangeNamePersonCommandRequest' türündense
                else if (command is ChangePersonNameCommandRequest req2)
                {
                    ChangePersonNameCommandHandler handler = new ChangePersonNameCommandHandler();
                    ChangePersonNameCommandResponse response = handler.ChangeName(req2);
                    //İlgili isteğe uygun event olan 'NameChangedEvent' nesnesi event deposuna atılıyor.
                    this.allEvents.Add(new NameChangedEvent(response.Person, response.OldName, req2.Name));
                }
                //Eğer gelen Command 'CreatePersonCommandRequest' türündense
                else if (command is CreatePersonCommandRequest req3)
                {
                    CreatePersonCommandHandler handler = new CreatePersonCommandHandler();
                    CreatePersonCommandResponse response = handler.CreatePerson(req3);
                    //İlgili isteğe uygun event olan 'PersonCreatedEvent' nesnesi event deposuna atılıyor.
                    this.allEvents.Add(new PersonCreatedEvent(response.Person));
                }
            };
            //'Queries' isimli 'EventHandler'a aşağıdaki metot tanımlanıyor.
            this.Queries += (sender, query) =>
            {
                //Eğer gelen Query 'GetPersonQueryRequest' türündense
                if (query is GetPersonByIdQueryRequest req1)
                {
                    GetPersonByIdQueryHandler handler = new GetPersonByIdQueryHandler();
                    GetPersonByIdQueryResponse response = handler.GetPerson(req1);
                    Console.WriteLine($"Id\tName\tAge");
                    Console.WriteLine($"{response.Person.Id}\t{response.Person.Name}\t{response.Person.Age}\n***********");
                }
                //Eğer gelen Query 'GetAllPersonQueryRequest' türündense
                else if (query is GetAllPersonQueryRequest req2)
                {
                    GetAllPersonQueryHandler handler = new GetAllPersonQueryHandler();
                    List<GetAllPersonQueryResponse> response = handler.GetAll(req2);
                    Console.WriteLine($"Id\tName\tAge");
                    response.ForEach(person => Console.WriteLine($"{person.Id}\t{person.Name}\t{person.Age}"));
                    Console.WriteLine("***********");
                }
            };
        }
        //Client'ın 'Command' gönderebilmesi için kullanacağı metot.
        public void Command(object command)
            => Commands(this, command);
        //Client'ın 'Query' gönderebilmesi için kullanacağı metot.
        public void Query(object query)
            => Queries(this, query);
        //Tüm event'i yazdırabilmek/okuyabilmek için kullanılacak metot.
        public void WriteAllEvent()
            => allEvents.ForEach(@event => Console.WriteLine($"{@event.ToString()}\n***********"));
    }
}
