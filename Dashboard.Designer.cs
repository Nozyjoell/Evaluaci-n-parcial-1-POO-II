namespace AlquilerDeVehiculos
{
    partial class Dashboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            menuStrip1 = new MenuStrip();
            Dasboard = new ToolStripMenuItem();
            Vechiculos = new ToolStripMenuItem();
            Clientes = new ToolStripMenuItem();
            Alquilires = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(menuStrip1);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 266;
            splitContainer1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { Dasboard, Vechiculos, Clientes, Alquilires });
            menuStrip1.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(266, 102);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // Dasboard
            // 
            Dasboard.Name = "Dasboard";
            Dasboard.Size = new Size(259, 24);
            Dasboard.Text = "Dasboard";
            // 
            // Vechiculos
            // 
            Vechiculos.Name = "Vechiculos";
            Vechiculos.Size = new Size(259, 24);
            Vechiculos.Text = "Vehiculos";
            Vechiculos.Click += Vechiculos_Click;
            // 
            // Clientes
            // 
            Clientes.Name = "Clientes";
            Clientes.Size = new Size(259, 24);
            Clientes.Text = "Clientes";
            Clientes.Click += Clientes_Click;
            // 
            // Alquilires
            // 
            Alquilires.Name = "Alquilires";
            Alquilires.Size = new Size(259, 24);
            Alquilires.Text = "Alquileres";
            Alquilires.Click += Alquilires_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            MainMenuStrip = menuStrip1;
            Name = "Dashboard";
            Text = "Menu Principal";
            FormClosing += Dashboard_FormClosing;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem Dasboard;
        private ToolStripMenuItem Vechiculos;
        private ToolStripMenuItem Clientes;
        private ToolStripMenuItem Alquilires;
    }
}
