namespace MinimalApiProject.ApiEndpoints
{
    /// <summary>
    /// Adds jobSector API endpoints.
    /// </summary>
    public static class JobSectorEndpoints
    {

        /// <summary>
        /// Maps CRUD, get and additional operations to API endpoints for the jobSector entity.
        /// </summary>
        /// <param name="app">Current web application</param>
        public static void AddJobSectorEndpoints(this WebApplication app)
        {
            // Endpoints
            app.MapGet("/JobSectors", GetJobSectors);
            app.MapGet("/JobSectors/{id}", GetJobSector);
            app.MapPost("/JobSectors", InsertJobSector);
            app.MapPut("/JobSectors", UpdateJobSector);
            app.MapDelete("/JobSectors", DeleteJobSector);
        }

        /// <summary>
        /// Retrieve all jobSectors.
        /// </summary>
        /// <param name="jobSectorData">JobSector repository</param>
        /// <returns></returns>
        private static async Task<IResult> GetJobSectors(IJobSectorRepository jobSectorData)
        {
            try
            {
                return Results.Ok(await jobSectorData.GetAll());
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not retrieve jobSectors -- {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieve specific jobSector.
        /// </summary>
        /// <param name="id">JobSector ID</param>
        /// <param name="jobSectorData">JobSector repository</param>
        /// <returns></returns>
        private static async Task<IResult> GetJobSector(int id, IJobSectorRepository jobSectorData)
        {
            try
            {
                var results = await jobSectorData.Get(id);
                if (results == null) return Results.NotFound();
                return Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not retrieve jobSector -- {ex.Message}");
            }
        }

        /// <summary>
        /// Insert new jobSector.
        /// </summary>
        /// <param name="jobSector">New jobSector properties</param>
        /// <param name="jobSectorData">JobSector repository</param>
        /// <returns></returns>
        private static async Task<IResult> InsertJobSector(JobSector jobSector, IJobSectorRepository jobSectorData)
        {
            try
            {
                await jobSectorData.Insert(jobSector);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not create jobSector -- {ex.Message}");
            }
        }

        /// <summary>
        /// Update existing jobSector.
        /// </summary>
        /// <param name="jobSector">JobSector's new properties</param>
        /// <param name="jobSectorData">JobSector repository</param>
        /// <returns></returns>
        private static async Task<IResult> UpdateJobSector(JobSector jobSector, IJobSectorRepository jobSectorData)
        {
            try
            {
                await jobSectorData.Update(jobSector);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not update jobSector -- {ex.Message}");
            }
        }

        /// <summary>
        /// Delete a jobSector.
        /// </summary>
        /// <param name="id">JobSector ID</param>
        /// <param name="jobSectorData">JobSector repository</param>
        /// <returns></returns>
        private static async Task<IResult> DeleteJobSector(int id, IJobSectorRepository jobSectorData)
        {
            try
            {
                await jobSectorData.Delete(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not delete jobSector -- {ex.Message}");
            }
        }

    }
}
