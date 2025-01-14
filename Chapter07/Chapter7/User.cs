namespace Chapter7
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; } = new Address();
    }

    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
    }
}
