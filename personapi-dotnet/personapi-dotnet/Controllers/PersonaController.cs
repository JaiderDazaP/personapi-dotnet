using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Repository;

namespace personapi_dotnet.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : Controller
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonaController(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        // POST: api/persona
        [HttpPost]
        [ActionName(nameof(CreatePersonaAsync))]
        public async Task<ActionResult<Persona>> CreatePersonaAsync(Persona persona)
        {
            await _personaRepository.CreatePersonaAsync(persona);
            return CreatedAtAction(nameof(GetPersonaById), new { id = persona.Cc }, persona);
        }

        // PUT: api/persona/{id}
        [HttpPut("{id}")]
        [ActionName(nameof(UpdatePersona))]
        public async Task<ActionResult> UpdatePersona(int id, Persona persona)
        {
            if (id != persona.Cc)
            {
                return BadRequest();
            }

            await _personaRepository.UpdatePersonaAsync(persona);

            return NoContent();
        }

        // DELETE: api/persona/{id}
        [HttpDelete("{id}")]
        [ActionName(nameof(DeletePersona))]
        public async Task<IActionResult> DeletePersonas(int id)
        {
            var persona = _personaRepository.GetPersonaById(id);
            if (persona == null)
            {
                return NotFound();
            }

            await _personaRepository.DeletePersonaAsync(persona);

            return NoContent();
        }

        // Acción de la API - Retorna datos JSON
        [HttpGet("GetAll")]
        [ActionName(nameof(GetPersonasAsync))]
        public IEnumerable<Persona> GetPersonasAsync()
        {
            return _personaRepository.GetPersonas();
        }

        // Acción de la API - Retorna datos JSON por ID
        [HttpGet("{id}")]
        [ActionName(nameof(GetPersonaById))]
        public ActionResult<Persona> GetPersonaById(int id)
        {
            var persona = _personaRepository.GetPersonaById(id);
            if (persona == null)
            {
                return NotFound();
            }
            return persona;
        }

        // Vista de interfaz de usuario para listar personas
        [HttpGet]
        [Route("/Persona/Index")]
        public IActionResult Index()
        {
            var personas = _personaRepository.GetPersonas();
            return View("View", personas);  // Especifica el nombre correcto de la vista
        }

        // Acción para editar una persona
        [HttpGet]
        [Route("/Persona/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var persona = _personaRepository.GetPersonaById(id);
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);  // Retorna la vista con el modelo de la persona a editar
        }

        [HttpPost]
        [Route("/Persona/Edit/{id}")]
        public async Task<IActionResult> Edit([FromForm] Persona persona)
        {
            if (ModelState.IsValid)
            {
                await _personaRepository.UpdatePersonaAsync(persona);
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }


        // Acción para ver los detalles de una persona
        [HttpGet]
        [Route("/Persona/Details/{id}")]
        public IActionResult DetailsPersona(int id)
        {
            var persona = _personaRepository.GetPersonaById(id);
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }

        // Acción para eliminar una persona
        [HttpGet]
        [Route("/Persona/Delete/{id}")]
        public IActionResult DeletePersona(int id)
        {
            var persona = _personaRepository.GetPersonaById(id);
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }

        [HttpPost, ActionName("DeletePersona")]
        [Route("/Persona/Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var persona = _personaRepository.GetPersonaById(id);
            if (persona == null)
            {
                return NotFound();
            }

            await _personaRepository.DeletePersonaAsync(persona);
            return RedirectToAction(nameof(Index));
        }

        // Acción para crear una nueva persona
        [HttpGet]
        [Route("/Persona/Create")]
        public IActionResult CreatePersona()
        {
            return View();
        }

        [HttpPost]
        [Route("/Persona/Create")]
        public async Task<IActionResult> CreatePersona([FromForm] Persona persona)
        {
            if (ModelState.IsValid)
            {
                await _personaRepository.CreatePersonaAsync(persona);
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

    }
}
