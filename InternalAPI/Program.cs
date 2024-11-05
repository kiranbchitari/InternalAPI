var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Map the controllers
app.MapControllers();

// Set the application to listen on the port defined by Vercel
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080"; // Default to 8080 if PORT is not set
app.Urls.Add($"http://*:{port}"); // Listen on the specified port

app.Run();
