using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TFI.Dominio.Contratos;
using TFI.Dominio.Interfaces;
using TFI.Vista.Presentadores;

namespace TFI.Vista
{
    public partial class MenuPrincipal : Form, IMenuPrincipalVista
    {
        private MenuPrincipalPresentador _presentador;
        public MenuPrincipal(MenuPrincipalPresentador presentador)
        {
            InitializeComponent();
            _presentador = presentador;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        public void MostrarVentaIndumentaria()
        {
            _presentador.MostrarVentaIndumentaria();
        }

        private void MenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnVentaIndumentaria_Click(object sender, EventArgs e)
        {
            MostrarVentaIndumentaria();
        }
    }
}
