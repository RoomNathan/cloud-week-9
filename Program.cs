// Create a new HostBuilder. This is the starting point for building the function app.
var host = new HostBuilder()
    // Configure the host to run Azure Functions
    .ConfigureFunctionsWebApplication()
    // Configure the dependency injection container
    .ConfigureServices(services =>
    {
        // Register CosmosClient as a singleton
        // The connection string is retrieved from an environment variable
        services.AddSingleton<CosmosClient>(new CosmosClient(Environment.GetEnvironmentVariable("CosmosDBConnectionString")));
        // Register CloudBlobClient as a singleton
        services.AddSingleton<BlobServiceClient>(new BlobServiceClient(Environment.GetEnvironmentVariable("BlobStorageConnectionString")));

        // Register SqlConnection as a singleton
        services.AddSingleton<SqlConnection>(new SqlConnection(Environment.GetEnvironmentVariable("SqlConnectionString")));

        // Register IPersonRepository interface with its implementation PersonRepository
        // This allows for dependency injection of IPersonRepository

        services.AddSingleton<IFoodRepo, FoodRepo>();

        // Register IPersonService interface with its implementation PersonService
        // This allows for dependency injection of IPersonService
        services.AddSingleton<IFoodService, FoodService>();

        // You can add more service registrations here as needed
    })
    // Build the host
    .Build();

// Run the host. This starts the Azure Functions runtime.
host.Run();
