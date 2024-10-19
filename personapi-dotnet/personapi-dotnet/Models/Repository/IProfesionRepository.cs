using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Repository
{
    public interface IProfesionRepository
    {
        IEnumerable<Profesion> GetProfesiones();
        Profesion GetProfesionById(int id);
        Task<Profesion> CreateProfesionAsync(Profesion profesion);
        Task<bool> UpdateProfesionAsync(Profesion profesion);
        Task<bool> DeleteProfesionAsync(Profesion profesion);
    }
}
