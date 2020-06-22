using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageUsersAPI.Data.Entities
{
    public class UserEntity
    {

        [Column("UserID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // [Required(ErrorMessage = "User ID is required")]
        public int UserId { get; set; }

        [Column("FirstName")]
        // [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Column("LastName")]
        // [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Column("Email")]
        // [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Column("Phone")]
        // [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }
    }
}