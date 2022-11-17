namespace MinimalApiProject.ApiEndpoints
{
    /// <summary>
    /// Adds planet API endpoints.
    /// </summary>
    public static class PlanetEndpoints
    {

        /// <summary>
        /// Maps CRUD, get and additional operations to API endpoints for the planet entity.
        /// </summary>
        /// <param name="app">Current web application</param>
        public static void AddPlanetEndpoints(this WebApplication app)
        {
            // Endpoints
            app.MapGet("/Planets", GetPlanets);
            app.MapGet("/Planets/{id}", GetPlanet);
            app.MapPost("/Planets", InsertPlanet);
            app.MapPut("/Planets", UpdatePlanet);
            app.MapDelete("/Planets", DeletePlanet);
        }

        /// <summary>
        /// Retrieve all planets.
        /// </summary>
        /// <param name="planetData">Planet repository</param>
        /// <returns></returns>
        private static async Task<IResult> GetPlanets(IPlanetRepository planetData)
        {
            try
            {
                return Results.Ok(await planetData.GetAll());
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not retrieve planets -- {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieve specific planet.
        /// </summary>
        /// <param name="id">Planet ID</param>
        /// <param name="planetData">Planet repository</param>
        /// <returns></returns>
        private static async Task<IResult> GetPlanet(int id, IPlanetRepository planetData)
        {
            try
            {
                var results = await planetData.Get(id);
                if (results == null) return Results.NotFound();
                return Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not retrieve planet -- {ex.Message}");
            }
        }

        /// <summary>
        /// Insert new planet.
        /// </summary>
        /// <param name="planet">New planet properties</param>
        /// <param name="planetData">Planet repository</param>
        /// <returns></returns>
        private static async Task<IResult> InsertPlanet(Planet planet, IPlanetRepository planetData)
        {
            try
            {
                await planetData.Insert(planet);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not create planet -- {ex.Message}");
            }
        }

        /// <summary>
        /// Update existing planet.
        /// </summary>
        /// <param name="planet">Planet's new properties</param>
        /// <param name="planetData">Planet repository</param>
        /// <returns></returns>
        private static async Task<IResult> UpdatePlanet(Planet planet, IPlanetRepository planetData)
        {
            try
            {
                await planetData.Update(planet);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not update planet -- {ex.Message}");
            }
        }

        /// <summary>
        /// Delete a planet.
        /// </summary>
        /// <param name="id">Planet ID</param>
        /// <param name="planetData">Planet repository</param>
        /// <returns></returns>
        private static async Task<IResult> DeletePlanet(int id, IPlanetRepository planetData)
        {
            try
            {
                await planetData.Delete(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not delete planet -- {ex.Message}");
            }
        }

    }
}
