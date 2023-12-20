using Desafio.Api.Entities;

namespace Desafio.Api.Repositories;

public interface ICityRepository
{
    Task<IEnumerable<CityModel>> GetAllAsync();
    Task<CityModel> GetForIdAsync(int id);
    Task<CityModel> GetForCityAsync(string city);
    Task<CityModel> GetForStateAsync(string state);
    Task<CityModel> AddCityAsync(CityModel city);
    Task<CityModel> UpCityAsync(int id, CityModel city);
    Task<bool> DeleteCityAsync(int id);
}