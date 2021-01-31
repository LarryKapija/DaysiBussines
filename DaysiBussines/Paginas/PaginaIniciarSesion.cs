using DaisyClass.Clases;
using DaisyClass.Servicios;
using DayiClass.Clases;
using DayiClass.Interfaces;
using DaysiBussines.Servicios.Clases;
using DaysiBussines.Servicios.Interfaces;
using System;
using System.Windows.Forms;

namespace DaysiBussines.Paginas
{
    public partial class PaginaIniciarSesion : Form
    {
        Autenticacion iniciarSesion;
        Alerta alerta;
        Encrypt encrypt;
        PaginaPrincipal paginaPrincipal;
        public PaginaIniciarSesion(IAutenticacion iniciarSesion, IAlerta alerta, IEncrypt encrypt, PaginaPrincipal paginaPrincipal)
        {   
            InitializeComponent();
            this.paginaPrincipal = paginaPrincipal;
            this.iniciarSesion = (Autenticacion)iniciarSesion;
            this.alerta = (Alerta)alerta;
            this.encrypt = (Encrypt)encrypt;
        }

        private void BotonIniciar_Click(object sender, EventArgs e)
        {
            string usuarioEncriptado = encrypt.GetSHA256(EntradaUsuario.Text);
            string contraseñaEncriptada = encrypt.GetSHA256(EntradaContraseña.Text);

            if (EntradaUsuario.Text == ""|| EntradaContraseña.Text == "")
            {
                alerta.MostrarAlerta("Ambos campos son obligatorios","ERROR");
            }
            else if (iniciarSesion.IniciarSesion(usuarioEncriptado,contraseñaEncriptada))
            {
                alerta.MostrarAlerta("Bienvenido!","Autenticacion");
                this.Hide();
                paginaPrincipal.FormClosed += (s, args) => this.Close();
                paginaPrincipal.Show();
            }
            else
            {
                alerta.MostrarAlerta("Usuario y/o contraseña incorrectos","Autenticacion");
            }
        }
    }
}
