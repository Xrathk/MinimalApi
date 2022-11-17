using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    /// <summary>
    /// Planet model. Each user originates from a planet.
    /// </summary>
    public class Planet
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string PlanetName { get; set; }
    }
}
