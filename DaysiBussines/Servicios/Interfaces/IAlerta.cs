using System.Threading.Tasks;
namespace DaysiBussines.Servicios.Interfaces
{
    public interface IAlerta
    {
        Task MostrarAlerta(string texto, string titulo);
    }
}
