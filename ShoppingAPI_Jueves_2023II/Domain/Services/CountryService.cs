using Microsoft.EntityFrameworkCore;
using ShoppingAPI_Jueves_2023II.DAL;
using ShoppingAPI_Jueves_2023II.DAL.Entities;
using ShoppingAPI_Jueves_2023II.Domain.Interfaces;

namespace ShoppingAPI_Jueves_2023II.Domain.Services
{
    public class CountryService : ICountryService
    {
        private readonly DataBaseContext _context;
        public CountryService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            try
            {
                var countries = await _context.Countries.ToListAsync();

                return countries;
            }
            catch (DbUpdateException dbUdateException)
            {

                throw new Exception(dbUdateException.InnerException?.Message ??
                    dbUdateException.Message);
            }
        }

        public async Task<Country> GetCountryByIdAsync(Guid id)
        {

            try
            {
                var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
                //otras dos formas de traerme un objeto desde la BD
                var country2 = await _context.Countries.FindAsync(id);
                var country3 = await _context.Countries.FirstAsync(c => c.Id == id);
                return country;
            }
            catch (DbUpdateException dbUdateException)
            {

                throw new Exception(dbUdateException.InnerException?.Message ??
                    dbUdateException.Message);
            }
        }
        public async Task<Country> CreateCountriesAsync(Country country)
        {
            try
            {
                country.Id = Guid.NewGuid();
                country.CreatedDate = DateTime.Now;

                _context.Countries.Add(country); // me permite crear el objeto en el contexto de la base de datos

                await _context.SaveChangesAsync();// este metodo add() me permite guardar el pais en mi tabla COUNTRY

                return country;
            }
            catch (DbUpdateException dbUdateException)
            {

                throw new Exception (dbUdateException.InnerException?.Message ??
                    dbUdateException.Message);
            }
        }
        public async Task<Country> EditCountryAsync(Country country)
        {
            try
            {
                country.ModifiedDate = DateTime.Now;

                _context.Countries.Update(country);
                await _context.SaveChangesAsync();

                return country;

            }
            catch (DbUpdateException dbUdateException)
            {

                throw new Exception(dbUdateException.InnerException?.Message ??
                    dbUdateException.Message);
            }
        }

        public async Task<Country> DeleteCountryAsync(Guid id)
        {
            try
            {
                var country = await GetCountryByIdAsync(id);

                if (country != null)
                {
                    return null;
                }
                _context.Countries.Remove(country);

                return country;
            }
            catch (DbUpdateException dbUdateException)
            {

                throw new Exception(dbUdateException.InnerException?.Message ??
                    dbUdateException.Message);
            }
        }

    }
}
