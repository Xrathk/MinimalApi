using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    /// <summary>
    /// User model properties.
    /// </summary>
    public class User
    {
        public int Id { get; set; }

        [MaxLength(60)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(60)]
        public string LastName { get; set; }

        public DateTime DateCreated { get; set; }


    }
}
