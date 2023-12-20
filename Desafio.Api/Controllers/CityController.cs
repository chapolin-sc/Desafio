using Desafio.Api.Entities;
using Desafio.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CityController : ControllerBase
{
    private readonly ILogger<CityController> _logger;
    private readonly ICityRepository _city;



    public CityController(ILogger<CityController> logger, ICityRepository city)
    {
        _logger = logger;
        _city = city;
    }



    [HttpGet]
    public async Task<IEnumerable<CityModel>> GetAsync()
    {
        var cit = await _city.GetAllAsync();
        return cit;
    }


    [HttpGet("{id}")]
    public async Task<CityModel> GetAsync(int id)
    {
        var cit = await _city.GetForIdAsync(id);
        return cit;
    }


    [HttpPost]
    public async Task<CityModel> PostAsync([FromForm]CityModel city)
    {
        await _city.AddCityAsync(city);
        return city;
    }   


    [HttpPut("{id}")]
    public async Task<CityModel> PutAsync(int id, [FromForm]CityModel city)
    {
        await _city.UpCityAsync(id, city);
        return city;
    } 


    [HttpDelete("{id}")]
    public async Task<bool> DeleteAsync(int id)
    {
        await _city.DeleteCityAsync(id);
        return true;
    }
}
