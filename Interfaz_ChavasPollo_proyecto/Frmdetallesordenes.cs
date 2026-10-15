using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Interfaz_ChavasPollo_proyecto
{
    public partial class Frmdetallesordenes : Form
    {
        public Frmdetallesordenes(int idOrden)
        {
            InitializeComponent();
            idOrdenGlobal = idOrden;
        }

        SqlConnection cn =
    new SqlConnection(Conexion.cadena);
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private int idOrdenGlobal;

        //De esta manera muestra la lista de ordenes realizadas segun su id automatizado por identity
        //(ojo ya se han hecho pruebas por lo que el numero ya va corriendo)

        private void Frmdetallesordenes_Load(object sender, EventArgs e)
        {
            //Esta se muestra en un label
            labelidorden.Text = "Orden #" + idOrdenGlobal;

            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                string sql = @" SELECT 
            m.nombre_platillo AS Producto,
            d.cantidad,
            m.precio,
            (d.cantidad * m.precio) AS Subtotal,
            o.fecha,
            e.nombre AS Empleado
        FROM detalleordenes d
        INNER JOIN menu m ON d.id_menu = m.id_menu
        INNER JOIN ordenes o ON d.id_orden = o.id_orden
        INNER JOIN empleados e ON o.id_empleado = e.id_empleado
        WHERE d.id_orden = @id";

                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                da.SelectCommand.Parameters.AddWithValue("@id", idOrdenGlobal);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvdeta.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

                dgvdeta.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvdeta.ReadOnly = true;

                dgvdeta.DataSource = dt;


                if (dt.Rows.Count > 0)
                {
                    labelfecha.Text = dt.Rows[0]["fecha"].ToString();
                    labelemp.Text = dt.Rows[0]["Empleado"].ToString();
                }

                CalcularTotal();
            }
        }

        private void CalcularTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvdeta.Rows)
            {
                if (row.Cells[3].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells[3].Value);
                }
            }

            labeltotal.Text = "Total: " + total.ToString("0.00");
        }
        //El boton imprimir imprime en un documento de texto la factura segun el formato dado. salio un poco incomodo la posicion
        //si se quiere cambiar cree una carpeta y cambie el directorio actual
        private void butimp_Click(object sender, EventArgs e)
        {
            try
            {
                string ruta = @"C:\Users\hack-\source\repos\Interfaz_ChavasPollo_proyecto\Tickets";

                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }

                string archivo = ruta + $@"\Ticket_Orden_{idOrdenGlobal}.txt";

                using (StreamWriter sw = new StreamWriter(archivo))
                {
                    sw.WriteLine("CHAVAS POLLO");
                    sw.WriteLine("------------------------");
                    sw.WriteLine("Orden #: " + idOrdenGlobal);
                    sw.WriteLine("Fecha: " + labelfecha.Text);
                    sw.WriteLine("Empleado: " + labelemp.Text);
                    sw.WriteLine("");
                    sw.WriteLine("Producto\t/Cant     \t/Subtotal");
                    sw.WriteLine("------------------------");

                    decimal total = 0;

                    foreach (DataGridViewRow row in dgvdeta.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            string producto = row.Cells[0].Value.ToString();
                            string cantidad = row.Cells[1].Value.ToString();
                            string subtotal = row.Cells[3].Value.ToString();

                            sw.WriteLine($"{producto}\t{cantidad}\t{subtotal}");

                            total += Convert.ToDecimal(subtotal);
                        }
                    }

                    sw.WriteLine("------------------------");
                    sw.WriteLine("TOTAL: " + total.ToString("0.00"));
                    sw.WriteLine("------------------------");
                }

                MessageBox.Show("Ticket generado en su carpeta de seleccion",
                    "Accion compleatada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
