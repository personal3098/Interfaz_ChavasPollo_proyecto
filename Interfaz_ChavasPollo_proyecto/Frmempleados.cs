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
    public partial class Frmempleados : Form
    {
        public Frmempleados()
        {
            InitializeComponent();
            MostrarEmpleados();
            Limpiar();
            CargarRoles();
            CargarTurnos();
        }
        SqlConnection cn =
    new SqlConnection(Conexion.cadena);
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void MostrarEmpleados()
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                string consulta = @"SELECT 
                            e.id_empleado,
                            e.nombre,
                            e.telefono,
                            r.nombre_rol,
                            t.nombre_turno
                            FROM empleados e
                            INNER JOIN roles r
                            ON e.id_rol = r.id_rol
                            INNER JOIN turnos t
                            ON e.id_turnos = t.id_turnos";

                SqlDataAdapter da = new SqlDataAdapter(consulta, cn);
                DataTable dt = new DataTable();

                da.Fill(dt);
                dgvemp.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

                dgvemp.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvemp.ReadOnly = true;

                dgvemp.DataSource = dt;
            }
        }
        //modo para limpiar las celdas cada ves que se vaya a usar
        private void Limpiar()
        {
            textidemp.Clear();
            textnombrem.Clear();
            texttel.Clear();

            cmbcargo.SelectedIndex = -1;
            cmbturno.SelectedIndex = -1;

            textidemp.Focus();
        }

        private void CargarRoles()
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                string consulta = "SELECT id_rol, nombre_rol FROM roles";

                SqlDataAdapter da = new SqlDataAdapter(consulta, cn);
                DataTable dt = new DataTable();

                da.Fill(dt);

                cmbcargo.DataSource = dt;
                cmbcargo.DisplayMember = "nombre_rol";
                cmbcargo.ValueMember = "id_rol";
            }
        }

        private void CargarTurnos()
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                string consulta = "SELECT id_turnos, nombre_turno FROM turnos";

                SqlDataAdapter da = new SqlDataAdapter(consulta, cn);
                DataTable dt = new DataTable();

                da.Fill(dt);

                cmbturno.DataSource = dt;
                cmbturno.DisplayMember = "nombre_turno";
                cmbturno.ValueMember = "id_turnos";
            }
        }

        private void butagr_Click(object sender, EventArgs e)
        {

            if (textidemp.Text == "" ||
                    textnombrem.Text == "" ||
                    texttel.Text == "")
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }

            if (textnombrem.Text.Any(char.IsDigit))
            {
                MessageBox.Show("El nombre no puede contener números.");
                textnombrem.Focus();
                return;
            }
            if (textidemp.Text.Any(char.IsAsciiLetter))
            {
                MessageBox.Show("El Id no puede contener letras.");
                textidemp.Focus();
                return;
            }
            if (texttel.Text.Any(char.IsAsciiLetter))
            {
                MessageBox.Show("El telefono no puede contener letras.");
                texttel.Focus();
                return;
            }

            if (cmbcargo.SelectedIndex == -1 || cmbturno.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un cargo y un turno.");
                return;
            }
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {

                string verificar = "SELECT COUNT(*) FROM empleados WHERE id_empleado = @id";

                SqlCommand cmdVerificar = new SqlCommand(verificar, cn);
                cmdVerificar.Parameters.AddWithValue("@id", int.Parse(textidemp.Text));

                cn.Open();

                int existe = (int)cmdVerificar.ExecuteScalar();

                if (existe > 0)
                {
                    MessageBox.Show("El numero de ID que escribio ya está registrado.");
                    cn.Close();
                    textidemp.Focus();
                    return;
                }

                cn.Close();
                string consulta = @"INSERT INTO empleados
                            (id_empleado, nombre, telefono, id_rol, id_turnos)
                            VALUES
                            (@id, @nombre, @telefono, @rol, @turno)";

                SqlCommand cmd = new SqlCommand(consulta, cn);

                cmd.Parameters.AddWithValue("@id", textidemp.Text);
                cmd.Parameters.AddWithValue("@nombre", textnombrem.Text);
                cmd.Parameters.AddWithValue("@telefono", texttel.Text);
                cmd.Parameters.AddWithValue("@rol", cmbcargo.SelectedValue);
                cmd.Parameters.AddWithValue("@turno", cmbturno.SelectedValue);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                MessageBox.Show("Empleado agregado correctamente",
                    "Accion ejecutada corectamente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                MostrarEmpleados();
                Limpiar();
            }
        }

        private void btnmod_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                string consulta = @"UPDATE empleados SET
                            nombre = @nombre,
                            telefono = @telefono,
                            id_rol = @rol,
                            id_turnos = @turno
                            WHERE id_empleado = @id";

                SqlCommand cmd = new SqlCommand(consulta, cn);

                cmd.Parameters.AddWithValue("@id", textidemp.Text);
                cmd.Parameters.AddWithValue("@nombre", textnombrem.Text);
                cmd.Parameters.AddWithValue("@telefono", texttel.Text);
                cmd.Parameters.AddWithValue("@rol", cmbcargo.SelectedValue);
                cmd.Parameters.AddWithValue("@turno", cmbturno.SelectedValue);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                MessageBox.Show("Empleado modificado correctamente",
                    "Accion ejecutada correctamente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                MostrarEmpleados();
                Limpiar();
            }
        }

        private void dgvemp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textidemp.Text = dgvemp.CurrentRow.Cells["id_empleado"].Value.ToString();
            textnombrem.Text = dgvemp.CurrentRow.Cells["nombre"].Value.ToString();
            texttel.Text = dgvemp.CurrentRow.Cells["telefono"].Value.ToString();

            cmbcargo.Text = dgvemp.CurrentRow.Cells["nombre_rol"].Value.ToString();
            cmbturno.Text = dgvemp.CurrentRow.Cells["nombre_turno"].Value.ToString();
        }

        private void buteli_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "Desea eliminar el empleado del sistema?",
                "Confirme la eliminacion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
                using (SqlConnection cn = new SqlConnection(Conexion.cadena))
                {
                    string consulta = "DELETE FROM empleados WHERE id_empleado = @id";

                    SqlCommand cmd = new SqlCommand(consulta, cn);
                    cmd.Parameters.AddWithValue("@id", textidemp.Text);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();



                    MessageBox.Show("Empleado eliminado correctamente",
                        "Se elimino correctamente",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);


                    MostrarEmpleados();
                    Limpiar();
                }
        }

        private void butb_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                string consulta = @"SELECT 
                            e.id_empleado,
                            e.nombre,
                            e.telefono,
                            r.nombre_rol,
                            t.nombre_turno
                            FROM empleados e
                            INNER JOIN roles r ON e.id_rol = r.id_rol
                            INNER JOIN turnos t ON e.id_turnos = t.id_turnos
                            WHERE e.nombre LIKE @buscar";

                SqlDataAdapter da = new SqlDataAdapter(consulta, cn);

                da.SelectCommand.Parameters.AddWithValue("@buscar", "%" + textbusca.Text + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvemp.DataSource = dt;
            }
        }

        private void Frmempleados_Load(object sender, EventArgs e)
        {

        }

        private void textidemp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textnombrem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void texttel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvemp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}



