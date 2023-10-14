using BlackHole.Entities;

namespace BlackHoleTutorial.GenericObjects
{
    public class StringValueGenerator : IBHValueGenerator<string>
    {
        public string GenerateValue()
        {
            return DateTime.Now.ToString();
        }
    }
}
