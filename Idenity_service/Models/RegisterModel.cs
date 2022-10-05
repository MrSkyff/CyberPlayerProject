using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Idenity_service.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User name is not set!")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email is not set!")]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is not set!")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Pass", ErrorMessage = "Password do not match.")]
        public string? ConfirmPassword { get; set; }
    }
}
