using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Repository
{
    public interface IPersonaRepository
    {
        IEnumerable<Persona> GetPersonas();
        Persona GetPersonaById(int id);
        Task<Persona> CreatePersonaAsync(Persona persona);
        Task<bool> UpdatePersonaAsync(Persona persona);
        Task<bool> DeletePersonaAsync(Persona persona);
    }
}
