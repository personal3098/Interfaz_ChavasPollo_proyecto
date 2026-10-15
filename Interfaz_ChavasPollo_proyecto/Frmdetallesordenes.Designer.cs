namespace Interfaz_ChavasPollo_proyecto
{
    partial class Frmdetallesordenes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmdetallesordenes));
            panel1 = new Panel();
            labelfecha = new Label();
            labelidorden = new Label();
            labeltotal = new Label();
            labelemp = new Label();
            dgvdeta = new DataGridView();
            panel2 = new Panel();
            butimp = new Button();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvdeta).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Orange;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(labelfecha);
            panel1.Controls.Add(labelidorden);
            panel1.Controls.Add(labeltotal);
            panel1.Controls.Add(labelemp);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1057, 129);
            panel1.TabIndex = 2;
            // 
            // labelfecha
            // 
            labelfecha.AutoSize = true;
            labelfecha.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelfecha.Location = new Point(296, 90);
            labelfecha.Name = "labelfecha";
            labelfecha.Size = new Size(55, 23);
            labelfecha.TabIndex = 11;
            labelfecha.Text = "Fecha";
            // 
            // labelidorden
            // 
            labelidorden.AutoSize = true;
            labelidorden.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelidorden.Location = new Point(296, 20);
            labelidorden.Name = "labelidorden";
            labelidorden.Size = new Size(78, 23);
            labelidorden.TabIndex = 9;
            labelidorden.Text = "Id orden";
            // 
            // labeltotal
            // 
            labeltotal.AutoSize = true;
            labeltotal.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labeltotal.Location = new Point(603, 56);
            labeltotal.Name = "labeltotal";
            labeltotal.Size = new Size(49, 23);
            labeltotal.TabIndex = 1;
            labeltotal.Text = "Total";
            // 
            // labelemp
            // 
            labelemp.AutoSize = true;
            labelemp.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelemp.Location = new Point(296, 56);
            labelemp.Name = "labelemp";
            labelemp.Size = new Size(203, 23);
            labelemp.TabIndex = 2;
            labelemp.Text = "Empleado que lo realizo";
            // 
            // dgvdeta
            // 
            dgvdeta.BackgroundColor = Color.WhiteSmoke;
            dgvdeta.ColumnHeadersHeight = 29;
            dgvdeta.Dock = DockStyle.Fill;
            dgvdeta.Location = new Point(0, 129);
            dgvdeta.Name = "dgvdeta";
            dgvdeta.RowHeadersWidth = 51;
            dgvdeta.Size = new Size(1057, 509);
            dgvdeta.TabIndex = 8;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(35, 35, 35);
            panel2.Controls.Add(butimp);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 638);
            panel2.Name = "panel2";
            panel2.Size = new Size(1057, 66);
            panel2.TabIndex = 9;
            panel2.Paint += panel2_Paint;
            // 
            // butimp
            // 
            butimp.BackColor = Color.FromArgb(230, 126, 34);
            butimp.BackgroundImageLayout = ImageLayout.None;
            butimp.Cursor = Cursors.Hand;
            butimp.FlatStyle = FlatStyle.Popup;
            butimp.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            butimp.ForeColor = Color.White;
            butimp.Location = new Point(446, 19);
            butimp.Name = "butimp";
            butimp.Size = new Size(120, 35);
            butimp.TabIndex = 1;
            butimp.Text = "Imprimir";
            butimp.UseVisualStyleBackColor = false;
            butimp.Click += butimp_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.WhatsApp_Image_2026_01_30_at_8_40_06_AM;
            pictureBox1.Location = new Point(925, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(120, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // Frmdetallesordenes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1057, 704);
            Controls.Add(dgvdeta);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Frmdetallesordenes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Frmdetallesordenes";
            Load += Frmdetallesordenes_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvdeta).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label labelfecha;
        private Label labelidorden;
        private Label labeltotal;
        private Label labelemp;
        private DataGridView dgvdeta;
        private Panel panel2;
        private Button butimp;
        private PictureBox pictureBox1;
    }
}