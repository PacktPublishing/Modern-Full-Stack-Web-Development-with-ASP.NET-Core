namespace Chapter7;

public class User
{
    public string Name { get; set; } = default!;
    public int Age { get; set; }
    public Address Address { get; set; } = new Address();
}

public class Address
{
    public string City { get; set; } = default!;
    public string Street { get; set; } = default!;
    public string State { get; set; } = default!;
}
