namespace MinimalApiProject.ApiEndpoints
{
    /// <summary>
    /// Adds user address API endpoints.
    /// </summary>
    public static class UserAddressEndpoints
    {

        /// <summary>
        /// Maps CRUD, get and additional operations to API endpoints for the user address entity.
        /// </summary>
        /// <param name="app">Current web application</param>
        public static void AddUserAddressEndpoints(this WebApplication app)
        {
            // Endpoints
            app.MapGet("/UserAddresses", GetUserAddresses);
            app.MapGet("/UserAddresses/{id}", GetUserAddress);
            app.MapPost("/UserAddresses", InsertUserAddress);
            app.MapPut("/UserAddresses", UpdateUserAddress);
            app.MapDelete("/UserAddresses", DeleteUserAddress);
        }

        /// <summary>
        /// Retrieve all user addresses.
        /// </summary>
        /// <param name="userAddressData">User address repository</param>
        /// <returns></returns>
        private static async Task<IResult> GetUserAddresses(IUserAddressRepository userAddressData)
        {
            try
            {
                return Results.Ok(await userAddressData.GetAll());
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not retrieve user address -- {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieve specific user address.
        /// </summary> 
        /// <param name="id">Address ID</param>
        /// <param name="userAddressData">User address repository</param>
        /// <returns></returns>
        private static async Task<IResult> GetUserAddress(int id, IUserAddressRepository userAddressData)
        {
            try
            {
                var results = await userAddressData.Get(id);
                if (results == null) return Results.NotFound();
                return Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not retrieve user address -- {ex.Message}");
            }
        }


        /// <summary>
        /// Insert new user address.
        /// </summary>
        /// <param name="userAddress">New user address properties</param>
        /// <param name="userAddressData">User address repository</param>
        /// <returns></returns>
        private static async Task<IResult> InsertUserAddress(UserAddress userAddress, IUserAddressRepository userAddressData)
        {
            try
            {
                await userAddressData.Insert(userAddress);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not create user address -- {ex.Message}");
            }
        }

        /// <summary>
        /// Update existing user address.
        /// </summary>
        /// <param name="userAddress">User address's new properties</param>
        /// <param name="userAddressData">User address repository</param>
        /// <returns></returns>
        private static async Task<IResult> UpdateUserAddress(UserAddress userAddress, IUserAddressRepository userAddressData)
        {
            try
            {
                await userAddressData.Update(userAddress);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not update user address -- {ex.Message}");
            }
        }

        /// <summary>
        /// Delete a user address entry.
        /// </summary>
        /// <param name="id">Entry ID</param>
        /// <param name="userAddressData">User address repository</param>
        /// <returns></returns>
        private static async Task<IResult> DeleteUserAddress(int id, IUserAddressRepository userAddressData)
        {
            try
            {
                await userAddressData.Delete(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem($"Could not delete user address -- {ex.Message}");
            }
        }

    }
}
