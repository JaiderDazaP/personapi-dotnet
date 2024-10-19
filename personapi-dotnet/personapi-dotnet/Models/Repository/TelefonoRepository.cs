using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Repository
{
    public class TelefonoRepository : ITelefonoRepository
    {
        protected readonly PersonaDbContext _context;
        public TelefonoRepository(PersonaDbContext context) => _context = context;

        public IEnumerable<Telefono> GetTelefonos()
        {
            return _context.Telefonos.Include(t => t.DuenioNavigation).ToList();
        }

        public Telefono GetTelefonoByNum(string num)
        {
            return _context.Telefonos.Include(t => t.DuenioNavigation).FirstOrDefault(t => t.Num == num);
        }

        public async Task<Telefono> CreateTelefonoAsync(Telefono telefono)
        {
            await _context.Set<Telefono>().AddAsync(telefono);
            await _context.SaveChangesAsync();
            return telefono;
        }

        public async Task<bool> UpdateTelefonoAsync(Telefono telefono)
        {
            _context.Entry(telefono).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTelefonoAsync(Telefono telefono)
        {
            if (telefono is null)
            {
                return false;
            }
            _context.Set<Telefono>().Remove(telefono);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}