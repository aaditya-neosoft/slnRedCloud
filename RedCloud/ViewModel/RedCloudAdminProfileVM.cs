using RedCloud.Domain.Entities;

namespace RedCloud.ViewModel
{
    public class RedCloudAdminProfileVM
    {
        public int RedCloudAdminUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string? Password { get; set; }
        public bool IsActive { get; set; } = true;
        public int? ResellerAdminUserId { get; set; }
        public virtual ResellerAdminUser ResellerAdminUsers { get; set; }
    }
}
