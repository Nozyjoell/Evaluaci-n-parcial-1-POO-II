namespace AlquilerDeVehiculos.Vistas
{
    partial class frmAlquileres
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvAlquiler = new DataGridView();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            btnGuardar = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cmbCliente = new ComboBox();
            cmbVehiculo = new ComboBox();
            dtpFechaInicio = new DateTimePicker();
            dtpFechaFin = new DateTimePicker();
            label5 = new Label();
            label6 = new Label();
            txtCosto = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvAlquiler).BeginInit();
            SuspendLayout();
            // 
            // dgvAlquiler
            // 
            dgvAlquiler.AllowUserToAddRows = false;
            dgvAlquiler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAlquiler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlquiler.Location = new Point(427, 84);
            dgvAlquiler.MultiSelect = false;
            dgvAlquiler.Name = "dgvAlquiler";
            dgvAlquiler.ReadOnly = true;
            dgvAlquiler.RowHeadersWidth = 51;
            dgvAlquiler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlquiler.Size = new Size(581, 350);
            dgvAlquiler.TabIndex = 25;
            dgvAlquiler.CellClick += dgvAlquiler_CellClick;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(457, 588);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(151, 76);
            btnLimpiar.TabIndex = 24;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(244, 588);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(151, 76);
            btnEliminar.TabIndex = 23;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(43, 588);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(151, 76);
            btnGuardar.TabIndex = 22;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(43, 281);
            label4.Name = "label4";
            label4.Size = new Size(153, 28);
            label4.TabIndex = 20;
            label4.Text = "Fecha de Inicio";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 184);
            label3.Name = "label3";
            label3.Size = new Size(93, 28);
            label3.TabIndex = 18;
            label3.Text = "Vehiculo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 98);
            label2.Name = "label2";
            label2.Size = new Size(78, 28);
            label2.TabIndex = 16;
            label2.Text = "Cliente";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(230, 40);
            label1.Name = "label1";
            label1.Size = new Size(290, 28);
            label1.TabIndex = 15;
            label1.Text = "Gestion Alquiler de Vehiculos";
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(43, 129);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(264, 36);
            cmbCliente.TabIndex = 26;
            // 
            // cmbVehiculo
            // 
            cmbVehiculo.FormattingEnabled = true;
            cmbVehiculo.Location = new Point(43, 215);
            cmbVehiculo.Name = "cmbVehiculo";
            cmbVehiculo.Size = new Size(264, 36);
            cmbVehiculo.TabIndex = 27;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Location = new Point(43, 312);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(264, 34);
            dtpFechaInicio.TabIndex = 28;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Location = new Point(43, 400);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(264, 34);
            dtpFechaFin.TabIndex = 30;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(43, 369);
            label5.Name = "label5";
            label5.Size = new Size(129, 28);
            label5.TabIndex = 29;
            label5.Text = "Fecha de Fin";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(43, 450);
            label6.Name = "label6";
            label6.Size = new Size(65, 28);
            label6.TabIndex = 31;
            label6.Text = "Costo";
            // 
            // txtCosto
            // 
            txtCosto.Location = new Point(47, 481);
            txtCosto.Multiline = true;
            txtCosto.Name = "txtCosto";
            txtCosto.Size = new Size(260, 45);
            txtCosto.TabIndex = 32;
            // 
            // frmAlquileres
            // 
            AutoScaleDimensions = new SizeF(12F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1079, 699);
            Controls.Add(txtCosto);
            Controls.Add(label6);
            Controls.Add(dtpFechaFin);
            Controls.Add(label5);
            Controls.Add(dtpFechaInicio);
            Controls.Add(cmbVehiculo);
            Controls.Add(cmbCliente);
            Controls.Add(dgvAlquiler);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnGuardar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            Margin = new Padding(4);
            Name = "frmAlquileres";
            Text = "Alquiler";
            Load += frmAlquileres_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAlquiler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvAlquiler;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Button btnGuardar;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cmbCliente;
        private ComboBox cmbVehiculo;
        private DateTimePicker dtpFechaInicio;
        private DateTimePicker dtpFechaFin;
        private Label label5;
        private Label label6;
        private TextBox txtCosto;
    }
}