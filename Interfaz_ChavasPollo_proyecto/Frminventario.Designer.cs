namespace Interfaz_ChavasPollo_proyecto
{
    partial class Frminventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frminventario));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            textbusc = new TextBox();
            label6 = new Label();
            textid = new TextBox();
            label5 = new Label();
            cmbprov = new ComboBox();
            cmbuni = new ComboBox();
            textcant = new TextBox();
            textnombrep = new TextBox();
            label1 = new Label();
            label4 = new Label();
            label2 = new Label();
            label3 = new Label();
            panel2 = new Panel();
            btnact = new Button();
            button4 = new Button();
            button3 = new Button();
            btnmodi = new Button();
            button1 = new Button();
            dgvinv = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvinv).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(65, 88, 10);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(textbusc);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(textid);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(cmbprov);
            panel1.Controls.Add(cmbuni);
            panel1.Controls.Add(textcant);
            panel1.Controls.Add(textnombrep);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1057, 129);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.WhatsApp_Image_2026_01_30_at_8_40_06_AM;
            pictureBox1.Location = new Point(925, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(120, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // textbusc
            // 
            textbusc.Location = new Point(614, 90);
            textbusc.Name = "textbusc";
            textbusc.Size = new Size(266, 27);
            textbusc.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(525, 91);
            label6.Name = "label6";
            label6.Size = new Size(83, 23);
            label6.TabIndex = 11;
            label6.Text = "Buscador";
            // 
            // textid
            // 
            textid.Location = new Point(173, 12);
            textid.Name = "textid";
            textid.Size = new Size(287, 27);
            textid.TabIndex = 10;
            textid.KeyPress += textid_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(129, 13);
            label5.Name = "label5";
            label5.Size = new Size(28, 23);
            label5.TabIndex = 9;
            label5.Text = "ID";
            // 
            // cmbprov
            // 
            cmbprov.FormattingEnabled = true;
            cmbprov.Location = new Point(614, 51);
            cmbprov.Name = "cmbprov";
            cmbprov.Size = new Size(266, 28);
            cmbprov.TabIndex = 8;
            // 
            // cmbuni
            // 
            cmbuni.FormattingEnabled = true;
            cmbuni.Location = new Point(614, 11);
            cmbuni.Name = "cmbuni";
            cmbuni.Size = new Size(266, 28);
            cmbuni.TabIndex = 7;
            // 
            // textcant
            // 
            textcant.Location = new Point(173, 87);
            textcant.Name = "textcant";
            textcant.Size = new Size(287, 27);
            textcant.TabIndex = 6;
            textcant.KeyPress += textcant_KeyPress;
            // 
            // textnombrep
            // 
            textnombrep.Location = new Point(173, 51);
            textnombrep.Name = "textnombrep";
            textnombrep.Size = new Size(287, 27);
            textnombrep.TabIndex = 5;
            textnombrep.KeyPress += textnombrep_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 52);
            label1.Name = "label1";
            label1.Size = new Size(155, 23);
            label1.TabIndex = 1;
            label1.Text = "Nombre producto";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(516, 51);
            label4.Name = "label4";
            label4.Size = new Size(92, 23);
            label4.TabIndex = 4;
            label4.Text = "Proveedor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(84, 91);
            label2.Name = "label2";
            label2.Size = new Size(83, 23);
            label2.TabIndex = 2;
            label2.Text = "Cantidad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(531, 13);
            label3.Name = "label3";
            label3.Size = new Size(68, 23);
            label3.TabIndex = 3;
            label3.Text = "Unidad";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 241, 151);
            panel2.Controls.Add(btnact);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(btnmodi);
            panel2.Controls.Add(button1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 638);
            panel2.Name = "panel2";
            panel2.Size = new Size(1057, 66);
            panel2.TabIndex = 5;
            // 
            // btnact
            // 
            btnact.BackColor = Color.FromArgb(65, 88, 10);
            btnact.BackgroundImageLayout = ImageLayout.None;
            btnact.Cursor = Cursors.Hand;
            btnact.FlatStyle = FlatStyle.Popup;
            btnact.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnact.ForeColor = Color.White;
            btnact.Location = new Point(843, 17);
            btnact.Name = "btnact";
            btnact.Size = new Size(182, 35);
            btnact.TabIndex = 4;
            btnact.Text = "Mostrar/Actualizar";
            btnact.UseVisualStyleBackColor = false;
            btnact.Click += btnact_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(65, 88, 10);
            button4.BackgroundImageLayout = ImageLayout.None;
            button4.Cursor = Cursors.Hand;
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Location = new Point(664, 17);
            button4.Name = "button4";
            button4.Size = new Size(120, 35);
            button4.TabIndex = 3;
            button4.Text = "Buscar";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(65, 88, 10);
            button3.BackgroundImageLayout = ImageLayout.None;
            button3.Cursor = Cursors.Hand;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(456, 17);
            button3.Name = "button3";
            button3.Size = new Size(120, 35);
            button3.TabIndex = 2;
            button3.Text = "Eliminar";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // btnmodi
            // 
            btnmodi.BackColor = Color.FromArgb(65, 88, 10);
            btnmodi.BackgroundImageLayout = ImageLayout.None;
            btnmodi.Cursor = Cursors.Hand;
            btnmodi.FlatStyle = FlatStyle.Popup;
            btnmodi.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnmodi.ForeColor = Color.White;
            btnmodi.Location = new Point(243, 17);
            btnmodi.Name = "btnmodi";
            btnmodi.Size = new Size(120, 35);
            btnmodi.TabIndex = 1;
            btnmodi.Text = "Modificar";
            btnmodi.UseVisualStyleBackColor = false;
            btnmodi.Click += btnmodi_Click_1;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(65, 88, 10);
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(53, 17);
            button1.Name = "button1";
            button1.Size = new Size(120, 35);
            button1.TabIndex = 0;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dgvinv
            // 
            dgvinv.BackgroundColor = Color.WhiteSmoke;
            dgvinv.ColumnHeadersHeight = 29;
            dgvinv.Dock = DockStyle.Fill;
            dgvinv.Location = new Point(0, 129);
            dgvinv.Name = "dgvinv";
            dgvinv.RowHeadersWidth = 51;
            dgvinv.Size = new Size(1057, 509);
            dgvinv.TabIndex = 6;
            dgvinv.CellClick += dgvinv_CellClick;
            dgvinv.CellContentClick += dgvinv_CellContentClick;
            dgvinv.CellMouseClick += dgvinv_CellMouseClick;
            // 
            // Frminventario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1057, 704);
            Controls.Add(dgvinv);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Frminventario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inventario";
            Load += Frminventario_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvinv).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Panel panel2;
        private TextBox textcant;
        private TextBox textnombrep;
        private Button button1;
        private ComboBox cmbprov;
        private ComboBox cmbuni;
        private Button btnact;
        private Button button4;
        private Button button3;
        private Button btnmodi;
        private DataGridView dgvinv;
        private TextBox textid;
        private Label label5;
        private TextBox textbusc;
        private Label label6;
        private PictureBox pictureBox1;
    }
}