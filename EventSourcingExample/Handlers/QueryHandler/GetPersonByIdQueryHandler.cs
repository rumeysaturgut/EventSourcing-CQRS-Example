using EventSourcingExample.Model;
using EventSourcingExample.Queries.Request;
using EventSourcingExample.Queries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingExample.Handlers.QueryHandler
{
    class GetPersonByIdQueryHandler
    {
        public GetPersonByIdQueryResponse GetPerson(GetPersonByIdQueryRequest request)
        {
            Person person = PersonSource.PersonList.FirstOrDefault(p => p.Id == request.Id);
            return new GetPersonByIdQueryResponse
            {
                Person = person
            };
        }
    }
}
