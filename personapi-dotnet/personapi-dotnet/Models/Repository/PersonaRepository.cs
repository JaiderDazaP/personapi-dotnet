using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Repository
{
    public class PersonaRepository : IPersonaRepository
    {
        protected readonly PersonaDbContext _context;

        public PersonaRepository(PersonaDbContext context)
        {
            _context = context;
        }

        // Obtener todas las personas
        public IEnumerable<Persona> GetPersonas()
        {
            return _context.Personas.ToList();
        }

        // Obtener una persona por su ID
        public Persona GetPersonaById(int id)
        {
            return _context.Personas.Find(id);
        }

        // Crear una nueva persona
        public async Task<Persona> CreatePersonaAsync(Persona persona)
        {
            await _context.Set<Persona>().AddAsync(persona);
            await _context.SaveChangesAsync();
            return persona;
        }

        // Actualizar los datos de una persona existente
        public async Task<bool> UpdatePersonaAsync(Persona persona)
        {
            _context.Entry(persona).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        // Eliminar una persona existente
        public async Task<bool> DeletePersonaAsync(Persona persona)
        {
            if (persona == null)
            {
                return false;
            }
            _context.Set<Persona>().Remove(persona);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
