namespace MinimalApiProject.ApiEndpoints
{
    /// <summary>
    /// Adds user additional info API endpoints.
    /// </summary>
    public static class UserAdditionalInfoEndpoints
    {

        /// <summary>
        /// Maps CRUD, get and additional operations to API endpoints for the user additional info entity.
        /// </summary>
        /// <param name="app">Current web application</param>
        public static void AddUserAdditionalInfoEndpoints(this WebApplication app)
        {
            // Endpoints
            app.MapGet("/UsersAdditionalInfo", GetUserAdditionalInfos);
            app.MapGet("/UsersAdditionalInfo/{id}", GetUserAdditionalInfo);
            app.MapPost("/UsersAdditionalInfo", InsertUserAdditionalInfo);
            app.MapPut("/UsersAdditionalInfo", UpdateUserAdditionalInfo);
            app.MapDelete("/UsersAdditionalInfo", DeleteUserAdditionalInfo);
        }

        /// <summary>
        /// Retrieve all user infos.
        /// </summary>
        /// <param name="userInfoData">User additional info repository</param>
        /// <returns></returns>
        private static async Task<IResult> GetUserAdditionalInfos(IUserAdditionalInfoRepository userInfoData)
        {
            try
            {
                return Results.Ok(await userInfoData.GetAll());
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not retrieve user additional infos -- {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieve specific user additional info.
        /// </summary> 
        /// <param name="id">Info ID</param>
        /// <param name="userInfoData">User additional info repository</param>
        /// <returns></returns>
        private static async Task<IResult> GetUserAdditionalInfo(int id, IUserAdditionalInfoRepository userInfoData)
        {
            try
            {
                var results = await userInfoData.Get(id);
                if (results == null) return Results.NotFound();
                return Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not retrieve user additional info -- {ex.Message}");
            }
        }


        /// <summary>
        /// Insert new user info.
        /// </summary>
        /// <param name="userInfo">New user info properties</param>
        /// <param name="userInfoData">User additional info repository</param>
        /// <returns></returns>
        private static async Task<IResult> InsertUserAdditionalInfo(UserAdditionalInfo userInfo, IUserAdditionalInfoRepository userInfoData)
        {
            try
            {
                await userInfoData.Insert(userInfo);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not create user additional info -- {ex.Message}");
            }
        }

        /// <summary>
        /// Update existing user info.
        /// </summary>
        /// <param name="userInfo">User info's new properties</param>
        /// <param name="userInfoData">User additional info repository</param>
        /// <returns></returns>
        private static async Task<IResult> UpdateUserAdditionalInfo(UserAdditionalInfo userInfo, IUserAdditionalInfoRepository userInfoData)
        {
            try
            {
                await userInfoData.Update(userInfo);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not update user additional info -- {ex.Message}");
            }
        }

        /// <summary>
        /// Delete a user info entry.
        /// </summary>
        /// <param name="id">Entry ID</param>
        /// <param name="userInfoData">User additional info repository</param>
        /// <returns></returns>
        private static async Task<IResult> DeleteUserAdditionalInfo(int id, IUserAdditionalInfoRepository userInfoData)
        {
            try
            {
                await userInfoData.Delete(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not delete user additional info -- {ex.Message}");
            }
        }

    }
}
