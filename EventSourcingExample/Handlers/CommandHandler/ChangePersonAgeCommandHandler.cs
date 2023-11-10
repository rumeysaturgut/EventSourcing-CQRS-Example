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
    class ChangePersonAgeCommandHandler
    {
        public ChangePersonAgeCommandResponse ChangeAge(ChangePersonAgeCommandRequest request)
        {
            Person person = PersonSource.PersonList.FirstOrDefault(p => p.Id == request.Id);
            int oldAge = person.Age;
            person.ChangeAge(request.Age);
            return new ChangePersonAgeCommandResponse
            {
                OldAge = oldAge,
                Person = person
            };
        }
    }
}
