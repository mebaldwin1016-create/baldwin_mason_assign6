var builder = DistributedApplication.CreateBuilder(args);

var server = builder.AddDotnetProject("server", "../baldwinmason_assign6.Server/baldwinmason_assign6.Server.csproj")
    .WithHttpHealthCheck("/health")
    .WithExternalHttpEndpoints();

var webfrontend = builder.AddViteApp("webfrontend", "../frontend")
    .WithReference(server)
    .WaitFor(server);

server.PublishWithContainerFiles(webfrontend, "wwwroot");

builder.Build().Run();
