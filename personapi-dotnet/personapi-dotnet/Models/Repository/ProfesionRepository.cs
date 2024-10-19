using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Repository
{
    public class ProfesionRepository : IProfesionRepository
    {
        protected readonly PersonaDbContext _context;
        public ProfesionRepository(PersonaDbContext context) => _context = context;

        public IEnumerable<Profesion> GetProfesiones()
        {
            return _context.Profesions.Include(p => p.Estudios).ToList();
        }

        public Profesion GetProfesionById(int id)
        {
            return _context.Profesions.Include(p => p.Estudios).FirstOrDefault(p => p.Id == id);
        }

        public async Task<Profesion> CreateProfesionAsync(Profesion profesion)
        {
            await _context.Set<Profesion>().AddAsync(profesion);
            await _context.SaveChangesAsync();
            return profesion;
        }

        public async Task<bool> UpdateProfesionAsync(Profesion profesion)
        {
            _context.Entry(profesion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProfesionAsync(Profesion profesion)
        {
            if (profesion is null)
            {
                return false;
            }
            _context.Set<Profesion>().Remove(profesion);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

