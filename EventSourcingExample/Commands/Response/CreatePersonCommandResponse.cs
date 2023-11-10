using EventSourcingExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingExample.Commands.Response
{
    class CreatePersonCommandResponse
    {
        public Person Person { get; set; }

    }
}
