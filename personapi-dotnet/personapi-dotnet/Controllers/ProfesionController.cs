using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Repository;

namespace personapi_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesionController : Controller
    {
        private readonly IProfesionRepository _profesionRepository;

        public ProfesionController(IProfesionRepository profesionRepository)
        {
            _profesionRepository = profesionRepository;
        }

        // GET: api/Profesion
        [HttpGet]
        public IEnumerable<Profesion> GetProfesiones()
        {
            return _profesionRepository.GetProfesiones();
        }

        // GET: api/Profesion/5
        [HttpGet("{id}")]
        public ActionResult<Profesion> GetProfesionById(int id)
        {
            var profesion = _profesionRepository.GetProfesionById(id);
            if (profesion == null)
            {
                return NotFound();
            }
            return profesion;
        }

        // POST: api/Profesion
        [HttpPost]
        public async Task<ActionResult<Profesion>> CreateProfesionAsync(Profesion profesion)
        {
            await _profesionRepository.CreateProfesionAsync(profesion);
            return CreatedAtAction(nameof(GetProfesionById), new { id = profesion.Id }, profesion);
        }

        // PUT: api/Profesion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfesion(int id, Profesion profesion)
        {
            if (id != profesion.Id)
            {
                return BadRequest();
            }

            await _profesionRepository.UpdateProfesionAsync(profesion);
            return NoContent();
        }

        // DELETE: api/Profesion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesion(int id)
        {
            var profesion = _profesionRepository.GetProfesionById(id);
            if (profesion == null)
            {
                return NotFound();
            }

            await _profesionRepository.DeleteProfesionAsync(profesion);
            return NoContent();
        }

        // Obtener todas las profesiones (Vista)
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var profesiones = _profesionRepository.GetProfesiones();
            return View("ListProfesion", profesiones); // Devuelve la vista ListProfesion
        }

        // Crear una nueva profesión (Vista)
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View("CreateProfesion");
        }

        // Crear una nueva profesión (Acción POST)
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(Profesion profesion)
        {
            if (ModelState.IsValid)
            {
                await _profesionRepository.CreateProfesionAsync(profesion);
                return RedirectToAction("Index"); // Redirige al índice después de crear
            }
            return View("CreateProfesion", profesion); // Si hay errores, vuelve a la vista de creación
        }

        // Editar una profesión (Vista)
        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var profesion = _profesionRepository.GetProfesionById(id);
            if (profesion == null)
            {
                return NotFound();
            }
            return View("EditProfesion", profesion); // Devuelve la vista de edición
        }

        // Editar una profesión (Acción POST)
        [HttpPost]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, Profesion profesion)
        {
            if (id != profesion.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var result = await _profesionRepository.UpdateProfesionAsync(profesion);
                if (!result)
                {
                    return NotFound();
                }
                return RedirectToAction("Index"); // Redirige al índice después de editar
            }
            return View("DetailsProfesion", profesion); // Si hay errores, vuelve a la vista de edición
        }

        // Detallar una profesión (Vista)
        [HttpGet]
        [Route("Details/{id}")]
        public IActionResult Details(int id)
        {
            var profesion = _profesionRepository.GetProfesionById(id);
            if (profesion == null)
            {
                return NotFound();
            }
            return View("DeleteProfesion", profesion); // Devuelve la vista de detalles
        }

        // Eliminar una profesión (Acción POST)
        [HttpPost]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var profesion = _profesionRepository.GetProfesionById(id);
            if (profesion == null)
            {
                return NotFound();
            }

            await _profesionRepository.DeleteProfesionAsync(profesion);
            return RedirectToAction("Index"); // Redirige al índice después de eliminar
        }
    }
}
