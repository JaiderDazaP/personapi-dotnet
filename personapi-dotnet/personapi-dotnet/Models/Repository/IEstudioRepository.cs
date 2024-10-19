using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Repository
{
    public interface IEstudioRepository
    {
        IEnumerable<Estudio> GetEstudios();
        Estudio GetEstudioById(int id);
        Task<Estudio> CreateEstudioAsync(Estudio estudio);
        Task<bool> UpdateEstudioAsync(Estudio estudio);
        Task<bool> DeleteEstudioAsync(Estudio estudio);
    }
}
