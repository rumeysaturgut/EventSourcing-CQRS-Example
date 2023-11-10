using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventSourcingExample.Model;


namespace EventSourcingExample.Commands.Response
{
    class ChangePersonAgeCommandResponse
    {
        public int OldAge { get; set; }
        public Person Person { get; set; }
    }
}
