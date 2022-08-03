﻿using System.ComponentModel.DataAnnotations;

namespace SnaggleAPI.Models
{
    public class UserRegisterRequest
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty;
        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
