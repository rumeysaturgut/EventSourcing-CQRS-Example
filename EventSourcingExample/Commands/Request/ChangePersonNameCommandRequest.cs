using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingExample.Commands.Request
{
    public class ChangePersonNameCommandRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
