using ShoppingAPI_Jueves_2023II.DAL.Entities;

namespace ShoppingAPI_Jueves_2023II.Domain.Interfaces
{
    public interface IStateService
    {
        //una de las tantas filas de un metodo state
        Task<IEnumerable<State>> GetStatesAsync();
        Task<State> CreateStateAsycn(State state);
        Task<State> GetStateByIdAsync(Guid id);
        Task<State> EditStateAsync(State state);
        Task<State> DeleteStateAsync(Guid id);

    }
}
