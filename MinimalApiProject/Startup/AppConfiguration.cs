namespace MinimalApiProject.Startup
{
    /// <summary>
    /// Sets up basic app properties for the AkisApi application.
    /// </summary>
    public static class AppConfiguration
    {

        /// <summary>
        /// Configures useful middleware for AkisApi application.
        /// </summary>
        /// <param name="app">Current web application</param>
        /// <returns>Configured web application</returns>
        public static WebApplication AddMiddleware(this WebApplication app)
        {
            // Redirect HTTP requests
            app.UseHttpsRedirection();

            // Returns new app configuration
            return app;
        }


        /// <summary>
        /// Configures middleware for AkisApi application based on app environment.
        /// </summary>
        /// <param name="app">Current web application</param>
        /// <returns>Configured web application</returns>
        public static WebApplication RegisterSwagger(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                // Use swagger for dev environment
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Returns new app configuration
            return app;
        }
    }
}
