namespace stratmap.Models;

public class Country
{
    public string Id { get; set; }

    public string Name { get; set; }

    public Country()
    {
        Id = "";
        Name = "";
    }

    public Country(string id, string name)
    {
        Id = id;
        Name = name;
    }
}