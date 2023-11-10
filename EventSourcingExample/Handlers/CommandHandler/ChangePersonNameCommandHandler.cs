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
    class ChangePersonNameCommandHandler
    {
        public ChangePersonNameCommandResponse ChangeName(ChangePersonNameCommandRequest request)
        {
            Person person = PersonSource.PersonList.FirstOrDefault(p => p.Id == request.Id);
            string oldName = person.Name;
            person.ChangeName(request.Name);
            return new ChangePersonNameCommandResponse
            {
                OldName = oldName,
                Person = person
            };
        }
    }
}
