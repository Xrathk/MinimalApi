using DataAccessLayer.DbAccess;
using Domain.Models;

namespace DataAccessLayer.Data
{
    /// <summary>
    /// Handles planet table operations.
    /// </summary>
    public class PlanetRepository : IPlanetRepository
    {
        private readonly ISqlDataAccess _db;

        /// <summary>
        /// Initializes planet repository.
        /// </summary>
        /// <param name="db">Sql Client for DB connection</param>
        public PlanetRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        /// <summary>
        /// Retrieves all planets from the database.
        /// </summary>
        /// <returns>A list of planets</returns>
        public Task<IEnumerable<Planet>> GetAll() =>
            _db.LoadData<Planet, dynamic>("dbo.spAkisApi_getAll", new { TableName = "Planets" });

        /// <summary>
        /// Retrieves a planet from the database.
        /// </summary>
        /// <param name="id">Planet ID</param>
        /// <returns>The planet with the corresponding ID (if existing)</returns>
        public async Task<Planet> Get(int id)
        {
            var results = await _db.LoadData<Planet, dynamic>("dbo.spAkisApi_getById", new { TableName = "Planets", Id = id });
            return results.FirstOrDefault();
        }

        /// <summary>
        /// Inserts a planet to the database.
        /// </summary>
        /// <param name="planet">The planet's properties</param>
        /// <returns></returns>
        public Task Insert(Planet planet)
        {
            return _db.SaveData("dbo.spAkisApi_planetInsert", new { planet.PlanetName });
        }


        /// <summary>
        /// Updates an existing planet in the database.
        /// </summary>
        /// <param name="planet">The planet's new properties</param>
        /// <returns></returns>
        public Task Update(Planet planet)
        {
            var oldPlanet = _db.LoadData<Planet, dynamic>("dbo.spAkisApi_getById", new { TableName = "Planets", Id = planet.Id }).Result.FirstOrDefault();
            return _db.SaveData("dbo.spAkisApi_planetUpdate", planet);
        }


        /// <summary>
        /// Deletes a planet from the database.
        /// </summary>
        /// <param name="id">The planet's Id</param>
        /// <returns></returns>
        public Task Delete(int id) =>
            _db.SaveData("dbo.spAkisApi_deleteById", new { TableName = "Planets", Id = id });

    }
}
