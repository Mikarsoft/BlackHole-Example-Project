namespace BlackHoleTutorial.DTOs
{
    //A Class to Update specific columns on the Customer table
    public class CustomerUpdateLocation
    {
        public string ZipCode { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
    }
}
