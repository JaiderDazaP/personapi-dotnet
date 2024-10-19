using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Repository
{
    public interface ITelefonoRepository
    {
        IEnumerable<Telefono> GetTelefonos();
        Telefono GetTelefonoByNum(string num);
        Task<Telefono> CreateTelefonoAsync(Telefono telefono);
        Task<bool> UpdateTelefonoAsync(Telefono telefono);
        Task<bool> DeleteTelefonoAsync(Telefono telefono);
    }
}
