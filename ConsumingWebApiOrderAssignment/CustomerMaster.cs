using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumingWebApiOrderAssignment
{
    public class CustomerMaster
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
    }
}
