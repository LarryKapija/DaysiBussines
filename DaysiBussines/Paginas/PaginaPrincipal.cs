using DaysiBussines.Paginas.Clientes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaysiBussines.Paginas
{
    public partial class PaginaPrincipal : Form
    {
        public PaginaPrincipal()
        {
            InitializeComponent();
            PersonalizarDiseño();
        }
        private void PersonalizarDiseño()
        {
            panelSubmenuClientes.Visible = false;
            panelSubmenuProductos.Visible = false;
            panelSubmenuReportes.Visible = false;
            panelSubmenuVentas.Visible = false;
        }
        private void OcultarSubmenu()
        {
            if (panelSubmenuClientes.Visible == true)
                panelSubmenuClientes.Visible = false;
            if (panelSubmenuProductos.Visible == true)
                panelSubmenuProductos.Visible = false;
            if (panelSubmenuReportes.Visible == true)
                panelSubmenuReportes.Visible = false;
            if (panelSubmenuVentas.Visible == true)
                panelSubmenuVentas.Visible = false;
        }
        private void MostrarSubmenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                OcultarSubmenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        #region Botones
            private void btnClientes_Click(object sender, EventArgs e)
            {
                MostrarSubmenu(panelSubmenuClientes);
            }
            private void btnProductos_Click(object sender, EventArgs e)
            {
                MostrarSubmenu(panelSubmenuProductos);
            }
            private void btnReportes_Click(object sender, EventArgs e)
            {
                MostrarSubmenu(panelSubmenuReportes);

            }
            private void btnVentas_Click(object sender, EventArgs e)
            {
                MostrarSubmenu(panelSubmenuVentas);

            }
        #endregion

        private Form formularioActivo = null;
        public void AbrirFormularioHijo(Form formularioHijo)
        {
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }
            formularioActivo = formularioHijo;
            formularioHijo.TopLevel = false;
            formularioHijo.Dock = DockStyle.Fill;
            panelFormularioHijo.Controls.Add(formularioHijo);
            panelFormularioHijo.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        private void btnVerClientes_Click(object sender, EventArgs e)
        {
            OcultarSubmenu();
            AbrirFormularioHijo(new ListaClientes());
        }


    }
}
