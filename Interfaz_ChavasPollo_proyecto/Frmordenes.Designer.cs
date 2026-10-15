namespace Interfaz_ChavasPollo_proyecto
{
    partial class Frmordenes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmordenes));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            labeltotal = new Label();
            nudcant = new NumericUpDown();
            cmbmenu = new ComboBox();
            label6 = new Label();
            cmbemp = new ComboBox();
            label1 = new Label();
            labelprecio = new Label();
            label2 = new Label();
            dgvord = new DataGridView();
            panel2 = new Panel();
            button1 = new Button();
            btguard = new Button();
            butagr = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudcant).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvord).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(65, 88, 10);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(labeltotal);
            panel1.Controls.Add(nudcant);
            panel1.Controls.Add(cmbmenu);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(cmbemp);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(labelprecio);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1057, 129);
            panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.WhatsApp_Image_2026_01_30_at_8_40_06_AM;
            pictureBox1.Location = new Point(925, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(120, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            // 
            // labeltotal
            // 
            labeltotal.AutoSize = true;
            labeltotal.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labeltotal.ForeColor = Color.White;
            labeltotal.Location = new Point(487, 83);
            labeltotal.Name = "labeltotal";
            labeltotal.Size = new Size(22, 23);
            labeltotal.TabIndex = 16;
            labeltotal.Text = "=";
            // 
            // nudcant
            // 
            nudcant.Location = new Point(548, 21);
            nudcant.Name = "nudcant";
            nudcant.Size = new Size(204, 27);
            nudcant.TabIndex = 15;
            // 
            // cmbmenu
            // 
            cmbmenu.FormattingEnabled = true;
            cmbmenu.Location = new Point(207, 78);
            cmbmenu.Name = "cmbmenu";
            cmbmenu.Size = new Size(198, 28);
            cmbmenu.TabIndex = 12;
            cmbmenu.SelectedIndexChanged += cmbmenu_SelectedIndexChanged_1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(134, 74);
            label6.Name = "label6";
            label6.Size = new Size(55, 23);
            label6.TabIndex = 11;
            label6.Text = "Menu";
            // 
            // cmbemp
            // 
            cmbemp.FormattingEnabled = true;
            cmbemp.Location = new Point(210, 21);
            cmbemp.Name = "cmbemp";
            cmbemp.Size = new Size(195, 28);
            cmbemp.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(28, 21);
            label1.Name = "label1";
            label1.Size = new Size(161, 23);
            label1.TabIndex = 1;
            label1.Text = "Nombre Empleado";
            // 
            // labelprecio
            // 
            labelprecio.AutoSize = true;
            labelprecio.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelprecio.Location = new Point(428, 55);
            labelprecio.Name = "labelprecio";
            labelprecio.Size = new Size(0, 23);
            labelprecio.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(459, 21);
            label2.Name = "label2";
            label2.Size = new Size(83, 23);
            label2.TabIndex = 2;
            label2.Text = "Cantidad";
            // 
            // dgvord
            // 
            dgvord.BackgroundColor = Color.WhiteSmoke;
            dgvord.ColumnHeadersHeight = 29;
            dgvord.Dock = DockStyle.Fill;
            dgvord.Location = new Point(0, 129);
            dgvord.Name = "dgvord";
            dgvord.RowHeadersWidth = 51;
            dgvord.Size = new Size(1057, 509);
            dgvord.TabIndex = 8;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 241, 151);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(btguard);
            panel2.Controls.Add(butagr);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 638);
            panel2.Name = "panel2";
            panel2.Size = new Size(1057, 66);
            panel2.TabIndex = 9;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(65, 88, 10);
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(640, 17);
            button1.Name = "button1";
            button1.Size = new Size(159, 35);
            button1.TabIndex = 2;
            button1.Text = "Ver historial";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btguard
            // 
            btguard.BackColor = Color.FromArgb(65, 88, 10);
            btguard.BackgroundImageLayout = ImageLayout.None;
            btguard.Cursor = Cursors.Hand;
            btguard.FlatStyle = FlatStyle.Popup;
            btguard.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btguard.ForeColor = Color.White;
            btguard.Location = new Point(445, 17);
            btguard.Name = "btguard";
            btguard.Size = new Size(120, 35);
            btguard.TabIndex = 1;
            btguard.Text = "Guardar";
            btguard.UseVisualStyleBackColor = false;
            btguard.Click += btguard_Click;
            // 
            // butagr
            // 
            butagr.BackColor = Color.FromArgb(65, 88, 10);
            butagr.BackgroundImageLayout = ImageLayout.None;
            butagr.Cursor = Cursors.Hand;
            butagr.FlatStyle = FlatStyle.Popup;
            butagr.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            butagr.ForeColor = Color.White;
            butagr.Location = new Point(227, 17);
            butagr.Name = "butagr";
            butagr.Size = new Size(120, 35);
            butagr.TabIndex = 0;
            butagr.Text = "Agregar";
            butagr.UseVisualStyleBackColor = false;
            butagr.Click += butagr_Click;
            // 
            // Frmordenes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1057, 704);
            Controls.Add(dgvord);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Frmordenes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ordenes";
            Load += Frmordenes_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudcant).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvord).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox textbusca;
        private ComboBox cmbmenu;
        private Label label6;
        private ComboBox cmbemp;
        private Label label1;
        private Label labelprecio;
        private Label label2;
        private DataGridView dgvord;
        private NumericUpDown nudcant;
        private Panel panel2;
        private Button btguard;
        private Button butagr;
        private Label labeltotal;
        private Button button1;
        private PictureBox pictureBox1;
    }
}