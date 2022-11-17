using DataAccessLayer.DbAccess;
using Domain.Models;

namespace DataAccessLayer.Data
{
    /// <summary>
    /// Handles user table operations.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly ISqlDataAccess _db;

        /// <summary>
        /// Initializes user repository.
        /// </summary>
        /// <param name="db">Sql Client for DB connection</param>
        public UserRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        /// <summary>
        /// Retrieves all users from the database.
        /// </summary>
        /// <returns>A list of users</returns>
        public Task<IEnumerable<User>> GetAll() =>
            _db.LoadData<User, dynamic>("dbo.spAkisApi_getAll", new { TableName = "Users" });

        /// <summary>
        /// Retrieves a user from the database.
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>The user with the corresponding ID (if existing)</returns>
        public async Task<User> Get(int id)
        {
            var results = await _db.LoadData<User, dynamic>("dbo.spAkisApi_getById", new { TableName = "Users", Id = id });
            return results.FirstOrDefault();
        }

        /// <summary>
        /// Inserts a user to the database.
        /// </summary>
        /// <param name="user">The user's properties</param>
        /// <returns></returns>
        public Task Insert(User user)
        {
            user.DateCreated = DateTime.Now;
            return _db.SaveData("dbo.spAkisApi_userInsert", new { user.FirstName, user.LastName, user.DateCreated });
        }
            

        /// <summary>
        /// Updates an existing user in the database.
        /// </summary>
        /// <param name="user">The user's new properties</param>
        /// <returns></returns>
        public Task Update(User user)
        {
            var oldUser = _db.LoadData<User, dynamic>("dbo.spAkisApi_getById", new { TableName = "Users", Id = user.Id }).Result.FirstOrDefault();
            user.DateCreated = oldUser.DateCreated;
            return _db.SaveData("dbo.spAkisApi_userUpdate", user);
        }


        /// <summary>
        /// Deletes a user from the database.
        /// </summary>
        /// <param name="id">The user's Id</param>
        /// <returns></returns>
        public Task Delete(int id) =>
            _db.SaveData("dbo.spAkisApi_deleteById", new { TableName = "Users", Id = id });

    }
}
