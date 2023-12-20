using System.Net.Http.Json;
using Desafio.Client.Model;

namespace Desafio.Client.Repository;

public class CityRepository : ICityRepository
{
    public readonly HttpClient _http;
    

    public CityRepository(HttpClient http)
    {
        _http = http;
    }


    public async Task<CityModel> AddCity(CityModel city)
    {
        try
        {
            using(MultipartFormDataContent content = new MultipartFormDataContent())
            {
                content.Add(new StringContent(city.City), "city.City");
                content.Add(new StringContent(city.State), "city.State");

                HttpResponseMessage cit = await _http.PostAsync("", content);
            };
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("1: " + ex.Message);
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("2: " + ex.Message);
        }
        catch (TaskCanceledException ex)
        {
            Console.WriteLine("3: " + ex.Message);
        }
        catch (UriFormatException ex)
        {
            Console.WriteLine("4: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        return city;
    }


    public async Task<bool> DeleteCity(int id)
    {
        HttpResponseMessage data = await _http.DeleteAsync("" + id);
        return data.IsSuccessStatusCode;
    }

    public async Task<IEnumerable<CityModel>> GetAll()
    {
        var city = await _http.GetFromJsonAsync<IEnumerable<CityModel>>("");
        return city;
    }

    public Task<CityModel> GetForCity(string city)
    {
        throw new NotImplementedException();
    }

    public async Task<CityModel> GetForId(int id)
    {
        CityModel? data;
        try
        {
            data = await _http.GetFromJsonAsync<CityModel>("" + id);
        }
        catch (Exception)
        {
            Console.WriteLine("problemas na chamada da api");
            return null;
        }
        
        return data;
    }


    public Task<CityModel> GetForState(string state)
    {
        throw new NotImplementedException();
    }

    public async Task<CityModel> UpCity(int id, CityModel city)
    {
         try
        {
            using(MultipartFormDataContent content = new MultipartFormDataContent())
            {
                content.Add(new StringContent(city.Id.ToString()), "city.Id");
                content.Add(new StringContent(city.City), "city.City");
                content.Add(new StringContent(city.State), "city.State");

                HttpResponseMessage data = await _http.PutAsync("" + id, content);
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        return city;
    }
}