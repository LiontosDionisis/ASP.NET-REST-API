﻿using RESTAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace RESTAPI.DTO
{
    public class UserDTO
    {
        [NotNull]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Usersname should be between 2-50 characters")]
        public string? UserName { get; set; }

        [StringLength(100, ErrorMessage = "Email should not exceed 100 characters")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string? Email { get; set; }

        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*\d)(?=.*?\W).{8,}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter , one digit and one special character")]
        public string? Password { get; set; }

        [StringLength(50, ErrorMessage = "Firstname should not exceed 50 characters")]
        public string? Firstname { get; set; }

        [StringLength(50, ErrorMessage = "Lastname should not exceed 50 characters")]
        public string? Lastname { get; set; }

        public UserRole? UserRole {  get; set; }
    }
}