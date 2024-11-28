using Microsoft.AspNetCore.Mvc;
using ShoppingAPI_Jueves_2023II.DAL.Entities;
using ShoppingAPI_Jueves_2023II.Domain.Interfaces;

namespace ShoppingAPI_Jueves_2023II.Controllers
{
    [Route("api/[controller]")]//esta es el nombre inicial de mi ruta, url o path
    [ApiController]
    public class StatesController : Controller
    {
        private readonly IStateService _stateService;
        
        public StatesController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<State>>> GetStatesAsync()
        {
            var state = await _stateService.GetStatesAsync();
            if (state == null || !state.Any())
            {
                return NotFound();//404
            }
            return Ok(state);//200
        }


        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]//url: api/state/get
        public async Task<ActionResult<State>> GetStateByIdAsync(Guid id)
        {
            var state = await _stateService.GetStateByIdAsync(id);
            if (state == null)
            {
                return NotFound();//404
            }
            return Ok(state);// ok = status code 200
        }
        [HttpPost, ActionName("create")]
        [Route("Create")]
        public async Task<ActionResult<State>> CreateStateAsync(State state)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);  // Devuelve los errores de validación
                }
                var newState = await _stateService.CreateStateAsycn(state);
                if (newState == null)
                {
                    return NotFound();
                }
                
                return Ok(newState);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(string.Format("{0} ya existe", state.Name));
                }
                return StatusCode(500,ex.Message);
            }

        }
        [HttpPut, ActionName("edit")]
        [Route("edit")]

        public async Task<ActionResult<State>> EditStateAsync(State state)
        {
            try
            {
                var editedState = await _stateService.EditStateAsync(state);
                if (editedState == null)
                {
                    return NotFound();
                }
                return Ok(editedState);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(string.Format("{0} ya existe", state.Name));
                }
                return Conflict(ex.Message);
            }
        }


        [HttpDelete, ActionName("Delete")]
        [Route("Delete/{id}")]
        public async Task<ActionResult<State>> DelateStateAsync(Guid id)
        {
            try
            {
                if (id == null) return BadRequest();
                var delatedState = await _stateService.DeleteStateAsync(id);
                if (delatedState == null)
                {
                    return NotFound();
                }
                return Ok(delatedState);
            }
            catch (Exception ex)
            {

                return StatusCode(500,ex.Message);
            }

            

        }
    }
}
