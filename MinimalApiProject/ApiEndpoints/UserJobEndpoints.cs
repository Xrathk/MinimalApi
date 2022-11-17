namespace MinimalApiProject.ApiEndpoints
{
    /// <summary>
    /// Adds user job API endpoints.
    /// </summary>
    public static class UserJobEndpoints
    {

        /// <summary>
        /// Maps CRUD, get and additional operations to API endpoints for the user job entity.
        /// </summary>
        /// <param name="app">Current web application</param>
        public static void AddUserJobEndpoints(this WebApplication app)
        {
            // Endpoints
            app.MapGet("/UserJobs", GetUserJobs);
            app.MapGet("/UserJobs/{id}", GetUserJob);
            app.MapPost("/UserJobs", InsertUserJob);
            app.MapPut("/UserJobs", UpdateUserJob);
            app.MapDelete("/UserJobs", DeleteUserJob);
        }

        /// <summary>
        /// Retrieve all user jobs.
        /// </summary>
        /// <param name="userJobData">User job repository</param>
        /// <returns></returns>
        private static async Task<IResult> GetUserJobs(IUserJobRepository userJobData)
        {
            try
            {
                return Results.Ok(await userJobData.GetAll());
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not retrieve user jobs -- {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieve specific user job.
        /// </summary> 
        /// <param name="id">Job ID</param>
        /// <param name="userJobData">User job repository</param>
        /// <returns></returns>
        private static async Task<IResult> GetUserJob(int id, IUserJobRepository userJobData)
        {
            try
            {
                var results = await userJobData.Get(id);
                if (results == null) return Results.NotFound();
                return Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not retrieve user job -- {ex.Message}");
            }
        }


        /// <summary>
        /// Insert new user job.
        /// </summary>
        /// <param name="userJob">New user job properties</param>
        /// <param name="userJobData">User job repository</param>
        /// <returns></returns>
        private static async Task<IResult> InsertUserJob(UserJob userJob, IUserJobRepository userJobData)
        {
            try
            {
                await userJobData.Insert(userJob);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not create user job -- {ex.Message}");
            }
        }

        /// <summary>
        /// Update existing user job.
        /// </summary>
        /// <param name="userJob">User job's new properties</param>
        /// <param name="userJobData">User job repository</param>
        /// <returns></returns>
        private static async Task<IResult> UpdateUserJob(UserJob userJob, IUserJobRepository userJobData)
        {
            try
            {
                await userJobData.Update(userJob);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not update user job -- {ex.Message}");
            }
        }

        /// <summary>
        /// Delete a user job entry.
        /// </summary>
        /// <param name="id">Entry ID</param>
        /// <param name="userJobData">User job repository</param>
        /// <returns></returns>
        private static async Task<IResult> DeleteUserJob(int id, IUserJobRepository userJobData)
        {
            try
            {
                await userJobData.Delete(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not delete user job -- {ex.Message}");
            }
        }

    }
}
