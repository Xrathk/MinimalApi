using DataAccessLayer.DbAccess;
using Domain.Models;

namespace DataAccessLayer.Data
{
    /// <summary>
    /// Handles user address table operations.
    /// </summary>
    public class UserAddressRepository : IUserAddressRepository
    {
        private readonly ISqlDataAccess _db;

        /// <summary>
        /// Initializes user address repository.
        /// </summary>
        /// <param name="db">Sql Client for DB connection</param>
        public UserAddressRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        /// <summary>
        /// Retrieves all users addresss from the database.
        /// </summary>
        /// <returns>A list of user addresses</returns>
        public Task<IEnumerable<UserAddress>> GetAll() =>
            _db.LoadData<UserAddress, dynamic>("dbo.spAkisApi_getAll", new { TableName = "UserAddresses" });

        /// <summary>
        /// Retrieves a user address entry from the database.
        /// </summary>
        /// <param name="id">Entry ID</param>
        /// <returns>The entry with the corresponding ID (if existing)</returns>
        public async Task<UserAddress> Get(int id)
        {
            var results = await _db.LoadData<UserAddress, dynamic>("dbo.spAkisApi_getById", new { TableName = "UserAddresses", Id = id });
            return results.FirstOrDefault();
        }

        /// <summary>
        /// Inserts user address to the database.
        /// </summary>
        /// <param name="userAddress">The user's address</param>
        /// <returns></returns>
        public Task Insert(UserAddress userAddress)
        {
            return _db.SaveData("dbo.spAkisApi_userAddressInsert", new { userAddress.PlanetId, userAddress.Country, userAddress.Address, userAddress.AreaCode, userAddress.UserInfoId });
        }


        /// <summary>
        /// Updates existing user address in the database.
        /// </summary>
        /// <param name="userAddress">The user's new address</param>
        /// <returns></returns>
        public Task Update(UserAddress userAddress)
        {
            return _db.SaveData("dbo.spAkisApi_userAddressUpdate", userAddress);
        }


        /// <summary>
        /// Deletes a user address entry from the database.
        /// </summary>
        /// <param name="id">The address's Id</param>
        /// <returns></returns>
        public Task Delete(int id) =>
            _db.SaveData("dbo.spAkisApi_deleteById", new { TableName = "UserAddresses", Id = id });

    }
}
