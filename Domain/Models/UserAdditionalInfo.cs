using Domain.Converters;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    /// <summary>
    /// User additional info model properties.
    /// </summary>
    public class UserAdditionalInfo
    {
        public int Id { get; set; }

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public float Height { get; set; }

        public float Weight { get; set; }

        [Required]
        public int PlanetOfOriginId { get; set; }

        [MaxLength(90)]
        public string CountryOfOrigin { get; set; }

        [Required]
        public int UserId { get; set; }

        // Navigation properties
        [JsonIgnore]
        public List<UserAddress> Addresses = new List<UserAddress>();

        [JsonIgnore]
        public List<UserJob> Jobs = new List<UserJob>();

    }
}
