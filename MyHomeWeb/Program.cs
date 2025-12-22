var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Welcome to MyHomeWeb!");
app.MapGet("/hello/{name}", (string name) => $"Hello, {name}!");
app.MapGet("/api/status", () => new 
{ 
    message = "MyHomeWeb is running", 
    time = DateTime.Now 
});
app.Run();