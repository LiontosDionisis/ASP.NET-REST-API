using System.ComponentModel.DataAnnotations;

namespace RESTAPI.DTO
{
    public class UserPatchDTO
    {


        [StringLength(50, MinimumLength = 2, ErrorMessage = "Username should be betweem 2-50 characters")]
        public string? Username { get; set; }

        [StringLength(100, ErrorMessage = "Email should not exceed 100 characters")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string? Email { get; set; }

        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*\d)(?=.*?\W).{8,}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter , one digit and one special character")]
        public string? Password { get; set; }

    }
}
