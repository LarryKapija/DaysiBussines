using DaisyClass.Clases;
using DaisyClass.Servicios;
using DayiClass.Clases;
using DayiClass.Interfaces;
using DaysiBussines.Paginas;
using DaysiBussines.Servicios.Clases;
using DaysiBussines.Servicios.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using PaginaIniciarSesion = DaysiBussines.Paginas.PaginaIniciarSesion;

namespace DaysiBussines
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var iniciarSesion = serviceProvider.GetRequiredService<PaginaIniciarSesion>();
                Application.Run(iniciarSesion);
            }   
        }

        private static void ConfigureServices(IServiceCollection service)
        {
            #region Paginas
            service.AddScoped<PaginaIniciarSesion>()
                .AddScoped<PaginaPrincipal>()
            #endregion

            #region Servicios
                .AddScoped<IEncrypt, Encrypt>()
                .AddScoped<IAutenticacion, Autenticacion>()
                .AddScoped<IAlerta, Alerta>()
            #endregion

            #region Clientes
                .AddScoped<IClientes,Clientes>();
            #endregion

        }
    }
}
