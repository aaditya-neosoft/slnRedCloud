using RedCloud.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace RedCloud.ViewModel
{
    public class GetByRateIdForAssignCreditVM
    {
        //[Key]
        public int RateAssignCreditId { get; set; }
        public int OrgID { get; set; }
        public int TypeId { get; set; }
        public string InboundSMS { get; set; }
        public string OutboundSMS { get; set; }
        public string InboundMMS { get; set; }
        public string OutboundMMS { get; set; }
        public string MonthlyNumber { get; set; }
        public string Users { get; set; }
        //public AssignCreditByRate? AssignCreditByRate { get; set; }
        //public RateAssignCredit? RateAssignCredit { get; set; }
        public List<OrganizationAdmin>? OrganizationAdmin { get; set; }
        public List<CreditsType>? CreditsType { get; set; }
        public List<AssignCredits>? AssignCredits { get; set; }
    }
}
