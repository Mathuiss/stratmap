using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using stratmap.Models;
using stratmap.Services;

namespace stratmap.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    private CountryService _countryService;

    public string ExMessage { get; set; }

    public List<Country> Countries { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        _countryService = new CountryService();
        ExMessage = string.Empty;
        Countries = new();
    }

    public void OnGet()
    {
        try
        {
            Countries = _countryService.GetCountries();
        }
        catch (NullReferenceException)
        {
            // Mo countries in list
            ExMessage = "No Countries found... Check the countries.json file.";
            Countries = new();
        }
    }
}
