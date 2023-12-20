using Desafio.Api.Context;
using Desafio.Api.Entities;
using Desafio.Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Client.Repository;

public class CityRepository : ICityRepository
{
    public readonly AppDbContext _context;
    

    public CityRepository(AppDbContext context)
    {
        _context = context;
    }



    public async Task<CityModel> AddCityAsync(CityModel city)
    {
        try
        {
            await _context.City.AddAsync(city);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex) 
        {  
            throw;
        }

        return city;
    }

    public async Task<bool> DeleteCityAsync(int id)
    {
        var cit = await _context.City.FirstAsync(c => c.Id == id);

        if(cit == null)
        {
            return false;
        }

        try
        {
            _context.City.Remove(cit);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            
            throw;
        }

        return true;
    }

    public async Task<IEnumerable<CityModel>> GetAllAsync()
    {
        //Fazer: Vereficar excessões
        var city = await _context.City.AsNoTracking().ToListAsync();
        return city;
    }

    public Task<CityModel> GetForCityAsync(string city)
    {
        throw new NotImplementedException();
    }

    public async Task<CityModel> GetForIdAsync(int id)
    {
        //Fazer: Vereficar excessões
        var data = await _context.City.AsNoTracking().Where(c => c.Id == id).ToListAsync();
        return data[0];
    }


    public Task<CityModel> GetForStateAsync(string state)
    {
        throw new NotImplementedException();
    }

    public async Task<CityModel> UpCityAsync(int id, CityModel city)
    {
        var cit = await _context.City.AsNoTracking().FirstAsync(c => c.Id == id);
        
        if(cit == null)
        {
            return null;
        }

        try
        {
            _context.City.Update(city);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw;
        }

        return city;
    }
}