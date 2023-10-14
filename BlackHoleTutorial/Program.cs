using BlackHole.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CAdd your Connection string here
string SqlServerConnectionString = "Data Source=[Host],[Port];Database=[Database Name];User Id=[User Name];Password=[Password];TrustServerCertificate=[Optional]";

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
