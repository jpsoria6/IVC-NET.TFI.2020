using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TFI.Dominio;
using TFI.Dominio.Interfaces;
using TFI.Vista.Presentadores;

namespace TFI.Vista.Vistas
{
    public partial class VentaIndumentaria : Form, IVentaIndumentariaVista
    {
        private VentaIndumentariaPresentador _presentador;
        private Venta _venta;
        private Indumentaria _indumentaria;
        public VentaIndumentaria(VentaIndumentariaPresentador presentador)
        {
            InitializeComponent();
            this._presentador = presentador;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            presentador.SetVista(this);
            InicializarVista();
        }

        public void InicializarVista()
        {
            this._venta = _presentador.CrearNuevaVenta();
            this.bsVenta.DataSource = _venta;
            this.lineaDeVentaBindingSource.DataSource = _venta.LineaDeVentas;
            this.lineaDeVentaBindingSource.ResetBindings(false);
            ListarTalles(_presentador.GetTalles());
        }

        public void ListarTalles(List<Talle> talles)
        {
            this.bsTalle.DataSource = talles;
        }

        public void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void MostrarIndumentaria(Indumentaria ind)
        {
            this._indumentaria = ind;
            this.LblDescripcion.Text = ind.Descripcion;
            this.lblPrecio.Text = "$"+ind.Precio;
        }

        private void TxtCodigo_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtCodigo.Text))
            {
            _presentador.IngresarIndumentaria(int.Parse(TxtCodigo.Text));
            }
        }

        private void btnAgregarIndumentaria_Click(object sender, EventArgs e)
        {
            var talle = (Talle)comboTalle.SelectedItem;
            _presentador.RegistrarLineaDeVenta(_indumentaria, int.Parse(TxtCantidad.Text),talle.Id);
        }

        private void txtImporte_Leave(object sender, EventArgs e)
        {
            try
            {
            txtVuelto.Text = ""+_presentador.IngresarImporte(double.Parse(txtImporte.Text));
            }
            catch (FormatException)
            {
                MostrarError("El formato no es correcto");
            }
        }

        public void ActualizarVista(Venta venta)
        {
            this._venta = venta;
            this.bsVenta.DataSource = venta;
            this.lineaDeVentaBindingSource.DataSource = venta.LineaDeVentas;
            lineaDeVentaBindingSource.ResetBindings(false);
            bsVenta.ResetBindings(false);
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            TxtCodigo.Text = null;
            lblPrecio.Text = null;
            LblDescripcion.Text = null;
            comboTalle.SelectedIndex = 0;
        }

        private void TxtCantidad_Leave(object sender, EventArgs e)
        {
            try
            {
                int.Parse(TxtCantidad.Text);
            }
            catch(FormatException)
            {
                MostrarError("Formato no valido");
            }
        }

        private void btnConcretarVenta_Click(object sender, EventArgs e)
        {
            _presentador.ConfirmarVenta();
        }

        public void MostrarExito(string mensaje)
        {
            MessageBox.Show(mensaje, "Operacion Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void LimpiarVentana()
        {
            InicializarVista();
            txtVuelto.Text = "0";
            TxtCantidad.Text = null;
            txtImporte.Text = null;
        }

        private void btnEliminarIndumentaria_Click(object sender, EventArgs e)
        {
            var fila = this.dataGridLineaVenta.CurrentRow.Index;
            _presentador.EliminarLineaDeVenta(fila);
        }

        private void btnRealizarVenta_Click(object sender, EventArgs e)
        {
            LimpiarVentana();
            MostrarExito("Venta cancelada");
        }
    }
}
