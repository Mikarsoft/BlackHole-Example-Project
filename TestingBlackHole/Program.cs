using BlackHole.Configuration; //Required to Initialize Black Hole
using BlackHole.Enums; //Required to declear sql type
using TestingBlackHole.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connection String. Change it to lead at your Host
string MySql = "Server=[Your Server};Port={Your Port};Database={Iput a name of a non-existing Database}; Uid={Your Sql User}; Pwd={Your Sql Password}";

// *** Initialize BlackHole *** Basic Easy COnfiguration. For more Advanced Configurations Read the Documentation
//Make sure to choose the correct Sql Type
//If LogsPath is unset or Empty string, the default logs path is in Current User's Folder/BlackHole/Logs
builder.Services.SuperNova(new BlackHoleBaseConfig {ConnectionString=MySql,SqlType = BHSqlTypes.MySql, LogsPath = string.Empty });

//Put in Comment the Above Line and Uncomment the next to SetUp an SqLite Database in Current User's Folder/BlackHole
//builder.Services.SuperNovaLite("testDatabase");

//Also you can setup SqLite with the regular SuperNova. Make sure to give Permissions to your App to write/read in the inserted File Path
//builder.Services.SuperNova(new BlackHoleBaseConfig { ConnectionString = "C://{full file path}", SqlType = BHSqlTypes.SqlLite, LogsPath = string.Empty });


var app = builder.Build();

//In this class i have made a stored view that we can use later in a Service
//without calculating all the parameters again. Stored Views can speed up your Application.
var storeView = new StoreViews();
storeView.CreateAndStoreView();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
