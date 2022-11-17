using MinimalApiProject.ApiEndpoints;
using MinimalApiProject.Startup;

// Instantiating app builder
var builder = WebApplication.CreateBuilder(args);

// Configure JSON options.
builder.Services.ConfigureJsonOptions();

// Add services to the container (dependency injection)
builder.Services.RegisterBasicServices();

// Configure swagger for AkisApi
builder.Services.ConfigureSwagger();

// Data access and repositories
builder.Services.RegisterDataAccess();

// Building application with services
var app = builder.Build();

// Adding swagger to application for Dev environment
app.RegisterSwagger();

// Add misc middleware
app.AddMiddleware();

// Add endpoints
app.AddEndpoints();

// Run application
app.Run();

