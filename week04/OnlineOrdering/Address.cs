public class Address
{
    private string _streetAddress;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        _streetAddress = street;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    public string GetCompleteAddress()
    {
        return $"{_streetAddress}\n{_city}, {_stateOrProvince}\n{_country}";
    }

    public bool IsInUSA()
    {
        return _country.ToUpper() == "USA";
    }

    public string StreetAddress => _streetAddress;
    public string City => _city;
    public string StateOrProvince => _stateOrProvince;
    public string Country => _country;
}