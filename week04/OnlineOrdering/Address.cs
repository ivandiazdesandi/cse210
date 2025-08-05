public class Address
{
    private string _streetAddress;
    private string _city;
    private string _state;
    private string _country;

    public Address(string streetAddress, string city, string state, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _state = state;
        _country = country;
    }

    public string StreetAddress
    {
        get { return _streetAddress; }
    }

    public string City
    {
        get { return _city; }
    }

    public string State
    {
        get { return _state; }
    }

    public string Country
    {
        get { return _country; }
    }

    public bool IsInUSA()
    {
        return _country == "USA";
    }

    public string FullAddress()
    {
        return _streetAddress + "\n" +
               _city + ", " + _state + "\n" +
               _country;
    }
}