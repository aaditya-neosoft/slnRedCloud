﻿using System.ComponentModel.DataAnnotations;

namespace RedCloud.Models
{
    public class RedCloudUserVM
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a valid email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter mobile number")]
        public string MobileNumber { get; set; }

        public bool IsActive { get; set; }
    }
}
 