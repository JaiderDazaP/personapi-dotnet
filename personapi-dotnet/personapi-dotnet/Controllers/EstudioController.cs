using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Repository;

namespace personapi_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudioController : Controller
    {
        private readonly IEstudioRepository _estudioRepository;

        public EstudioController(IEstudioRepository estudioRepository)
        {
            _estudioRepository = estudioRepository;
        }

        // Obtener todos los estudios
        [HttpGet]
        public IEnumerable<Estudio> GetEstudios()
        {
            return _estudioRepository.GetEstudios();
        }

        // Obtener un estudio por ID
        [HttpGet("{id}")]
        public ActionResult<Estudio> GetEstudioById(int id)
        {
            var estudio = _estudioRepository.GetEstudioById(id);
            if (estudio == null)
            {
                return NotFound();
            }
            return estudio;
        }

        // Crear un nuevo estudio
        [HttpPost]
        public async Task<ActionResult<Estudio>> CreateEstudioAsync([FromBody] Estudio estudio)
        {
            if (estudio == null)
            {
                return BadRequest("El objeto estudio no puede ser nulo.");
            }

            // Validar propiedades requeridas
            if (string.IsNullOrWhiteSpace(estudio.Univer) || estudio.IdProf <= 0 || estudio.CcPer <= 0)
            {
                return BadRequest("Propiedades requeridas faltantes o inválidas.");
            }

            // Crear la entidad sin las propiedades de navegación
            var nuevoEstudio = new Estudio
            {
                IdProf = estudio.IdProf,
                CcPer = estudio.CcPer,
                Fecha = estudio.Fecha,
                Univer = estudio.Univer
            };

            await _estudioRepository.CreateEstudioAsync(nuevoEstudio);

            return CreatedAtAction(nameof(GetEstudioById), new { id = nuevoEstudio.CcPer }, nuevoEstudio);
        }


        // Actualizar un estudio existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEstudio(int id, Estudio estudio)
        {
            if (id != estudio.CcPer)
            {
                return BadRequest();
            }

            await _estudioRepository.UpdateEstudioAsync(estudio);
            return NoContent();
        }

        // Eliminar un estudio
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudio(int id)
        {
            var estudio = _estudioRepository.GetEstudioById(id);
            if (estudio == null)
            {
                return NotFound();
            }

            await _estudioRepository.DeleteEstudioAsync(estudio);
            return NoContent();
        }

        // Vista de interfaz de usuario para listar personas
        [HttpGet]
        [Route("/Estudio/Index")]
        public IActionResult Index()
        {
            var estudios = _estudioRepository.GetEstudios();
            return View("ListEstudio", estudios);  // Especifica el nombre correcto de la vista
        }

        // Acción para editar una persona
        [HttpGet]
        [Route("/Estudio/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var estudio = _estudioRepository.GetEstudioById(id);
            if (estudio == null)
            {
                return NotFound();
            }
            return View(estudio);  // Retorna la vista con el modelo de la persona a editar
        }

        [HttpPost]
        [Route("/Estudio/Edit/{id}")]
        public async Task<IActionResult> Edit([FromForm] Estudio estudio)
        {
            if (ModelState.IsValid)
            {
                await _estudioRepository.UpdateEstudioAsync(estudio);
                return RedirectToAction(nameof(Index));
            }
            return View(estudio);
        }

        // Acción para ver los detalles de una persona
        [HttpGet]
        [Route("/Estudio/Details/{id}")]
        public IActionResult DetailsEstudio(int id)
        {
            var estudio = _estudioRepository.GetEstudioById(id);
            if (estudio == null)
            {
                return NotFound();
            }
            return View(estudio);
        }

        // Acción para eliminar una persona
        [HttpGet]
        [Route("/Estudio/Delete/{id}")]
        public IActionResult DeleteEstudio2(int id)
        {
            var estudio = _estudioRepository.GetEstudioById(id);
            if (estudio == null)
            {
                return NotFound();
            }
            return View(estudio);
        }

        [HttpPost, ActionName("DeleteEstudio")]
        [Route("/Estudio/Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudio = _estudioRepository.GetEstudioById(id);
            if (estudio == null)
            {
                return NotFound();
            }

            await _estudioRepository.DeleteEstudioAsync(estudio);
            return RedirectToAction(nameof(Index));
        }

        // Acción para crear una nueva persona
        [HttpGet]
        [Route("/Estudio/Create")]
        public IActionResult CreateEstudio()
        {
            return View();
        }

        [HttpPost]
        [Route("/Estudio/Create")]
        public async Task<IActionResult> CreateEstudio([FromForm] Estudio estudio)
        {
            if (ModelState.IsValid)
            {
                await _estudioRepository.CreateEstudioAsync(estudio);
                return RedirectToAction(nameof(Index));
            }
            return View(estudio);
        }
    }
}
