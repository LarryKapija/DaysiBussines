using DaisyClass.Clases;
using DaisyClass.Servicios;
using DayiClass.Clases;
using DayiClass.Interfaces;
using DaysiBussines.Servicios.Clases;
using DaysiBussines.Servicios.Interfaces;
using System;
using System.Runtime.InteropServices;
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
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

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
