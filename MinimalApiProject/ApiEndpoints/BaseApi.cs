namespace MinimalApiProject.ApiEndpoints
{
    /// <summary>
    /// Base API class. Categorizes the endpoints by entity and adds them to the application
    /// </summary>
    public static class BaseApi
    {

        /// <summary>
        /// Add endpoints by entity to the web application.
        /// </summary>
        /// <param name="app">Current web application</param>
        public static void AddEndpoints(this WebApplication app)
        {
            app.AddUserEndpoints(); // User entity
            app.AddUserAdditionalInfoEndpoints(); // User additional info entity
            app.AddPlanetEndpoints(); // Planet entity
            app.AddJobSectorEndpoints(); // Job sector entity
            app.AddUserJobEndpoints(); // User job entity
            app.AddUserAddressEndpoints(); // User address entity
        }
    }
}
