using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Repository
{
    public class EstudioRepository : IEstudioRepository
    {
        private readonly PersonaDbContext _context;

        public EstudioRepository(PersonaDbContext context)
        {
            _context = context;
        }

        // Obtener todos los estudios
        public IEnumerable<Estudio> GetEstudios()
        {
            return _context.Estudios
                .Include(e => e.CcPerNavigation)  // Incluye la relación con Persona
                .Include(e => e.IdProfNavigation) // Incluye la relación con Profesion
                .ToList();
        }

        // Obtener un estudio por ID
        public Estudio GetEstudioById(int id)
        {
            return _context.Estudios
                .Include(e => e.CcPerNavigation)
                .Include(e => e.IdProfNavigation)
                .FirstOrDefault(e => e.CcPer == id);
        }

        // Crear un nuevo estudio
        public async Task<Estudio> CreateEstudioAsync(Estudio estudio)
        {
            await _context.Estudios.AddAsync(estudio);
            await _context.SaveChangesAsync();
            return estudio;
        }

        // Actualizar un estudio existente
        public async Task<bool> UpdateEstudioAsync(Estudio estudio)
        {
            _context.Entry(estudio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        // Eliminar un estudio
        public async Task<bool> DeleteEstudioAsync(Estudio estudio)
        {
            if (estudio == null)
            {
                return false;
            }

            _context.Estudios.Remove(estudio);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}