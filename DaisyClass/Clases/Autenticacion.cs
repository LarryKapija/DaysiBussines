using DaisyClass.Servicios;
using System;
using System.Collections.Generic;
using System.Text;

namespace DaisyClass.Clases
{
    public class Autenticacion : IAutenticacion
    {
        public bool IniciarSesion(string nombreAdmin, string contraseña)
        {
            if (nombreAdmin == "d4584547c7f6a01a40bb8d863ab2c134e0c51ce353c0ca2fd93857961d750658")
            {
                if (contraseña == "12d3a199caf6945263630c066c19c37c0cac649b16fd94e321a2df1b3abba4ff")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
