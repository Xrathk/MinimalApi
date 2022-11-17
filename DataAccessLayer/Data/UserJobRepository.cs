using DataAccessLayer.DbAccess;
using Domain.Models;
using Validators.SimpleModelValidators;

namespace DataAccessLayer.Data
{
    /// <summary>
    /// Handles user job table operations.
    /// </summary>
    public class UserJobRepository : IUserJobRepository
    {
        private readonly ISqlDataAccess _db;

        /// <summary>
        /// Initializes user job repository.
        /// </summary>
        /// <param name="db">Sql Client for DB connection</param>
        public UserJobRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        /// <summary>
        /// Retrieves all users jobs from the database.
        /// </summary>
        /// <returns>A list of user Jobs</returns>
        public Task<IEnumerable<UserJob>> GetAll() =>
            _db.LoadData<UserJob, dynamic>("dbo.spAkisApi_getAll", new { TableName = "UserJobs" });

        /// <summary>
        /// Retrieves a user job entry from the database.
        /// </summary>
        /// <param name="id">Entry ID</param>
        /// <returns>The entry with the corresponding ID (if existing)</returns>
        public async Task<UserJob> Get(int id)
        {
            var results = await _db.LoadData<UserJob, dynamic>("dbo.spAkisApi_getById", new { TableName = "UserJobs", Id = id });
            return results.FirstOrDefault();
        }

        /// <summary>
        /// Inserts user job to the database.
        /// </summary>
        /// <param name="userJob">The user's job</param>
        /// <returns></returns>
        public Task Insert(UserJob userJob)
        {
            userJob = UserJobValidation.Validate(userJob);
            return _db.SaveData("dbo.spAkisApi_userJobInsert", new { userJob.Title, userJob.Company, userJob.SectorId, userJob.YearsOfExperience, userJob.Salary, userJob.WorkModel, userJob.UserInfoId });
        }


        /// <summary>
        /// Updates existing user job in the database.
        /// </summary>
        /// <param name="userJob">The user's new job</param>
        /// <returns></returns>
        public Task Update(UserJob userJob)
        {
            userJob = UserJobValidation.Validate(userJob);
            return _db.SaveData("dbo.spAkisApi_userJobUpdate", userJob);
        }


        /// <summary>
        /// Deletes a user job entry from the database.
        /// </summary>
        /// <param name="id">The job's Id</param>
        /// <returns></returns>
        public Task Delete(int id) =>
            _db.SaveData("dbo.spAkisApi_deleteById", new { TableName = "UserJobs", Id = id });

    }
}
