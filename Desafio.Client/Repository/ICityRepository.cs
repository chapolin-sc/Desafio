using Desafio.Client.Model;

namespace Desafio.Client.Repository;

public interface ICityRepository
{
    Task<IEnumerable<CityModel>> GetAll();
    Task<CityModel> GetForId(int id);
    Task<CityModel> GetForCity(string city);
    Task<CityModel> GetForState(string state);
    Task<CityModel> AddCity(CityModel city);
    Task<CityModel> UpCity(int id, CityModel city);
    Task<bool> DeleteCity(int id);
}