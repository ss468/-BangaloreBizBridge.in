using System.ComponentModel.DataAnnotations;
using InvestHub.Core.Entities;

namespace InvestHub.Core.Dto
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
        public string LinkedIn { get; set; }
        public string StageofBusiness { get; set; }
        public string Website { get; set; }
        public string TypeOfInvestor { get; set; }
        public string InvestmentIntrest { get; set; }
        public int? InvestmentRange { get; set; }
        public string InvestorDetails { get; set; }

        [Required(ErrorMessage = "User type is required")]
        public UserType UserType { get; set; }
    }
}
