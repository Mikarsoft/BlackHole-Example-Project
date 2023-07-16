using BlackHole.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string Postgres = "Host={YourHost};Port={YourPort};Database={DatabaseName};User Id={YourUserName};Password={YourPassword}";

string devmode = "dev";

//BlackHole Basic Configuration
builder.Services.SuperNova(settings => settings.IsDeveloperMode(devmode=="dev").AddDatabase(connection => connection.UseNpgSql(Postgres, "eshop")));

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
