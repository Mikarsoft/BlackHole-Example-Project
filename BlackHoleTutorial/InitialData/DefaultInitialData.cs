using BlackHole.Services;

namespace BlackHoleTutorial.InitialData
{
    public class DefaultInitialData : IBHInitialData
    {
        //Initialize default data of your database with this method
        public void DefaultData(BHDataInitializer initializer)
        {
            initializer.ExecuteCommand(@"insert into eshop.""Users"" (""Username"", ""Password"", ""Inactive"") Values ('username1','password1',0)");
            //initializer.CommandsFromFile("");
        }
    }
}
