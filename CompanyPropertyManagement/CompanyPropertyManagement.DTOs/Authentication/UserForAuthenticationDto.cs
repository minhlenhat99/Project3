﻿using System.ComponentModel.DataAnnotations;

namespace CompanyPropertyManagement.DTOs.Authentication
{
    public class UserForAuthenticationDto
    {
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password name is required")]
        public string Password { get; set; }
    }
}