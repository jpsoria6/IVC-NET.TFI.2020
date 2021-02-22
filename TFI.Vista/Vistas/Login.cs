using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TFI.Dominio.Interfaces;
using TFI.Vista.Presentadores;

namespace TFI.Vista.Vistas
{
    public partial class Login : Form, ILoginVista
    {
        private readonly LoginPresentador _presentador;
        public Login(LoginPresentador presentador)
        {
            InitializeComponent();
            this._presentador = presentador;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            _presentador.SetVista(this);
        }

        public void Mostrar()
        {
            this.Visible = true;
        }

        public void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Ocultar()
        {
            this.Visible = false;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            _presentador.IngresarDatos(int.Parse(txtLegajo.Text), txtContraseña.Text);
        }
    }
}
