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
    public partial class frmAlquileres : Form
    {
        int idAlquilerSeleccionado = 0;

        private readonly AlquilerControllers _alquiler = new AlquilerControllers();

        private readonly ClientesControllers _clientes = new ClientesControllers();

        private readonly VehiculosControllers _vehiculos = new VehiculosControllers();
        public frmAlquileres()
        {
            InitializeComponent();
        }

        private void cargarCombos()
        {
            cmbCliente.DataSource = _clientes.todos();
            cmbCliente.DisplayMember = "nombre";
            cmbCliente.ValueMember = "id_cliente";
            cmbCliente.SelectedIndex = -1;

            cmbVehiculo.DataSource = _vehiculos.todos();
            cmbVehiculo.DisplayMember = "placa";
            cmbVehiculo.ValueMember = "id_vehiculo";
            cmbVehiculo.SelectedIndex = -1;
        }

        private void cargarAlquileres()
        {
            dgvAlquiler.DataSource = null;
            dgvAlquiler.DataSource = _alquiler.todos();
        }

        private void frmAlquileres_Load(object sender, EventArgs e)
        {
            cargarCombos();
            cargarAlquileres();

            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Format = DateTimePickerFormat.Short;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedIndex == -1 ||
        cmbVehiculo.SelectedIndex == -1 ||
        txtCosto.Text.Trim() == "")
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }

            if (dtpFechaFin.Value.Date < dtpFechaInicio.Value.Date)
            {
                MessageBox.Show("La fecha de fin no puede ser anterior a la fecha de inicio");
                return;
            }

            try
            {
                if (!decimal.TryParse(txtCosto.Text.Trim(),
                    System.Globalization.NumberStyles.Number,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out decimal costo) || costo <= 0)
                {
                    MessageBox.Show("Ingrese un costo válido mayor que cero");
                    return;
                }

                AlquileresModel alquiler = new AlquileresModel();

                alquiler.id_cliente = Convert.ToInt32(cmbCliente.SelectedValue);
                alquiler.id_vehiculo = Convert.ToInt32(cmbVehiculo.SelectedValue);
                alquiler.fecha_inicio = dtpFechaInicio.Value;
                alquiler.fecha_fin = dtpFechaFin.Value;
                alquiler.costo = costo;

                AlquileresModel resultado = _alquiler.insertar(alquiler);

                if (resultado != null)
                {
                    MessageBox.Show("Alquiler registrado correctamente");

                    cargarAlquileres();
                    cargarCombos();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar alquiler: " + ex.Message);
            }
        }

        private void dgvAlquiler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvAlquiler.Rows[e.RowIndex];

                idAlquilerSeleccionado =
                    Convert.ToInt32(fila.Cells["id_alquiler"].Value);

                cmbCliente.SelectedValue =
                    Convert.ToInt32(fila.Cells["id_cliente"].Value);

                cmbVehiculo.SelectedValue =
                    Convert.ToInt32(fila.Cells["id_vehiculo"].Value);

                dtpFechaInicio.Value =
                    Convert.ToDateTime(fila.Cells["fecha_inicio"].Value);

                dtpFechaFin.Value =
                    Convert.ToDateTime(fila.Cells["fecha_fin"].Value);

                txtCosto.Text =
                    Convert.ToDecimal(fila.Cells["costo"].Value)
                    .ToString("0.00",
                        System.Globalization.CultureInfo.InvariantCulture);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            cmbCliente.SelectedIndex = -1;
            cmbVehiculo.SelectedIndex = -1;

            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            txtCosto.Clear();

            idAlquilerSeleccionado = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idAlquilerSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un alquiler de la tabla");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar este alquiler?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    if (_alquiler.eliminar(idAlquilerSeleccionado))
                    {
                        MessageBox.Show("Alquiler eliminado correctamente");

                        idAlquilerSeleccionado = 0;
                        cargarAlquileres();
                        cargarCombos();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el alquiler");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message);
                }
            }
        }
    }
}
