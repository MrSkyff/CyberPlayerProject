using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Idenity_service.Models
{
    public class LoginModel
    {
        [DataType(DataType.EmailAddress, ErrorMessage = "Email not valid!")]
        [Required(ErrorMessage = "Error: email is not set!")]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Error: password is not set!")]
        public string? Password { get; set; }
    }
}
