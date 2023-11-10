using EventSourcingExample.Commands.Request;
using EventSourcingExample.Commands.Response;
using EventSourcingExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingExample.Handlers.CommandHandler
{
    class CreatePersonCommandHandler
    {
        public CreatePersonCommandResponse CreatePerson(CreatePersonCommandRequest request)
        {
            PersonSource.PersonList.Add(new Person(request.Id, request.Name, request.Age));
            return new CreatePersonCommandResponse
            {
                Person = PersonSource.PersonList.Last()
            };
        }
    }
}
