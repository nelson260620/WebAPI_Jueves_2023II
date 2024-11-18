using ShoppingAPI_Jueves_2023II.DAL.Entities;

namespace ShoppingAPI_Jueves_2023II.Domain.Interfaces
{
    public interface ICountryService
    {
        Task <IEnumerable<Country>>GetCountriesAsync();//una de las tantas filas de un metodo
        Task<Country> CreateCountriesAsync(Country country);
        Task<Country> GetCountryByIdAsync(Guid id);
        Task<Country> EditCountryAsync(Country country);
        Task<Country> DeleteCountryAsync(Guid id);
    }
}


