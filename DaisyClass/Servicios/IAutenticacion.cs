using System;
using System.Collections.Generic;
using System.Text;

namespace DaisyClass.Servicios
{
    public interface IAutenticacion
    {
        bool IniciarSesion(string nombreAdmin, string contraseña);
    }
}
