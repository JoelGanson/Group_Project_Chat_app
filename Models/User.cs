using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group_Project_Chat_app.Models
{
    public class User
    {
        [Key] // Set as primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Disable autoincriment, allowing for String to be used
        [StringLength(24,ErrorMessage="Username cannot be longer than 24 characters")] // Limit username size
        [Required(ErrorMessage ="A username is required")] // Require username
        public required string Username { get; set; }
        [Required(ErrorMessage ="A password is required")]
        public required string Password { get; set; }
    }
}
