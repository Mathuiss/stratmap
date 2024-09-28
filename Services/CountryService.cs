using System.Text.Json;
using System.Text.Json.Nodes;
using System.Collections.Generic;
using stratmap.Models;

namespace stratmap.Services;

public class CountryService
{
    private readonly string _countryFile;

    public CountryService()
    {
        _countryFile = Path.Combine(Environment.CurrentDirectory, "data", "country.json");
    }

    public List<Country> GetCountries()
    {
        string fileContent = File.ReadAllText(_countryFile);
        JsonNode? json = JsonNode.Parse(fileContent);
        var dict = JsonSerializer.Deserialize<Dictionary<string, string>>(json) ?? throw new NullReferenceException();

        var countries = new List<Country>();

        foreach (string key in dict.Keys)
        {
            countries.Add(new Country(key, dict[key]));
        }

        return countries;
    }
}