using BlackHole.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string SqlServerConnectionString = "Data Source=127.0.0.1,1455;Database=BlackHoleTestingDb;User Id=sa;Password=glo7646.-;TrustServerCertificate=True";

//string devmode = "dev";

//BlackHole Basic Configuration
builder.Services.SuperNova(settings => settings.AutomaticUpdate().IsDeveloperMode(false).AddDatabase(connection => connection.UseSqlServer(SqlServerConnectionString)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
