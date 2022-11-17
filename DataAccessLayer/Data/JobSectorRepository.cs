using DataAccessLayer.DbAccess;
using Domain.Models;

namespace DataAccessLayer.Data
{
    /// <summary>
    /// Handles jobSector table operations.
    /// </summary>
    public class JobSectorRepository : IJobSectorRepository
    {
        private readonly ISqlDataAccess _db;

        /// <summary>
        /// Initializes jobSector repository.
        /// </summary>
        /// <param name="db">Sql Client for DB connection</param>
        public JobSectorRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        /// <summary>
        /// Retrieves all jobSectors from the database.
        /// </summary>
        /// <returns>A list of jobSectors</returns>
        public Task<IEnumerable<JobSector>> GetAll() =>
            _db.LoadData<JobSector, dynamic>("dbo.spAkisApi_getAll", new { TableName = "JobSectors" });

        /// <summary>
        /// Retrieves a jobSector from the database.
        /// </summary>
        /// <param name="id">JobSector ID</param>
        /// <returns>The jobSector with the corresponding ID (if existing)</returns>
        public async Task<JobSector> Get(int id)
        {
            var results = await _db.LoadData<JobSector, dynamic>("dbo.spAkisApi_getById", new { TableName = "JobSectors", Id = id });
            return results.FirstOrDefault();
        }

        /// <summary>
        /// Inserts a jobSector to the database.
        /// </summary>
        /// <param name="jobSector">The jobSector's properties</param>
        /// <returns></returns>
        public Task Insert(JobSector jobSector)
        {
            return _db.SaveData("dbo.spAkisApi_jobSectorInsert", new { jobSector.SectorName });
        }


        /// <summary>
        /// Updates an existing jobSector in the database.
        /// </summary>
        /// <param name="jobSector">The jobSector's new properties</param>
        /// <returns></returns>
        public Task Update(JobSector jobSector)
        {
            var oldJobSector = _db.LoadData<JobSector, dynamic>("dbo.spAkisApi_getById", new { TableName = "JobSectors", Id = jobSector.Id }).Result.FirstOrDefault();
            return _db.SaveData("dbo.spAkisApi_jobSectorUpdate", jobSector);
        }


        /// <summary>
        /// Deletes a jobSector from the database.
        /// </summary>
        /// <param name="id">The jobSector's Id</param>
        /// <returns></returns>
        public Task Delete(int id) =>
            _db.SaveData("dbo.spAkisApi_deleteById", new { TableName = "JobSectors", Id = id });

    }
}
