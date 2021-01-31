using DaysiBussines.Servicios.Interfaces;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaysiBussines.Servicios.Clases
{
    class Alerta : IAlerta
    {
        public Task MostrarAlerta(string texto, string titulo)
        {
            MessageBox.Show(texto, titulo);
            return null;
        }
    }
}
