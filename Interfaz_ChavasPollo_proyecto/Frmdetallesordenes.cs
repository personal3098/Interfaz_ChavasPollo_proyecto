using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Interfaz_ChavasPollo_proyecto
{
    public partial class Frmdetallesordenes : Form
    {
        private int idOrdenGlobal;

        public Frmdetallesordenes(int idOrden)
        {
            InitializeComponent();

            idOrdenGlobal = idOrden;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        // Cargar los detalles de la orden
        private void Frmdetallesordenes_Load(object sender, EventArgs e)
        {
            labelidorden.Text = "Orden #" + idOrdenGlobal;

            using (var db = Conexion.CrearContexto())
            {
                var datos = (
                    from d in db.detalleordenes
                    join m in db.menus
                    on d.id_menu equals m.id_menu
                    join o in db.ordenes
                    on d.id_orden equals o.id_orden
                    join emp in db.empleados
                    on o.id_empleado equals emp.id_empleado
                    where d.id_orden == idOrdenGlobal
                    select new
                    {
                        Producto = m.nombre_platillo,
                        d.cantidad,
                        m.precio,
                        Subtotal = d.cantidad * m.precio,
                        o.fecha,
                        Empleado = emp.nombre
                    }
                ).ToList();

                dgvdeta.DataSource = datos;

                dgvdeta.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvdeta.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvdeta.ReadOnly = true;
                dgvdeta.AllowUserToAddRows = false;

                if (datos.Count > 0)
                {
                    labelfecha.Text = datos[0].fecha.ToString();
                    labelemp.Text = datos[0].Empleado;
                }

                CalcularTotal();
            }
        }

        // Calcular el total de la orden
        private void CalcularTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvdeta.Rows)
            {
                if (row.Cells["Subtotal"].Value != null)
                {
                    total += Convert.ToDecimal(
                        row.Cells["Subtotal"].Value);
                }
            }

            labeltotal.Text = "Total: " + total.ToString("0.00");
        }

        // Generar el ticket en un archivo de texto
        private void butimp_Click(object sender, EventArgs e)
        {
            try
            {
                string ruta = Path.Combine(
                    Application.StartupPath,
                    "Tickets");

                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }

                string archivo = Path.Combine(
                    ruta,
                    $"Ticket_Orden_{idOrdenGlobal}.txt");

                using (StreamWriter sw = new StreamWriter(archivo))
                {
                    sw.WriteLine("CHAVAS POLLO");
                    sw.WriteLine("------------------------");

                    sw.WriteLine("Orden #: " + idOrdenGlobal);
                    sw.WriteLine("Fecha: " + labelfecha.Text);
                    sw.WriteLine("Empleado: " + labelemp.Text);

                    sw.WriteLine("");
                    sw.WriteLine("Producto\tCant\tSubtotal");
                    sw.WriteLine("------------------------");

                    decimal total = 0;

                    foreach (DataGridViewRow row in dgvdeta.Rows)
                    {
                        if (row.Cells["Producto"].Value != null)
                        {
                            string producto =
                                row.Cells["Producto"].Value.ToString();

                            string cantidad =
                                row.Cells["cantidad"].Value.ToString();

                            string subtotal =
                                row.Cells["Subtotal"].Value.ToString();

                            sw.WriteLine(
                                $"{producto}\t{cantidad}\t{subtotal}");

                            total += Convert.ToDecimal(subtotal);
                        }
                    }

                    sw.WriteLine("------------------------");
                    sw.WriteLine("TOTAL: " + total.ToString("0.00"));
                    sw.WriteLine("------------------------");
                }

                MessageBox.Show(
                    "Ticket generado correctamente en la carpeta Tickets.",
                    "Acción completada",
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
