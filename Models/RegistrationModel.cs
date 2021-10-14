using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechTreeMVCWebApplication.Models
{
    public class RegistrationModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [EmailAddress]
        [Display(Name ="User Name")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirm password")]

        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z]{1,2}[0-9][0-9A-Za-z]{0,1} {0,1}[0-9][A-Za-z]{2}$")]
        [Display(Name = "Post Code")]
        public string PostCode { get; set; }

        [Required]
        [RegularExpression(@"(\s*\(?0\d{4}\)?\s*\d{6}\s*)|(\s*\(?0\d{3}\)?\s*\d{3}\s*\d{4}\s*)")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public bool AcceptUserAgreement { get; set; }

        public string RegistrationInValid { get; set; }



    }
}
