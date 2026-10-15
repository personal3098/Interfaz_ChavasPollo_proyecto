namespace Interfaz_ChavasPollo_proyecto
{
    partial class frmmenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmmenu));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            textbusca = new TextBox();
            label4 = new Label();
            textmen = new TextBox();
            label5 = new Label();
            cmbcat = new ComboBox();
            textprecio = new TextBox();
            textnommen = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dgvmenu = new DataGridView();
            panel2 = new Panel();
            butbusca = new Button();
            buteli = new Button();
            btnmodi = new Button();
            butagr = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvmenu).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(65, 88, 10);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(textbusca);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textmen);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(cmbcat);
            panel1.Controls.Add(textprecio);
            panel1.Controls.Add(textnommen);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1057, 129);
            panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.WhatsApp_Image_2026_01_30_at_8_40_06_AM;
            pictureBox1.Location = new Point(925, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(120, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // textbusca
            // 
            textbusca.Location = new Point(644, 75);
            textbusca.Name = "textbusca";
            textbusca.Size = new Size(266, 27);
            textbusca.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(555, 79);
            label4.Name = "label4";
            label4.Size = new Size(83, 23);
            label4.TabIndex = 11;
            label4.Text = "Buscador";
            // 
            // textmen
            // 
            textmen.Location = new Point(208, 8);
            textmen.Name = "textmen";
            textmen.Size = new Size(287, 27);
            textmen.TabIndex = 10;
            textmen.KeyPress += textmen_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(99, 12);
            label5.Name = "label5";
            label5.Size = new Size(103, 23);
            label5.TabIndex = 9;
            label5.Text = "ID de menu";
            // 
            // cmbcat
            // 
            cmbcat.FormattingEnabled = true;
            cmbcat.Location = new Point(208, 92);
            cmbcat.Name = "cmbcat";
            cmbcat.Size = new Size(287, 28);
            cmbcat.TabIndex = 7;
            // 
            // textprecio
            // 
            textprecio.Location = new Point(644, 37);
            textprecio.Name = "textprecio";
            textprecio.Size = new Size(266, 27);
            textprecio.TabIndex = 6;
            textprecio.KeyPress += textprecio_KeyPress;
            // 
            // textnommen
            // 
            textnommen.Location = new Point(208, 49);
            textnommen.Name = "textnommen";
            textnommen.Size = new Size(287, 27);
            textnommen.TabIndex = 5;
            textnommen.TextChanged += textnommen_TextChanged;
            textnommen.KeyPress += textnommen_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 49);
            label1.Name = "label1";
            label1.Size = new Size(202, 23);
            label1.TabIndex = 1;
            label1.Text = "Nombre platillo/bebida";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(579, 37);
            label2.Name = "label2";
            label2.Size = new Size(59, 23);
            label2.TabIndex = 2;
            label2.Text = "Precio";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(114, 93);
            label3.Name = "label3";
            label3.Size = new Size(88, 23);
            label3.TabIndex = 3;
            label3.Text = "Categoria";
            // 
            // dgvmenu
            // 
            dgvmenu.BackgroundColor = Color.WhiteSmoke;
            dgvmenu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvmenu.Dock = DockStyle.Fill;
            dgvmenu.Location = new Point(0, 129);
            dgvmenu.Name = "dgvmenu";
            dgvmenu.RowHeadersWidth = 51;
            dgvmenu.Size = new Size(1057, 511);
            dgvmenu.TabIndex = 7;
            dgvmenu.CellClick += dgvmenu_CellClick;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 241, 151);
            panel2.Controls.Add(butbusca);
            panel2.Controls.Add(buteli);
            panel2.Controls.Add(btnmodi);
            panel2.Controls.Add(butagr);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 640);
            panel2.Name = "panel2";
            panel2.Size = new Size(1057, 64);
            panel2.TabIndex = 8;
            // 
            // butbusca
            // 
            butbusca.BackColor = Color.FromArgb(65, 88, 10);
            butbusca.BackgroundImageLayout = ImageLayout.None;
            butbusca.Cursor = Cursors.Hand;
            butbusca.FlatStyle = FlatStyle.Popup;
            butbusca.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            butbusca.ForeColor = Color.White;
            butbusca.Location = new Point(737, 17);
            butbusca.Name = "butbusca";
            butbusca.Size = new Size(120, 35);
            butbusca.TabIndex = 3;
            butbusca.Text = "Buscar";
            butbusca.UseVisualStyleBackColor = false;
            butbusca.Click += butbusca_Click;
            // 
            // buteli
            // 
            buteli.BackColor = Color.FromArgb(65, 88, 10);
            buteli.BackgroundImageLayout = ImageLayout.None;
            buteli.Cursor = Cursors.Hand;
            buteli.FlatStyle = FlatStyle.Popup;
            buteli.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buteli.ForeColor = Color.White;
            buteli.Location = new Point(528, 17);
            buteli.Name = "buteli";
            buteli.Size = new Size(120, 35);
            buteli.TabIndex = 2;
            buteli.Text = "Eliminar";
            buteli.UseVisualStyleBackColor = false;
            buteli.Click += buteli_Click;
            // 
            // btnmodi
            // 
            btnmodi.BackColor = Color.FromArgb(65, 88, 10);
            btnmodi.BackgroundImageLayout = ImageLayout.None;
            btnmodi.Cursor = Cursors.Hand;
            btnmodi.FlatStyle = FlatStyle.Popup;
            btnmodi.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnmodi.ForeColor = Color.White;
            btnmodi.Location = new Point(322, 17);
            btnmodi.Name = "btnmodi";
            btnmodi.Size = new Size(120, 35);
            btnmodi.TabIndex = 1;
            btnmodi.Text = "Modificar";
            btnmodi.UseVisualStyleBackColor = false;
            btnmodi.Click += btnmodi_Click;
            // 
            // butagr
            // 
            butagr.BackColor = Color.FromArgb(65, 88, 10);
            butagr.BackgroundImageLayout = ImageLayout.None;
            butagr.Cursor = Cursors.Hand;
            butagr.FlatStyle = FlatStyle.Popup;
            butagr.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            butagr.ForeColor = Color.White;
            butagr.Location = new Point(123, 17);
            butagr.Name = "butagr";
            butagr.Size = new Size(120, 35);
            butagr.TabIndex = 0;
            butagr.Text = "Agregar";
            butagr.UseVisualStyleBackColor = false;
            butagr.Click += butagr_Click;
            // 
            // frmmenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1057, 704);
            Controls.Add(dgvmenu);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmmenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu";
            Load += frmmenu_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvmenu).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox textbusc;
        private Label label6;
        private TextBox textmen;
        private Label label5;
        private ComboBox cmbprov;
        private ComboBox cmbcat;
        private TextBox textprecio;
        private TextBox textnommen;
        private Label label1;
        private Label label4;
        private Label label2;
        private Label label3;
        private DataGridView dgvmenu;
        private Panel panel2;
        private Button buteli;
        private Button btnmodi;
        private Button butagr;
        private TextBox textbusca;
        private Button butbusca;
        private PictureBox pictureBox1;
    }
}