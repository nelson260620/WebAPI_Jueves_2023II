using ShoppingAPI_Jueves_2023II.DAL.Entities;

namespace ShoppingAPI_Jueves_2023II.Domain.Interfaces
{
    public interface ICountryService
    {
<<<<<<< HEAD
        //una de las tantas filas de un metodo countries
        Task<IEnumerable<Country>> GetCountriesAsync();
=======
        //una de las tantas filas de un metodo
        Task<IEnumerable<Country>>GetCountriesAsync();
        Task<Country> CreateCountriesAsync(Country country);
>>>>>>> 20d0c7ad3c6b60f8fb653de04afd3a136e674bcc
        Task<Country> GetCountryByIdAsync(Guid id);
        Task<Country> CreateCountryAsync(Country country);
        Task<Country> EditCountryAsync(Country country);
        Task<Country> DeleteCountryAsync(Guid id);
    }
}


