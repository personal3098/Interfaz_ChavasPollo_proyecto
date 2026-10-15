//De esta manera llama a sql y usa sus datos
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Interfaz_ChavasPollo_proyecto
{


    public partial class Frmprincipal : Form
    {

        public Frmprincipal()
        {
            InitializeComponent();
        }
        SqlConnection cn =
    new SqlConnection(Conexion.cadena);
        private void Frmprincipal_Load(object sender, EventArgs e)
        {

        }
        //Este metodo se ocupo para comprobar la conexion actualmente no se ocupa para nada
        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn =
                    new SqlConnection(Conexion.cadena);

                cn.Open();

                MessageBox.Show("Conexión exitosa");

                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }
        private void btnmenu_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        // Se crea un objeto dentro de la accion que de click en inventario para llamar la debida form
        //Se usa lo mismo para los demas botones del menu
        private void btninv_Click(object sender, EventArgs e)
        {
            Frminventario frm = new Frminventario();
            frm.Show();
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        // Misma logica siempre para llamar su debida form
        private void button2_Click(object sender, EventArgs e)
        {
            frmmenu fr2 = new frmmenu();
            fr2.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Frmempleados fr3 = new Frmempleados();
            fr3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Frmordenes fr4 = new Frmordenes();
            fr4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Frmhistorial fr5 = new Frmhistorial();
            fr5.Show();

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }
    }
}

