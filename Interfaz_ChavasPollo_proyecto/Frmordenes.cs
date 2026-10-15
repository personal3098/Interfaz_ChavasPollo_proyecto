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
    public partial class Frmordenes : Form
    {
        public Frmordenes()
        {
            InitializeComponent();
            CargarEmpleados();
            CargarMenu();
        }

        SqlConnection cn =
    new SqlConnection(Conexion.cadena);

        //En este caso tuve que añadir la datagrid manualmente esta se muestra con instrucciones
        private void Frmordenes_Load(object sender, EventArgs e)
        {
            dgvord.Columns.Add("IdMenu", "IdMenu");
            dgvord.Columns.Add("Nombre", "Nombre");
            dgvord.Columns.Add("Precio", "Precio");
            dgvord.Columns.Add("Cantidad", "Cantidad");
            dgvord.Columns.Add("Subtotal", "Subtotal");
            dgvord.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvord.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvord.ReadOnly = true;
        }

        private void CargarEmpleados()
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                string sql = "SELECT id_empleado, nombre FROM empleados";

                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbemp.DataSource = dt;
                cmbemp.DisplayMember = "nombre";
                cmbemp.ValueMember = "id_empleado";
            }
        }

        private void CargarMenu()
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                string sql = "SELECT id_menu, nombre_platillo, precio FROM menu";

                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbmenu.DataSource = dt;
                cmbmenu.DisplayMember = "nombre_platillo";
                cmbmenu.ValueMember = "id_menu";
            }
        }
        //Con este metodo selected index podemos seleccionar en modo lista los platillo en este caso y las bebidas 
        private void cmbMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbmenu.SelectedItem != null)
            {
                DataRowView row = (DataRowView)cmbmenu.SelectedItem;

                decimal precio = Convert.ToDecimal(row["precio"]);


            }

        }

        private void butagr_Click(object sender, EventArgs e)
        {
            // se valida la selección en caso de que se le olvide seleccionar
            if (cmbmenu.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un platillo");
                return;
            }
            if (cmbemp.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un empleado");
                return;
            }


            // obtener datos directamente del ComboBox
            DataRowView row = (DataRowView)cmbmenu.SelectedItem;

            decimal precio = Convert.ToDecimal(row["precio"]);
            int cantidad = (int)nudcant.Value;
            
            //Validacion para cantidad

            if (cantidad <= 0)
            {
                MessageBox.Show("Cantidad inválida");
                return;
            }
            //como se va a mostrar 
            decimal subtotal = precio * cantidad;

            dgvord.Rows.Add(
                cmbmenu.SelectedValue,  // id_menu
                cmbmenu.Text,           // nombre
                precio,                 // precio seguro
                cantidad,
                subtotal
            );

            CalcularTotal();
        }

        //modo para sacar total y mostrarlo en el label "="
        private void CalcularTotal()
        {

            decimal total = 0;

            foreach (DataGridViewRow row in dgvord.Rows)
            {
                if (row.Cells[4].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells[4].Value);
                }
            }

            labeltotal.Text = total.ToString("0.00");

        }


        private void btguard_Click(object sender, EventArgs e)
        {
            try
            {    
                // validaciones en caso de errores
            
                if (cmbemp.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecciona un empleado");
                    return;
                }

                if (dgvord.Rows.Count == 0)
                {
                    MessageBox.Show("Agrega productos a la orden");
                    return;
                }

                if (string.IsNullOrWhiteSpace(labeltotal.Text))
                {
                    MessageBox.Show("El total no es válido");
                    return;
                }

                using (SqlConnection cn = new SqlConnection(Conexion.cadena))
                {
                    cn.Open();
                    SqlTransaction tr = cn.BeginTransaction();

                    
                    // insertar las ordenes en este caso utilice identity para que sea mas comodo y no tener 
                    //que escribir el numero de orden id manualmente todo el tiempo cada ves que se tenga una
                    //nueva compra
                   
                    string sqlOrden = @"
                     INSERT INTO ordenes(id_empleado)
                         VALUES(@emp);
                        SELECT SCOPE_IDENTITY();";

                    SqlCommand cmdOrden = new SqlCommand(sqlOrden, cn, tr);
                    cmdOrden.Parameters.AddWithValue("@emp", cmbemp.SelectedValue);

                    int idOrden = Convert.ToInt32(cmdOrden.ExecuteScalar());

                    
                    // detalles de la factura se genera con guid para tener un identificador unico
                   
                    foreach (DataGridViewRow row in dgvord.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            string sqlDet = @"INSERT INTO detalleordenes
                    (id_detalle, id_orden, id_menu, cantidad)
                    VALUES (@det, @orden, @menu, @cant)";

                            SqlCommand cmdDet = new SqlCommand(sqlDet, cn, tr);

                            cmdDet.Parameters.AddWithValue("@det", Guid.NewGuid().GetHashCode());
                            cmdDet.Parameters.AddWithValue("@orden", idOrden);
                            cmdDet.Parameters.AddWithValue("@menu", row.Cells[0].Value);
                            cmdDet.Parameters.AddWithValue("@cant", row.Cells[3].Value);

                            cmdDet.ExecuteNonQuery();
                        }
                    }

                 
                    // FACTURA
                  
                    decimal total;
                    //Validacion

                    if (!decimal.TryParse(labeltotal.Text, out total))
                    {
                        MessageBox.Show("Total inválido");
                        return;
                    }
                    //metodo para que guarde las facturas 
                    string sqlFac = @"INSERT INTO facturacion(id_factura, id_orden, total)
                              VALUES(@fac, @orden, @total)";

                    SqlCommand cmdFac = new SqlCommand(sqlFac, cn, tr);

                    cmdFac.Parameters.AddWithValue("@fac", Guid.NewGuid().GetHashCode());
                    cmdFac.Parameters.AddWithValue("@orden", idOrden);
                    cmdFac.Parameters.AddWithValue("@total", total);

                    cmdFac.ExecuteNonQuery();

                    tr.Commit();

                    MessageBox.Show("Orden guardada correctamente");

                    dgvord.Rows.Clear();
                    labeltotal.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // hay un boton para ir facturacion directamente o se puede hacer en el menu no hay problema 
        //en este caso aqui lo va a enviar a la siguiente form
        private void button1_Click(object sender, EventArgs e)
        {
            Frmhistorial fr5 = new Frmhistorial();
            fr5.Show();
        }

        private void cmbmenu_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}

