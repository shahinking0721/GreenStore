﻿using System.ComponentModel.DataAnnotations;

namespace EShop.ViewModels.Authenticate
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name ="UserName")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
