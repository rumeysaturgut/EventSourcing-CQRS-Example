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
    class GetAllPersonQueryHandler
    {
        public List<GetAllPersonQueryResponse> GetAll(GetAllPersonQueryRequest request)
        {
            return PersonSource.PersonList.Select(person => new GetAllPersonQueryResponse
            {
                Id = person.Id,
                Age = person.Age,
                Name = person.Name
            }).ToList();
        }
    }
}
