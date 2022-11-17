using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    /// <summary>
    /// Address information for a user. A user can have many addresses.
    /// </summary>
    public class UserAddress
    {
        public int Id { get; set; } 
        public int PlanetId { get; set; }

        [MaxLength(90)]
        public string Country { get; set; }

        [MaxLength(128)]
        public string Address { get; set; }

        [MaxLength(20)]
        public string AreaCode { get; set; }

        public int UserInfoId { get; set; }

    }
}
