using AlquilerDeVehiculos.Base_Datos;
using AlquilerDeVehiculos.Recursos;
using MySql.Data.MySqlClient;
using AlquilerDeVehiculos.Vistas;

namespace AlquilerDeVehiculos
{
    public partial class Dashboard : Form
    {
        private readonly MenuRenders menuRenderer = new MenuRenders();
        public Dashboard()
        {
            InitializeComponent();

            menuStrip1.Dock = DockStyle.Left;
            menuStrip1.AutoSize = true;

            //menuStrip1.Width = 220;

            menuStrip1.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            menuStrip1.BackColor = Color.FromArgb(20, 50, 41);
            menuStrip1.Renderer = menuRenderer;

            foreach (ToolStripItem item in menuStrip1.Items)
            {
                item.AutoSize = false;

                item.Size = new Size(210, 50);
                item.ForeColor = Color.White;
                item.TextAlign = ContentAlignment.MiddleLeft;

                item.Click += SeleccionaItem;

            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void SeleccionaItem(object? sender, EventArgs e)
        {
            menuRenderer.ItemActivo = sender as ToolStripItem;
            menuStrip1.Invalidate();
        }

        private void Vechiculos_Click(object sender, EventArgs e)
        {
            var vehiculos = new frmVehiculos();
            vehiculos.ShowDialog();
        }

        private void Clientes_Click(object sender, EventArgs e)
        {
            var clientes = new frmClientes();
            clientes.ShowDialog();
        }

        private void Alquilires_Click(object sender, EventArgs e)
        {
            var alquiler = new frmAlquileres();
            alquiler.ShowDialog();
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
        }
    }
}
