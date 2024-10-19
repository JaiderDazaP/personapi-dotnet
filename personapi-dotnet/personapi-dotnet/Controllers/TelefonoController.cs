using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Repository;

namespace personapi_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefonoController : ControllerBase
    {
        private readonly ITelefonoRepository _telefonoRepository;

        public TelefonoController(ITelefonoRepository telefonoRepository)
        {
            _telefonoRepository = telefonoRepository;
        }

        // GET: api/Telefono
        [HttpGet]
        public IEnumerable<Telefono> GetTelefonos()
        {
            return _telefonoRepository.GetTelefonos();
        }

        // GET: api/Telefono/5
        [HttpGet("{num}")]
        public ActionResult<Telefono> GetTelefonoByNum(string num)
        {
            var telefono = _telefonoRepository.GetTelefonoByNum(num);
            if (telefono == null)
            {
                return NotFound();
            }
            return telefono;
        }

        // POST: api/Telefono
        [HttpPost]
        public async Task<ActionResult<Telefono>> CreateTelefonoAsync(Telefono telefono)
        {
            await _telefonoRepository.CreateTelefonoAsync(telefono);
            return CreatedAtAction(nameof(GetTelefonoByNum), new { num = telefono.Num }, telefono);
        }

        // PUT: api/Telefono/5
        [HttpPut("{num}")]
        public async Task<IActionResult> UpdateTelefono(string num, Telefono telefono)
        {
            if (num != telefono.Num)
            {
                return BadRequest();
            }

            await _telefonoRepository.UpdateTelefonoAsync(telefono);
            return NoContent();
        }

        // DELETE: api/Telefono/5
        [HttpDelete("{num}")]
        public async Task<IActionResult> DeleteTelefono(string num)
        {
            var telefono = _telefonoRepository.GetTelefonoByNum(num);
            if (telefono == null)
            {
                return NotFound();
            }

            await _telefonoRepository.DeleteTelefonoAsync(telefono);
            return NoContent();
        }
    }
}
