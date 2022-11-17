using DataAccessLayer.DbAccess;
using Domain.Models;
using Validators.SimpleModelValidators;

namespace DataAccessLayer.Data
{
    /// <summary>
    /// Handles user additional info table operations.
    /// </summary>
    public class UserAdditionalInfoRepository : IUserAdditionalInfoRepository
    {
        private readonly ISqlDataAccess _db;

        /// <summary>
        /// Initializes user additional info repository.
        /// </summary>
        /// <param name="db">Sql Client for DB connection</param>
        public UserAdditionalInfoRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        /// <summary>
        /// Retrieves all users additional infoes from the database.
        /// </summary>
        /// <returns>A list of user additional infoes</returns>
        public Task<IEnumerable<UserAdditionalInfo>> GetAll() =>
            _db.LoadData<UserAdditionalInfo, dynamic>("dbo.spAkisApi_getAll", new { TableName = "UsersAdditionalInfo" });

        /// <summary>
        /// Retrieves a user additional info entry from the database.
        /// </summary>
        /// <param name="id">Entry ID</param>
        /// <returns>The entry with the corresponding ID (if existing)</returns>
        public async Task<UserAdditionalInfo> Get(int id)
        {
            var results = await _db.LoadData<UserAdditionalInfo, dynamic>("dbo.spAkisApi_getById", new { TableName = "UsersAdditionalInfo", Id = id });
            return results.FirstOrDefault();
        }

        /// <summary>
        /// Inserts user additional info to the database.
        /// </summary>
        /// <param name="userInfo">The user's additional info</param>
        /// <returns></returns>
        public Task Insert(UserAdditionalInfo userInfo)
        {
            userInfo = UserAdditionalInfoValidation.Validate(userInfo);
            return _db.SaveData("dbo.spAkisApi_userAdditionalInfoInsert", new { userInfo.DateOfBirth, userInfo.Gender, userInfo.Height, userInfo.Weight, userInfo.PlanetOfOriginId, userInfo.CountryOfOrigin, userInfo.UserId });
        }
            

        /// <summary>
        /// Updates existing user info in the database.
        /// </summary>
        /// <param name="userInfo">The user's new additional info</param>
        /// <returns></returns>
        public Task Update(UserAdditionalInfo userInfo) 
        {
            userInfo = UserAdditionalInfoValidation.Validate(userInfo);
            return _db.SaveData("dbo.spAkisApi_userAdditionalInfoUpdate", userInfo);
        }
            

        /// <summary>
        /// Deletes a user additional info entry from the database.
        /// </summary>
        /// <param name="id">The info's Id</param>
        /// <returns></returns>
        public Task Delete(int id) =>
            _db.SaveData("dbo.spAkisApi_deleteById", new { TableName = "UsersAdditionalInfo", Id = id });

    }
}
