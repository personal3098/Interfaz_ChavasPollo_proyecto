namespace Interfaz_ChavasPollo_proyecto
{
    partial class Frmhistorial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmhistorial));
            panel1 = new Panel();
            dtphasta = new DateTimePicker();
            dtpdesde = new DateTimePicker();
            label1 = new Label();
            labelprecio = new Label();
            label2 = new Label();
            dgvhisto = new DataGridView();
            panel2 = new Panel();
            buteli = new Button();
            butbusc = new Button();
            butcargar = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvhisto).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(65, 88, 10);
            panel1.Controls.Add(dtphasta);
            panel1.Controls.Add(dtpdesde);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(labelprecio);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1057, 92);
            panel1.TabIndex = 3;
            // 
            // dtphasta
            // 
            dtphasta.Location = new Point(627, 32);
            dtphasta.Name = "dtphasta";
            dtphasta.Size = new Size(250, 27);
            dtphasta.TabIndex = 18;
            // 
            // dtpdesde
            // 
            dtpdesde.Location = new Point(195, 28);
            dtpdesde.Name = "dtpdesde";
            dtpdesde.Size = new Size(250, 27);
            dtpdesde.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(130, 28);
            label1.Name = "label1";
            label1.Size = new Size(59, 23);
            label1.TabIndex = 1;
            label1.Text = "Desde";
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
            label2.Location = new Point(566, 32);
            label2.Name = "label2";
            label2.Size = new Size(55, 23);
            label2.TabIndex = 2;
            label2.Text = "Hasta";
            // 
            // dgvhisto
            // 
            dgvhisto.BackgroundColor = Color.WhiteSmoke;
            dgvhisto.ColumnHeadersHeight = 29;
            dgvhisto.Dock = DockStyle.Fill;
            dgvhisto.Location = new Point(0, 92);
            dgvhisto.Name = "dgvhisto";
            dgvhisto.RowHeadersWidth = 51;
            dgvhisto.Size = new Size(1057, 546);
            dgvhisto.TabIndex = 17;
            dgvhisto.CellDoubleClick += dgvhisto_CellDoubleClick;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 241, 151);
            panel2.Controls.Add(buteli);
            panel2.Controls.Add(butbusc);
            panel2.Controls.Add(butcargar);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 638);
            panel2.Name = "panel2";
            panel2.Size = new Size(1057, 66);
            panel2.TabIndex = 18;
            // 
            // buteli
            // 
            buteli.BackColor = Color.Red;
            buteli.BackgroundImageLayout = ImageLayout.None;
            buteli.Cursor = Cursors.Hand;
            buteli.FlatStyle = FlatStyle.Popup;
            buteli.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buteli.ForeColor = Color.White;
            buteli.Location = new Point(868, 19);
            buteli.Name = "buteli";
            buteli.Size = new Size(177, 35);
            buteli.TabIndex = 2;
            buteli.Text = "Eliminar historial";
            buteli.UseVisualStyleBackColor = false;
            buteli.Click += buteli_Click;
            // 
            // butbusc
            // 
            butbusc.BackColor = Color.FromArgb(65, 88, 10);
            butbusc.BackgroundImageLayout = ImageLayout.None;
            butbusc.Cursor = Cursors.Hand;
            butbusc.FlatStyle = FlatStyle.Popup;
            butbusc.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            butbusc.ForeColor = Color.White;
            butbusc.Location = new Point(566, 19);
            butbusc.Name = "butbusc";
            butbusc.Size = new Size(120, 35);
            butbusc.TabIndex = 1;
            butbusc.Text = "Buscar";
            butbusc.UseVisualStyleBackColor = false;
            butbusc.Click += butbusc_Click;
            // 
            // butcargar
            // 
            butcargar.BackColor = Color.FromArgb(65, 88, 10);
            butcargar.BackgroundImageLayout = ImageLayout.None;
            butcargar.Cursor = Cursors.Hand;
            butcargar.FlatStyle = FlatStyle.Popup;
            butcargar.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            butcargar.ForeColor = Color.White;
            butcargar.Location = new Point(325, 19);
            butcargar.Name = "butcargar";
            butcargar.Size = new Size(120, 35);
            butcargar.TabIndex = 0;
            butcargar.Text = "Cargar";
            butcargar.UseVisualStyleBackColor = false;
            butcargar.Click += butcargar_Click;
            // 
            // Frmhistorial
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1057, 704);
            Controls.Add(dgvhisto);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Frmhistorial";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Historial";
            Load += Frmhistorial_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvhisto).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label labelprecio;
        private Label label2;
        private DataGridView dgvhisto;
        private DateTimePicker dtpdesde;
        private Panel panel2;
        private Button butcargar;
        private DateTimePicker dtphasta;
        private Button butbusc;
        private Button buteli;
    }
}