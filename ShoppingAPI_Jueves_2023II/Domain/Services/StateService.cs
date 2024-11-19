using Microsoft.EntityFrameworkCore;
using ShoppingAPI_Jueves_2023II.DAL;
using ShoppingAPI_Jueves_2023II.DAL.Entities;
using ShoppingAPI_Jueves_2023II.Domain.Interfaces;

namespace ShoppingAPI_Jueves_2023II.Domain.Services
{
    public class StateService : IStateService
    {
        private readonly DataBaseContext _context;
        public StateService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<State>> GetStatesAsync()
        {
            try
            {
                var state = await _context.States.Include(s => s.Country).ToListAsync();
                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<State> GetStateByIdAsync(Guid id)
        {
            try
            {
                var state = await _context.States.Include(s => s.Country)
                    .FirstOrDefaultAsync(s => s.Id == id) ?? throw new Exception("no hay estado");

                return state;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<State> CreateStateAsycn(State state)
        {
            try
            {
                var coutry = await _context.Countries.FirstOrDefaultAsync(c => c.Id == state.CountryId);
                if (coutry == null)
                {
                    throw new Exception("el pais no existe");
                }
                state.Id = Guid.NewGuid();
                state.CreatedDate = DateTime.Now;

                _context.States.Add(state);
                await _context.SaveChangesAsync();

                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<State> EditStateAsync(State state)
        {
            try
            {
                state.ModifiedDate = DateTime.Now;

                _context.States.Update(state);
                await _context.SaveChangesAsync();


                return state;
            }
            catch (DbUpdateException ex)
            {

                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<State> DeleteStateAsync(Guid id)
        {
            try
            {

                var state = await _context.States.FirstOrDefaultAsync(s => s.Id == id);

                if (state == null)
                {
                    throw new Exception("Estado no encontrado");
                }
                _context.States.Remove(state);
                await _context.SaveChangesAsync();

                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Country> GetCountryByIdAsync(Guid countryId)
        {
            return await _context.Countries.FirstOrDefaultAsync(c => c.Id == countryId);
        }

    }
}
