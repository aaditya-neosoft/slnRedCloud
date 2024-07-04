using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
    public class AssignCreditByRate
    {
        public int AssignCreditByRateId { get; set; }
        public DateOnly CreditDate { get; set; }
        public int TypeId { get; set; }
        public int Amount { get; set; }
        public int NoOfCredits { get; set; }
        public int Expiration { get; set; }
        public string Note { get; set; }
        public int RateAssignCreditId { get; set; }
        public CreditsType CreditsType { get; set; }
        public RateAssignCredit RateAssignCredit { get; set; }
    }
}
