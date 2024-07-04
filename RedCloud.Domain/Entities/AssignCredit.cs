using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
    public class AssignCredits
    {
        public int AssignCreditByRateId { get; set; }
        public DateOnly CreditDate { get; set; }
        public string TypeName { get; set; }
        public int Amount { get; set; }
        public int NoOfCredits { get; set; }
        public string Note { get; set; }
    }
}
