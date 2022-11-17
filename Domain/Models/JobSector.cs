using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    /// <summary>
    /// Job sector model. Each job belongs in a job sector.
    /// </summary>
    public class JobSector
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string SectorName { get; set; }
    }
}
