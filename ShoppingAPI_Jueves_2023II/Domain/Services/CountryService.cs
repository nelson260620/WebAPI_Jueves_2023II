using Microsoft.EntityFrameworkCore;
using ShoppingAPI_Jueves_2023II.DAL;
using ShoppingAPI_Jueves_2023II.DAL.Entities;
using ShoppingAPI_Jueves_2023II.Domain.Interfaces;

namespace ShoppingAPI_Jueves_2023II.Domain.Services
{
    public class CountryService : ICountryService
    {
        private readonly DataBaseContext _context;
<<<<<<< HEAD

=======
>>>>>>> 20d0c7ad3c6b60f8fb653de04afd3a136e674bcc
        public CountryService(DataBaseContext context)
        {
            _context = context;
        }
<<<<<<< HEAD

=======
>>>>>>> 20d0c7ad3c6b60f8fb653de04afd3a136e674bcc
        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            try
            {
                var countries = await _context.Countries.ToListAsync();
<<<<<<< HEAD
                return countries;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
=======

                return countries;
            }
            catch (DbUpdateException dbUdateException)
            {

                throw new Exception(dbUdateException.InnerException?.Message ??
                    dbUdateException.Message);
>>>>>>> 20d0c7ad3c6b60f8fb653de04afd3a136e674bcc
            }
        }

        public async Task<Country> GetCountryByIdAsync(Guid id)
        {
<<<<<<< HEAD
            try
            {
                var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
                //Otras dos formas de traerme un objeto desde la BD
                var country1 = await _context.Countries.FindAsync(id);
                var country2 = await _context.Countries.FirstAsync(c => c.Id == id);

                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Country> CreateCountryAsync(Country country)
=======

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
>>>>>>> 20d0c7ad3c6b60f8fb653de04afd3a136e674bcc
        {
            try
            {
                country.Id = Guid.NewGuid();
                country.CreatedDate = DateTime.Now;
<<<<<<< HEAD
                _context.Countries.Add(country); //El Método Add() me permite crear el objeto en el contexto de mi BD

                await _context.SaveChangesAsync(); //Este método me permite guardar el país en mi tabla COUNTRY

                return country;

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

=======

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
>>>>>>> 20d0c7ad3c6b60f8fb653de04afd3a136e674bcc
        public async Task<Country> EditCountryAsync(Country country)
        {
            try
            {
                country.ModifiedDate = DateTime.Now;

<<<<<<< HEAD
                _context.Countries.Update(country); //Virtualizo mi objeto
                await _context.SaveChangesAsync();

                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
=======
                _context.Countries.Update(country);
                await _context.SaveChangesAsync();

                return country;

            }
            catch (DbUpdateException dbUdateException)
            {

                throw new Exception(dbUdateException.InnerException?.Message ??
                    dbUdateException.Message);
>>>>>>> 20d0c7ad3c6b60f8fb653de04afd3a136e674bcc
            }
        }

        public async Task<Country> DeleteCountryAsync(Guid id)
        {
            try
            {
                var country = await GetCountryByIdAsync(id);

<<<<<<< HEAD
                if (country == null)
                {
                    return null;
                }

                _context.Countries.Remove(country); //Creación del query "Delete from Countries Where Id = @id";
                await _context.SaveChangesAsync(); //La ejecución del Query

                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
=======
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

>>>>>>> 20d0c7ad3c6b60f8fb653de04afd3a136e674bcc
    }
}
