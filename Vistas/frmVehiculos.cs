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
    public partial class frmVehiculos : Form
    {
        int idVehiculoSeleccionado = 0;

        private readonly VehiculosControllers _vehiculo = new VehiculosControllers();
        public frmVehiculos()
        {
            InitializeComponent();
        }

        private void Vehiculos_Load(object sender, EventArgs e)
        {
            cmbEstado.Items.Clear();

            cmbEstado.Items.Add("Disponible");
            cmbEstado.Items.Add("Alquilado");
            cmbEstado.SelectedIndex = 0;

            cargarVehiculos();
        }

        private void cargarVehiculos()
        {
            dgvVehiculos.DataSource = null;
            dgvVehiculos.DataSource = _vehiculo.todos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtMarca.Text.Trim() == "" ||
                txtModelo.Text.Trim() == "" ||
                txtPlaca.Text.Trim() == "" ||
                cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }

            try
            {
                VehiculosModel vehiculo = new VehiculosModel();

                vehiculo.marca = txtMarca.Text.Trim();
                vehiculo.modelo = txtModelo.Text.Trim();
                vehiculo.placa = txtPlaca.Text.Trim();
                vehiculo.estado = cmbEstado.Text;

                VehiculosModel resultado = _vehiculo.insertar(vehiculo);

                if (_vehiculo != null)
                {
                    MessageBox.Show("Vehiculo registrado correctamente");

                    cargarVehiculos();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                cargarVehiculos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtMarca.Clear();
            txtModelo.Clear();
            txtPlaca.Clear();

            cmbEstado.SelectedIndex = 0;

            idVehiculoSeleccionado = 0;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvVehiculos.Rows[e.RowIndex];

                idVehiculoSeleccionado = Convert.ToInt32(fila.Cells["id_vehiculo"].Value);

                txtMarca.Text = fila.Cells["marca"].Value.ToString();
                txtModelo.Text = fila.Cells["modelo"].Value.ToString();
                txtPlaca.Text = fila.Cells["placa"].Value.ToString();
                cmbEstado.Text = fila.Cells["estado"].Value.ToString();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idVehiculoSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un vehiculo de la tabla");
                return;
            }

            DialogResult respuesta = MessageBox.Show("Desea eliminar este vehiculo?", "Confimar Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    if (_vehiculo.eliminar(idVehiculoSeleccionado))
                    {
                        MessageBox.Show("Vehiculo eliminado exitosamente");
                        idVehiculoSeleccionado = 0;
                        cargarVehiculos();
                        LimpiarCampos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo eliminar el vehiculo", ex.Message);
                }
            }
        }
    }
}
