var projectName = Assembly.GetExecutingAssembly().FullName?.Split(',')[0];
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var daprHttpPort = Environment.GetEnvironmentVariable("DAPR_HTTP_PORT") ?? "3600";
var daprGrpcPort = Environment.GetEnvironmentVariable("DAPR_GRPC_PORT") ?? "60000";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDaprClient(clientBuilder => clientBuilder
    .UseHttpEndpoint($"http://localhost:{daprHttpPort}")
    .UseGrpcEndpoint($"http://localhost:{daprGrpcPort}"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => $"{projectName} - {environment}")
    .WithName("Info");

app.MapGet("/uptime", () =>
    {
        var uptime = DateTime.UtcNow - Process.GetCurrentProcess().StartTime.ToUniversalTime();
        var uptimeInfo = new UptimeInfoResponse
        {
            TotalYears = (long) (uptime.TotalDays / 365.2425),
            TotalMonths = (long) (uptime.TotalDays / 12),
            TotalDays = (long) uptime.TotalDays,
            TotalHours = (long) uptime.TotalHours,
            TotalMinutes = (long) uptime.TotalMinutes,
            TotalSeconds = (long) uptime.TotalSeconds
        };
        return uptimeInfo;
    })
    .WithName("Uptime");

app.Run();