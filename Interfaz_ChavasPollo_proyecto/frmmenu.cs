using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Interfaz_ChavasPollo_proyecto
{
    public partial class frmmenu : Form
    {
        public frmmenu()
        {
            InitializeComponent();
        }
        SqlConnection cn =
    new SqlConnection(Conexion.cadena);

        private void frmmenu_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            MostrarMenu();
        }
        // De aqui en adelante se ocupa de manera similar los modos de cargar desde sql con select o
        //dependiendo de la consulta asi que solo agregare un mensaje cuando tenga algo nuevo o relevante
        //a explicar
        private void CargarCategorias()
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                string consulta =
                    "SELECT id_categoria, nombre_cat FROM categorias";

                SqlDataAdapter da = new SqlDataAdapter(consulta, cn);

                DataTable dt = new DataTable();

                da.Fill(dt);

                cmbcat.DataSource = dt;
                cmbcat.DisplayMember = "nombre_cat";
                cmbcat.ValueMember = "id_categoria";
            }
        }
        private void MostrarMenu()
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                string consulta = @"SELECT
                  m.id_menu,
                  m.nombre_platillo,
                  m.precio,
                  m.id_categoria,
                  c.nombre_cat
                    FROM menu m
                   INNER JOIN categorias c
                   ON m.id_categoria = c.id_categoria";

                SqlDataAdapter da = new SqlDataAdapter(consulta, cn);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dgvmenu.DataSource = dt;
                dgvmenu.AutoSizeColumnsMode =
                 DataGridViewAutoSizeColumnsMode.Fill;

                dgvmenu.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvmenu.ReadOnly = true;
                dgvmenu.Columns["nombre_platillo"].FillWeight = 200;

                dgvmenu.Columns["id_categoria"].Visible = false;
            }
        }

        private void butagr_Click(object sender, EventArgs e)
        {

            if (textmen.Text == "" ||
                    textnommen.Text == "" ||
                    textprecio.Text == "")
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }

            if (textnommen.Text.Any(char.IsDigit))
            {
                MessageBox.Show("El nombre del producto no puede contener números.");
                textnommen.Focus();
                return;
            }
            if (textmen.Text.Any(char.IsAsciiLetter))
            {
                MessageBox.Show("El Id no puede contener letras.");
                textmen.Focus();
                return;
            }
            if (textmen.Text.Any(char.IsSymbol))
            {
                MessageBox.Show("El Id no puede contener letras.");
                textmen.Focus();
                return;
            }
            if (textprecio.Text.Any(char.IsAsciiLetter))
            {
                MessageBox.Show("El precio no puede contener letras.");
                textprecio.Focus();
                return;
            }

            if (cmbcat.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de platillo.");
                return;
            }
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                string verificar = "SELECT COUNT(*) FROM menu WHERE id_menu = @id";

                SqlCommand cmdVerificar = new SqlCommand(verificar, cn);
                cmdVerificar.Parameters.AddWithValue("@id", int.Parse(textmen.Text));

                cn.Open();

                int existe = (int)cmdVerificar.ExecuteScalar();

                if (existe > 0)
                {
                    MessageBox.Show("El numero de ID que escribio ya está registrado.");
                    cn.Close();
                    textmen.Focus();
                    return;
                }
                string consulta = @"INSERT INTO menu
        (id_menu, nombre_platillo, precio, id_categoria)
        VALUES
        (@id, @nombre, @precio, @categoria)";

                SqlCommand cmd = new SqlCommand(consulta, cn);

                cmd.Parameters.AddWithValue("@id",
                    int.Parse(textmen.Text));

                cmd.Parameters.AddWithValue("@nombre",
                    textnommen.Text);

                cmd.Parameters.AddWithValue("@precio",
                    decimal.Parse(textprecio.Text));

                cmd.Parameters.AddWithValue("@categoria",
                    cmbcat.SelectedValue);


       
                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "Platillo agregado correctamente",
                    "Menú",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                MostrarMenu();
                
            }
        }
        private int idOriginalMenu;


        private void dgvmenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex >= 0 && e.RowIndex <= (dgvmenu.RowCount - 2))
            {
                DataGridViewRow fila = dgvmenu.Rows[e.RowIndex];

                idOriginalMenu = Convert.ToInt32(fila.Cells["id_menu"].Value);


                textmen.Text = fila.Cells["id_menu"].Value.ToString();
                textnommen.Text = fila.Cells["nombre_platillo"].Value.ToString();
                textprecio.Text = fila.Cells["precio"].Value.ToString();

                cmbcat.SelectedValue =
                Convert.ToInt32(fila.Cells["id_categoria"].Value);

            }
        }

        private void btnmodi_Click(object sender, EventArgs e)
        {

            using (SqlConnection cn =
                new SqlConnection(Conexion.cadena))
            {
                string consulta = @"
        UPDATE menu
        SET id_menu = @nuevoId,
            nombre_platillo = @nombre,
            precio = @precio,
            id_categoria = @categoria
        WHERE id_menu = @idOriginal";

                SqlCommand cmd =
                    new SqlCommand(consulta, cn);

                cmd.Parameters.AddWithValue(
                    "@nuevoId",
                    int.Parse(textmen.Text));

                cmd.Parameters.AddWithValue(
                    "@idOriginal",
                    idOriginalMenu);

                cmd.Parameters.AddWithValue(
                    "@nombre",
                    textnommen.Text);

                cmd.Parameters.AddWithValue(
                    "@precio",
                    decimal.Parse(textprecio.Text));

                cmd.Parameters.AddWithValue(
                    "@categoria",
                    cmbcat.SelectedValue);

                cn.Open();

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "Platillo modificado correctamente",
                    "Menú",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                MostrarMenu();
            }
        }

        private void buteli_Click(object sender, EventArgs e)
        {
            DialogResult respuesta =
    MessageBox.Show(
    "¿Desea eliminar este platillo?",
    "Confirmación",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                using (SqlConnection cn =
                    new SqlConnection(Conexion.cadena))
                {
                    string consulta =
                        "DELETE FROM menu WHERE id_menu=@id";

                    SqlCommand cmd =
                        new SqlCommand(consulta, cn);

                    cmd.Parameters.AddWithValue(
                        "@id",
                        int.Parse(textmen.Text));

                    cn.Open();

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Platillo eliminado",
                        "Menú",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    MostrarMenu();
                }
            }

        }

        private void textnommen_TextChanged(object sender, EventArgs e)
        {

        }

        private void butbusca_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                string consulta = @"
        SELECT
            m.id_menu,
            m.nombre_platillo,
            m.precio,
            m.id_categoria,
            c.nombre_cat
        FROM menu m
        INNER JOIN categorias c
            ON m.id_categoria = c.id_categoria
        WHERE m.nombre_platillo LIKE @buscar";

                SqlDataAdapter da = new SqlDataAdapter(consulta, cn);

                da.SelectCommand.Parameters.AddWithValue(
                    "@buscar",
                    "%" + textbusca.Text + "%");

                DataTable dt = new DataTable();

                da.Fill(dt);

                dgvmenu.DataSource = dt;

                dgvmenu.Columns["id_categoria"].Visible = false;
            }
        }

        private void textmen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textnommen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textprecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}


