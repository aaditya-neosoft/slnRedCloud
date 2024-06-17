using RedCloud.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace RedCloud.ViewModel
{
    public class RedCloudAdminProfileVM
    {
        public int RedCloudAdminUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        //[Required(ErrorMessage = "Password is required")]
        //[StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        //[DataType(DataType.Password)]
        public string Password { get; set; }

        //[Required(ErrorMessage = "Confirm Password is required")]
        //[StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        //[DataType(DataType.Password)]
        //[Compare("Password")]
        //public string? ConfirmPassword { get; set; }
    }
}
