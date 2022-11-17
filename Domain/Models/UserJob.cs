using Domain.Enums;

namespace Domain.Models
{
    /// <summary>
    /// Job information for user. A user can have many jobs.
    /// </summary>
    public class UserJob
    {
        public int Id { get; set; }

        public string Title { get; set; }   

        public string Company { get; set; }

        public int SectorId { get; set; }

        public int YearsOfExperience { get; set; }

        public float Salary { get; set; }

        public WorkModel WorkModel { get; set; }

        public int UserInfoId { get; set; }
    }
}
