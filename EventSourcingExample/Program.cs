using EventSourcingExample.Commands.Request;
using EventSourcingExample.Events;
using EventSourcingExample.Queries.Request;

class Program
{
    static void Main(string[] args)
    {
        EventBroker eventBroker = new EventBroker();
        eventBroker.Command(new CreatePersonCommandRequest { Id = 5, Age = 30, Name = "Funda" });
        eventBroker.Command(new CreatePersonCommandRequest { Id = 6, Age = 34, Name = "İbrahim" });
        eventBroker.Command(new ChangePersonAgeCommandRequest { Id = 2, Age = 25 });
        eventBroker.Command(new ChangePersonAgeCommandRequest { Id = 2, Age = 28 });
        eventBroker.Command(new ChangePersonNameCommandRequest { Id = 4, Name = "Serdar" });
        eventBroker.WriteAllEvent();
        eventBroker.Query(new GetAllPersonQueryRequest());
        eventBroker.Query(new GetPersonByIdQueryRequest() { Id = 3 });
    }
}