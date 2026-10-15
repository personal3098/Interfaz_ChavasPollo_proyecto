namespace Interfaz_ChavasPollo_proyecto
{
    partial class Frmempleados
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmempleados));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            textbusca = new TextBox();
            label3 = new Label();
            cmbturno = new ComboBox();
            label6 = new Label();
            textidemp = new TextBox();
            label5 = new Label();
            cmbcargo = new ComboBox();
            texttel = new TextBox();
            textnombrem = new TextBox();
            label1 = new Label();
            label4 = new Label();
            label2 = new Label();
            dgvemp = new DataGridView();
            panel2 = new Panel();
            butb = new Button();
            buteli = new Button();
            btnmod = new Button();
            butagr = new Button();
            guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvemp).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(65, 88, 10);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(textbusca);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cmbturno);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(textidemp);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(cmbcargo);
            panel1.Controls.Add(texttel);
            panel1.Controls.Add(textnombrem);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1057, 129);
            panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.WhatsApp_Image_2026_01_30_at_8_40_06_AM;
            pictureBox1.Location = new Point(927, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(120, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // textbusca
            // 
            textbusca.Location = new Point(655, 91);
            textbusca.Name = "textbusca";
            textbusca.Size = new Size(266, 27);
            textbusca.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(555, 92);
            label3.Name = "label3";
            label3.Size = new Size(83, 23);
            label3.TabIndex = 13;
            label3.Text = "Buscador";
            // 
            // cmbturno
            // 
            cmbturno.FormattingEnabled = true;
            cmbturno.Location = new Point(655, 55);
            cmbturno.Name = "cmbturno";
            cmbturno.Size = new Size(266, 28);
            cmbturno.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(111, 91);
            label6.Name = "label6";
            label6.Size = new Size(78, 23);
            label6.TabIndex = 11;
            label6.Text = "Telefono";
            // 
            // textidemp
            // 
            textidemp.Location = new Point(209, 12);
            textidemp.Name = "textidemp";
            textidemp.Size = new Size(287, 27);
            textidemp.TabIndex = 10;
            textidemp.KeyPress += textidemp_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(76, 16);
            label5.Name = "label5";
            label5.Size = new Size(113, 23);
            label5.TabIndex = 9;
            label5.Text = "ID empleado";
            // 
            // cmbcargo
            // 
            cmbcargo.FormattingEnabled = true;
            cmbcargo.Location = new Point(655, 16);
            cmbcargo.Name = "cmbcargo";
            cmbcargo.Size = new Size(266, 28);
            cmbcargo.TabIndex = 7;
            // 
            // texttel
            // 
            texttel.Location = new Point(209, 90);
            texttel.Name = "texttel";
            texttel.Size = new Size(287, 27);
            texttel.TabIndex = 6;
            texttel.KeyPress += texttel_KeyPress;
            // 
            // textnombrem
            // 
            textnombrem.Location = new Point(209, 51);
            textnombrem.Name = "textnombrem";
            textnombrem.Size = new Size(287, 27);
            textnombrem.TabIndex = 5;
            textnombrem.KeyPress += textnombrem_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(28, 55);
            label1.Name = "label1";
            label1.Size = new Size(161, 23);
            label1.TabIndex = 1;
            label1.Text = "Nombre Empleado";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(582, 55);
            label4.Name = "label4";
            label4.Size = new Size(56, 23);
            label4.TabIndex = 4;
            label4.Text = "Turno";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(580, 16);
            label2.Name = "label2";
            label2.Size = new Size(58, 23);
            label2.TabIndex = 2;
            label2.Text = "Cargo";
            // 
            // dgvemp
            // 
            dgvemp.BackgroundColor = Color.White;
            dgvemp.ColumnHeadersHeight = 29;
            dgvemp.Dock = DockStyle.Bottom;
            dgvemp.Location = new Point(0, 497);
            dgvemp.Name = "dgvemp";
            dgvemp.RowHeadersWidth = 51;
            dgvemp.Size = new Size(1057, 141);
            dgvemp.TabIndex = 7;
            dgvemp.CellClick += dgvemp_CellClick;
            dgvemp.CellContentClick += dgvemp_CellContentClick;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 241, 151);
            panel2.Controls.Add(butb);
            panel2.Controls.Add(buteli);
            panel2.Controls.Add(btnmod);
            panel2.Controls.Add(butagr);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 638);
            panel2.Name = "panel2";
            panel2.Size = new Size(1057, 66);
            panel2.TabIndex = 8;
            // 
            // butb
            // 
            butb.BackColor = Color.FromArgb(65, 88, 10);
            butb.BackgroundImageLayout = ImageLayout.None;
            butb.Cursor = Cursors.Hand;
            butb.FlatStyle = FlatStyle.Popup;
            butb.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            butb.ForeColor = Color.White;
            butb.Location = new Point(755, 17);
            butb.Name = "butb";
            butb.Size = new Size(120, 35);
            butb.TabIndex = 3;
            butb.Text = "Buscar";
            butb.UseVisualStyleBackColor = false;
            butb.Click += butb_Click;
            // 
            // buteli
            // 
            buteli.BackColor = Color.FromArgb(65, 88, 10);
            buteli.BackgroundImageLayout = ImageLayout.None;
            buteli.Cursor = Cursors.Hand;
            buteli.FlatStyle = FlatStyle.Popup;
            buteli.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buteli.ForeColor = Color.White;
            buteli.Location = new Point(580, 17);
            buteli.Name = "buteli";
            buteli.Size = new Size(120, 35);
            buteli.TabIndex = 2;
            buteli.Text = "Eliminar";
            buteli.UseVisualStyleBackColor = false;
            buteli.Click += buteli_Click;
            // 
            // btnmod
            // 
            btnmod.BackColor = Color.FromArgb(65, 88, 10);
            btnmod.BackgroundImageLayout = ImageLayout.None;
            btnmod.Cursor = Cursors.Hand;
            btnmod.FlatStyle = FlatStyle.Popup;
            btnmod.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnmod.ForeColor = Color.White;
            btnmod.Location = new Point(376, 17);
            btnmod.Name = "btnmod";
            btnmod.Size = new Size(120, 35);
            btnmod.TabIndex = 1;
            btnmod.Text = "Modificar";
            btnmod.UseVisualStyleBackColor = false;
            btnmod.Click += btnmod_Click;
            // 
            // butagr
            // 
            butagr.BackColor = Color.FromArgb(65, 88, 10);
            butagr.BackgroundImageLayout = ImageLayout.None;
            butagr.Cursor = Cursors.Hand;
            butagr.FlatStyle = FlatStyle.Popup;
            butagr.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            butagr.ForeColor = Color.White;
            butagr.Location = new Point(175, 17);
            butagr.Name = "butagr";
            butagr.Size = new Size(120, 35);
            butagr.TabIndex = 0;
            butagr.Text = "Agregar";
            butagr.UseVisualStyleBackColor = false;
            butagr.Click += butagr_Click;
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.BorderRadius = 50;
            guna2TextBox1.Cursor = Cursors.IBeam;
            guna2TextBox1.CustomizableEdges = customizableEdges1;
            guna2TextBox1.DefaultText = "jack mejia ";
            guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Font = new Font("Segoe UI", 9F);
            guna2TextBox1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Location = new Point(262, 264);
            guna2TextBox1.Margin = new Padding(3, 4, 3, 4);
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PlaceholderText = "";
            guna2TextBox1.SelectedText = "";
            guna2TextBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2TextBox1.Size = new Size(234, 70);
            guna2TextBox1.TabIndex = 15;
            // 
            // guna2Button1
            // 
            guna2Button1.BorderRadius = 30;
            guna2Button1.CustomizableEdges = customizableEdges3;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.Font = new Font("Segoe UI", 9F);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(47, 183);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Button1.Size = new Size(142, 51);
            guna2Button1.TabIndex = 16;
            guna2Button1.Text = "guna2Button1";
            // 
            // Frmempleados
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1057, 704);
            Controls.Add(guna2Button1);
            Controls.Add(guna2TextBox1);
            Controls.Add(dgvemp);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Frmempleados";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Empleados";
            Load += Frmempleados_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvemp).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label6;
        private TextBox textidemp;
        private Label label5;
        private ComboBox cmbcargo;
        private TextBox texttel;
        private TextBox textnombrem;
        private Label label1;
        private Label label4;
        private Label label2;
        private DataGridView dgvemp;
        private Panel panel2;
        private Button butb;
        private Button buteli;
        private Button btnmod;
        private Button butagr;
        private ComboBox cmbturno;
        private TextBox textbusca;
        private Label label3;
        private PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}