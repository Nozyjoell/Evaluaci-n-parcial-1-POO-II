using AlquilerDeVehiculos.Controladores;
using AlquilerDeVehiculos.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AlquilerDeVehiculos.Vistas
{
    public partial class frmClientes : Form
    {
        int idClienteSeleccionado = 0;

        private readonly ClientesControllers _cliente = new ClientesControllers();
        public frmClientes()
        {
            InitializeComponent();
        }

        private void cargarClientes()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = _cliente.todos();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            cargarClientes();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "" ||
        txtCedula.Text.Trim() == "")
            {
                MessageBox.Show("Complete los campos obligatorios");
                return;
            }

            try
            {
                ClientesModel cliente = new ClientesModel();

                cliente.nombre = txtNombre.Text.Trim();
                cliente.cedula = txtCedula.Text.Trim();
                cliente.telefono = txtTelefono.Text.Trim();

                ClientesModel resultado = _cliente.insertar(cliente);

                if (resultado != null)
                {
                    MessageBox.Show("Cliente registrado correctamente");

                    cargarClientes();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];

                idClienteSeleccionado =
                    Convert.ToInt32(fila.Cells["id_cliente"].Value);

                txtNombre.Text = fila.Cells["nombre"].Value.ToString();
                txtCedula.Text = fila.Cells["cedula"].Value.ToString();
                txtTelefono.Text = fila.Cells["telefono"].Value?.ToString() ?? "";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un cliente de la tabla");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar este cliente?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    if (_cliente.eliminar(idClienteSeleccionado))
                    {
                        MessageBox.Show("Cliente eliminado correctamente");

                        idClienteSeleccionado = 0;
                        cargarClientes();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el cliente");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "No se puede eliminar el cliente. " + ex.Message);
                }
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCedula.Clear();
            txtTelefono.Clear();

            idClienteSeleccionado = 0;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
