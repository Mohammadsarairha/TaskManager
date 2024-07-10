﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Dto
{
    public class LoginDto
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}