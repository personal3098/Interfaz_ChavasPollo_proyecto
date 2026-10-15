using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Interfaz_ChavasPollo_proyecto
{
    public partial class Frminventario : Form
    {
        //De esta manera cargamos las acciones al inicia en este caso cargar improv se va a ejecutar al abrir el form
        public Frminventario()
        {
            InitializeComponent();
            Cargarprov();
        }
        // Aqui estamos llamando la clase conexion para no tener que escribir tanto en cada form cada ves que querramos cargar los datos de sql
        //Para mas info vea la clase conexion
        SqlConnection cn =
    new SqlConnection(Conexion.cadena);
        private void Frminventario_Load(object sender, EventArgs e)
        {
            CargarUnidades();

        }

        //Aqui se llaman y cargan los datos de la tabla ya creada en sql tambien esta esta ubicada en
        //el load por que se va a usar con instrucciones y no al iniciar el form, escribimos el codigo de igual forma el cual hariamos
        //en sql en este caso dice seleccionar id unidad nombrre unidad de la tabla unidad de medida 
        //lo adapta y lo muestra en una datatable
        //y por los combobox le añadimos de donde proviene el source en este caso la datatable creada y solo le pedimos
        //que los muestre con el codigo de comando display member y que tome como referencia el valuemember para 
        //ubicarlo en una posicion
        private void CargarUnidades()
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                string consulta = "SELECT id_unidad, nombrre_unidad FROM unidad_medida";

                SqlDataAdapter da = new SqlDataAdapter(consulta, cn);

                DataTable dt = new DataTable();

                da.Fill(dt);

                cmbuni.DataSource = dt;
                cmbuni.DisplayMember = "nombrre_unidad";
                cmbuni.ValueMember = "id_unidad";
            }
        }
        // El metodo cargar para llamar mas datos de la tabla con la diferencia de que este se hara al iniciar el form 
        //por eso esta ubicado cerca de inicializar componente misma idea para el combobox proveedor
        private void Cargarprov()
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {

                string consulta = "SELECT id_proveedor, nombre_prov FROM proveedores";

                SqlDataAdapter da = new SqlDataAdapter(consulta, cn);

                DataTable dt = new DataTable();

                da.Fill(dt);

                cmbprov.DataSource = dt;
                cmbprov.DisplayMember = "nombre_prov";
                cmbprov.ValueMember = "id_proveedor";
            }
        }
        // De esta manera llamamos y cargamos el inventario a este form esto lo vamos a ocupar mas tarde,
        //la manera de identificar es casi la misma Select las celdas de la tabla inventario con la diferencia
        //que aqui se hara un inner join para que pueda mostrar datos de otra tabla en este caso unidad de medida
        //y proveedores ya que los vamos a usar todo en un datatable
        private void MostrarInventario()
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                string consulta = @"SELECT
                                   i.id_inv,
                               i.nombre_prod,
                                  i.cantidad,
                                   i.id_unidad,
                                 i.id_proveedor,
                                u.nombrre_unidad,
                                    p.nombre_prov
                                 FROM inventario i
                           INNER JOIN unidad_medida u
                          ON i.id_unidad = u.id_unidad
                                INNER JOIN proveedores p
                         ON i.id_proveedor = p.id_proveedor ";

                SqlDataAdapter da = new SqlDataAdapter(consulta, cn);

                DataTable dt = new DataTable();

                da.Fill(dt);
                //Esto es solo para darle un formato para que se vea mas limpio el codigo lo copie y pegue en varias forms
                dgvinv.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

                dgvinv.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvinv.ReadOnly = true;

                dgvinv.DataSource = dt;
                dgvinv.Columns["id_unidad"].Visible = false;
                dgvinv.Columns["id_proveedor"].Visible = false;
            }
        }
        //aqui usamos mostrar inventario en el boton actualizar/mostrar solo para llamarlo
        private void btnact_Click(object sender, EventArgs e)
        {
            MostrarInventario();
        }



        //Este es el metodo para el boton agregar llamamos la conexion como siempre 
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {

                //Excepciones si no se escribio nada o falto un campo
                if (textid.Text == "" ||
                     textnombrep.Text == "" ||
                     textcant.Text == "")
                {
                    MessageBox.Show("Complete todos los campos");
                    return;
                }

                if (textnombrep.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("El nombre del producto no puede contener números.");
                    textnombrep.Focus();
                    return;
                }
                if (textid.Text.Any(char.IsAsciiLetter))
                {
                    MessageBox.Show("El Id no puede contener letras.");
                    textnombrep.Focus();
                    return;
                }
                if (textcant.Text.Any(char.IsAsciiLetter))
                {
                    MessageBox.Show("la cantidad no puede contener letras.");
                    textnombrep.Focus();
                    return;
                }

                if (cmbuni.SelectedIndex == 0 || cmbprov.SelectedIndex == 0)
                {
                    MessageBox.Show("Debe seleccionar una unidad y un proveedor.");
                    return;
                }
                //consulta para hacerlo con sql 
                string consulta = @"INSERT INTO inventario
                           (id_inv, nombre_prod, cantidad, id_unidad, id_proveedor)
                           VALUES
                           (@id, @nombre, @cantidad, @unidad, @proveedor)";

                string verificar = "SELECT COUNT(*) FROM inventario WHERE id_inv = @id";

                SqlCommand cmdVerificar = new SqlCommand(verificar, cn);
                cmdVerificar.Parameters.AddWithValue("@id", int.Parse(textid.Text));

                cn.Open();

                int existe = (int)cmdVerificar.ExecuteScalar();

                if (existe > 0)
                {
                    MessageBox.Show("El numero de ID ingresado ya está registrado.");
                    cn.Close();
                    textid.Focus();
                    return;
                }

                cn.Close();

                SqlCommand cmd = new SqlCommand(consulta, cn);
                //para que añada los valores ingresados segun los campos 

                cmd.Parameters.AddWithValue("@id", int.Parse(textid.Text));
                cmd.Parameters.AddWithValue("@nombre", textnombrep.Text);
                cmd.Parameters.AddWithValue("@cantidad", int.Parse(textcant.Text));
                cmd.Parameters.AddWithValue("@unidad", cmbuni.SelectedValue);
                cmd.Parameters.AddWithValue("@proveedor", cmbprov.SelectedValue);

                cn.Open();
                cmd.ExecuteNonQuery();
                // si el resultado fue un exito
                MessageBox.Show(
                         "Producto agregado exitosamente",
                          "Accion completada",
                             MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                textid.Clear();
                textnombrep.Clear();
                textcant.Clear();

                cmbuni.SelectedIndex = 0;
                cmbprov.SelectedIndex = 0;
                //Muestra el inventario para ahorrarse tocar el boton actualizar
                MostrarInventario();
            }
        }

        private void dgvinv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvinv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        //con este metodo si tocamos la datagridview en una de las celdas nos va a ademas de seleccionar
        //a autorellenar los datos en caso de querer modificarlos
        private void dgvinv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.RowIndex <= (dgvinv.RowCount - 2))
            {
                DataGridViewRow fila = dgvinv.Rows[e.RowIndex];

                idOriginal = Convert.ToInt32(fila.Cells["id_inv"].Value);


                textid.Text = fila.Cells["id_inv"].Value.ToString();
                textnombrep.Text = fila.Cells["nombre_prod"].Value.ToString();
                textcant.Text = fila.Cells["cantidad"].Value.ToString();

                cmbuni.SelectedValue =
                Convert.ToInt32(fila.Cells["id_unidad"].Value);

                cmbprov.SelectedValue =
                    Convert.ToInt32(fila.Cells["id_proveedor"].Value);

            }
        }



        //El metodo para modificar siempre con consulta para seleccionar las celdas de dicha tabla pero 
        //en este caso es update para actualizar los datos ingresados tambien se creo id original
        //cuyo proposito es guardar los valores anteriores para que la accion pueda ser reemplazada con 
        //nuevo id
        private void btnmodi_Click_1(object sender, EventArgs e)
        {

            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                string consulta = @"UPDATE inventario
                             SET id_inv = @nuevoId,
                             nombre_prod = @nombre,
                              cantidad = @cantidad,
                                id_unidad = @unidad,
                              id_proveedor = @proveedor
                              WHERE id_inv = @idOriginal";

                SqlCommand cmd = new SqlCommand(consulta, cn);

                cmd.Parameters.AddWithValue("@nuevoId",
                    int.Parse(textid.Text));

                cmd.Parameters.AddWithValue("@idOriginal",
                    idOriginal);

                cmd.Parameters.AddWithValue("@nombre",
                    textnombrep.Text);

                cmd.Parameters.AddWithValue("@cantidad",
                    int.Parse(textcant.Text));

                cmd.Parameters.AddWithValue("@unidad",
                    cmbuni.SelectedValue);

                cmd.Parameters.AddWithValue("@proveedor",
                    cmbprov.SelectedValue);

                cn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Producto modificado correctamente",
                    "Accion Realizada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                MostrarInventario();
            }
        }
        //aqui se creo idoriginal para ser llamado y que guarde valores
        private int idOriginal;

        //Modo para eliminar ya que es una accion para borrar valores se le agrego una advertencia
        //de si o no
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
        "¿Desea eliminar este producto?",
        "Confirmar eliminación",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                using (SqlConnection cn = new SqlConnection(Conexion.cadena))
                {
                    string consulta =
                        "DELETE FROM inventario WHERE id_inv = @id";

                    SqlCommand cmd = new SqlCommand(consulta, cn);

                    cmd.Parameters.AddWithValue("@id",
                        int.Parse(textid.Text));

                    cn.Open();

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Producto eliminado",
                        "Borrado Completado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);

                    MostrarInventario();

                    textid.Clear();
                    textnombrep.Clear();
                    textcant.Clear();
                }
            }
        }
        // metodo para buscar los valores esta configurado de tal manera que muestre todo lo relacionado con
        //lo ingresado inclusive si es una letra, Tiene su propio textbox que solo se utiliza para buscar
        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                string consulta = @"SELECT
             i.id_inv,
             i.nombre_prod,
             i.cantidad,
             i.id_unidad,
             i.id_proveedor,
             u.nombrre_unidad,
             p.nombre_prov
          FROM inventario i
          INNER JOIN unidad_medida u
             ON i.id_unidad = u.id_unidad
          INNER JOIN proveedores p
             ON i.id_proveedor = p.id_proveedor
            WHERE i.nombre_prod LIKE @buscar";

                SqlDataAdapter da = new SqlDataAdapter(consulta, cn);

                da.SelectCommand.Parameters.AddWithValue(
                    "@buscar",
                    "%" + textbusc.Text + "%");

                DataTable dt = new DataTable();

                da.Fill(dt);

                dgvinv.DataSource = dt;
            }
        }

        private void textid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textnombrep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textcant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

