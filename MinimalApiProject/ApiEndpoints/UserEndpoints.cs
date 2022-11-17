namespace MinimalApiProject.ApiEndpoints
{
    /// <summary>
    /// Adds user API endpoints.
    /// </summary>
    public static class UserEndpoints
    {
        
        /// <summary>
        /// Maps CRUD, get and additional operations to API endpoints for the user entity.
        /// </summary>
        /// <param name="app">Current web application</param>
        public static void AddUserEndpoints(this WebApplication app)
        {
            // Endpoints
            app.MapGet("/Users", GetUsers);
            app.MapGet("/Users/{id}", GetUser);
            app.MapPost("/Users", InsertUser);
            app.MapPut("/Users", UpdateUser);
            app.MapDelete("/Users", DeleteUser);
        }

        /// <summary>
        /// Retrieve all users.
        /// </summary>
        /// <param name="userData">User repository</param>
        /// <returns></returns>
        private static async Task<IResult> GetUsers(IUserRepository userData)
        {
            try
            {
                return Results.Ok(await userData.GetAll());
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not retrieve users -- {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieve specific user.
        /// </summary>
        /// <param name="id">User ID</param>
        /// <param name="userData">User repository</param>
        /// <returns></returns>
        private static async Task<IResult> GetUser(int id, IUserRepository userData)
        {
            try
            {
                var results = await userData.Get(id);
                if (results == null) return Results.NotFound();
                return Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not retrieve user -- {ex.Message}");
            }
        }

        /// <summary>
        /// Insert new user.
        /// </summary>
        /// <param name="user">New user properties</param>
        /// <param name="userData">User repository</param>
        /// <returns></returns>
        private static async Task<IResult> InsertUser(User user, IUserRepository userData)
        {
            try
            {
                await userData.Insert(user);    
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not create user -- {ex.Message}");
            }
        }

        /// <summary>
        /// Update existing user.
        /// </summary>
        /// <param name="user">User's new properties</param>
        /// <param name="userData">User repository</param>
        /// <returns></returns>
        private static async Task<IResult> UpdateUser(User user, IUserRepository userData)
        {
            try
            {
                await userData.Update(user);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not update user -- {ex.Message}");
            }
        }

        /// <summary>
        /// Delete a user.
        /// </summary>
        /// <param name="id">User ID</param>
        /// <param name="userData">User repository</param>
        /// <returns></returns>
        private static async Task<IResult> DeleteUser(int id, IUserRepository userData)
        {
            try
            {
                await userData.Delete(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not delete user -- {ex.Message}");
            }
        }

    }
}
