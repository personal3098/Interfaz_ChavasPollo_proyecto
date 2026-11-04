
using System;
using System.Linq;
using System.Windows.Forms;
using Interfaz_ChavasPollo_proyecto.Models;

namespace Interfaz_ChavasPollo_proyecto
{
    public partial class Frmempleados : Form
    {
        private int idOriginalEmpleado;

        public Frmempleados()
        {
            InitializeComponent();
        }

        // Cargar los datos al abrir el formulario
        private void Frmempleados_Load(object sender, EventArgs e)
        {
            CargarRoles();
            CargarTurnos();
            MostrarEmpleados();
            Limpiar();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Mostrar los empleados registrados
        private void MostrarEmpleados()
        {
            using (var db = Conexion.CrearContexto())
            {
                var datos = (
                    from e in db.empleados
                    join r in db.roles
                    on e.id_rol equals r.id_rol
                    join t in db.turnos
                    on e.id_turnos equals t.id_turnos
                    select new
                    {
                        e.id_empleado,
                        e.nombre,
                        e.telefono,
                        r.nombre_rol,
                        t.nombre_turno
                    }
                ).ToList();

                dgvemp.DataSource = datos;

                dgvemp.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvemp.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvemp.ReadOnly = true;
                dgvemp.AllowUserToAddRows = false;
            }
        }

        // Limpiar los campos del formulario
        private void Limpiar()
        {
            textidemp.Clear();
            textnombrem.Clear();
            texttel.Clear();

            cmbcargo.SelectedIndex = -1;
            cmbturno.SelectedIndex = -1;

            idOriginalEmpleado = 0;

            textidemp.ReadOnly = false;

            textidemp.Focus();
        }

        // Cargar los roles
        private void CargarRoles()
        {
            using (var db = Conexion.CrearContexto())
            {
                var roles = db.roles
                    .Select(r => new
                    {
                        r.id_rol,
                        r.nombre_rol
                    })
                    .ToList();

                cmbcargo.DataSource = roles;
                cmbcargo.DisplayMember = "nombre_rol";
                cmbcargo.ValueMember = "id_rol";
                cmbcargo.SelectedIndex = -1;
            }
        }

        // Cargar los turnos
        private void CargarTurnos()
        {
            using (var db = Conexion.CrearContexto())
            {
                var turnos = db.turnos
                    .Select(t => new
                    {
                        t.id_turnos,
                        t.nombre_turno
                    })
                    .ToList();

                cmbturno.DataSource = turnos;
                cmbturno.DisplayMember = "nombre_turno";
                cmbturno.ValueMember = "id_turnos";
                cmbturno.SelectedIndex = -1;
            }
        }

        // Agregar un empleado
        private void butagr_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textidemp.Text) ||
                string.IsNullOrWhiteSpace(textnombrem.Text) ||
                string.IsNullOrWhiteSpace(texttel.Text))
            {
                MessageBox.Show("Complete todos los campos.");
                return;
            }

            if (textnombrem.Text.Any(char.IsDigit))
            {
                MessageBox.Show(
                    "El nombre no puede contener números.");

                textnombrem.Focus();
                return;
            }

            if (!int.TryParse(textidemp.Text, out int id))
            {
                MessageBox.Show("Ingrese un ID válido.");
                textidemp.Focus();
                return;
            }

            if (!texttel.Text.All(char.IsDigit))
            {
                MessageBox.Show("El teléfono solo debe contener números.");
                texttel.Focus();
                return;
            }

            if (cmbcargo.SelectedValue == null ||
                cmbturno.SelectedValue == null)
            {
                MessageBox.Show(
                    "Debe seleccionar un cargo y un turno.");

                return;
            }

            using (var db = Conexion.CrearContexto())
            {
                // Verificar si el ID ya existe
                bool existe = db.empleados
                    .Any(e => e.id_empleado == id);

                if (existe)
                {
                    MessageBox.Show(
                        "El número de ID que escribió ya está registrado.");

                    textidemp.Focus();
                    return;
                }

                // Crear el objeto empleado
                var nuevoEmpleado = new empleado
                {
                    id_empleado = id,
                    nombre = textnombrem.Text.Trim(),
                    telefono = texttel.Text,
                    id_rol = Convert.ToInt32(cmbcargo.SelectedValue),
                    id_turnos = Convert.ToInt32(cmbturno.SelectedValue)
                };

                db.empleados.Add(nuevoEmpleado);

                db.SaveChanges();

                MessageBox.Show(
                    "Empleado agregado correctamente.",
                    "Acción ejecutada correctamente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            MostrarEmpleados();
            Limpiar();
        }

        // Modificar un empleado
        private void btnmod_Click(object sender, EventArgs e)
        {
            if (idOriginalEmpleado <= 0)
            {
                MessageBox.Show("Seleccione un empleado de la tabla.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textnombrem.Text) ||
                string.IsNullOrWhiteSpace(texttel.Text))
            {
                MessageBox.Show("Complete todos los campos.");
                return;
            }

            if (textnombrem.Text.Any(char.IsDigit))
            {
                MessageBox.Show("El nombre no puede contener números.");
                textnombrem.Focus();
                return;
            }

            if (!texttel.Text.All(char.IsDigit))
            {
                MessageBox.Show("El teléfono solo debe contener números.");
                texttel.Focus();
                return;
            }

            if (cmbcargo.SelectedValue == null ||
                cmbturno.SelectedValue == null)
            {
                MessageBox.Show(
                    "Debe seleccionar un cargo y un turno.");

                return;
            }

            using (var db = Conexion.CrearContexto())
            {
                var empleadoActual =
                    db.empleados.Find(idOriginalEmpleado);

                if (empleadoActual == null)
                {
                    MessageBox.Show("No se encontró el empleado.");
                    return;
                }

                empleadoActual.nombre = textnombrem.Text.Trim();
                empleadoActual.telefono = texttel.Text;

                empleadoActual.id_rol =
                    Convert.ToInt32(cmbcargo.SelectedValue);

                empleadoActual.id_turnos =
                    Convert.ToInt32(cmbturno.SelectedValue);

                db.SaveChanges();

                MessageBox.Show(
                    "Empleado modificado correctamente.",
                    "Acción ejecutada correctamente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            MostrarEmpleados();
            Limpiar();
        }

        // Seleccionar un empleado de la tabla
        private void dgvemp_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvemp.Rows[e.RowIndex];

            idOriginalEmpleado =
                Convert.ToInt32(fila.Cells["id_empleado"].Value);

            textidemp.Text =
                fila.Cells["id_empleado"].Value.ToString();

            textnombrem.Text =
                fila.Cells["nombre"].Value.ToString();

            texttel.Text =
                fila.Cells["telefono"].Value.ToString();

            cmbcargo.Text =
                fila.Cells["nombre_rol"].Value.ToString();

            cmbturno.Text =
                fila.Cells["nombre_turno"].Value.ToString();

            // Evitar modificar la clave primaria
            textidemp.ReadOnly = true;
        }

        // Eliminar un empleado
        private void buteli_Click(object sender, EventArgs e)
        {
            if (idOriginalEmpleado <= 0)
            {
                MessageBox.Show("Seleccione un empleado de la tabla.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar el empleado del sistema?",
                "Confirme la eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                using (var db = Conexion.CrearContexto())
                {
                    var empleadoActual =
                        db.empleados.Find(idOriginalEmpleado);

                    if (empleadoActual == null)
                    {
                        MessageBox.Show("No se encontró el empleado.");
                        return;
                    }

                    db.empleados.Remove(empleadoActual);

                    db.SaveChanges();

                    MessageBox.Show(
                        "Empleado eliminado correctamente.",
                        "Se eliminó correctamente",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                MostrarEmpleados();
                Limpiar();
            }
        }

        // Buscar empleados por nombre

        private void butb_Click(object sender, EventArgs e)
        {
            using (var db = Conexion.CrearContexto())
            {
                string busqueda = textbusca.Text.Trim();

                var consulta =
                    from emp in db.empleados
                    join r in db.roles
                    on emp.id_rol equals r.id_rol
                    join t in db.turnos
                    on emp.id_turnos equals t.id_turnos
                    select new
                    {
                        emp.id_empleado,
                        emp.nombre,
                        emp.telefono,
                        r.nombre_rol,
                        t.nombre_turno
                    };

                if (!string.IsNullOrWhiteSpace(busqueda))
                {
                    consulta = consulta.Where(empleado =>
                        empleado.nombre.Contains(busqueda));
                }

                dgvemp.DataSource = consulta.ToList();

                dgvemp.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvemp.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvemp.ReadOnly = true;
                dgvemp.AllowUserToAddRows = false;
            }
        }


        // Validar el ID
        private void textidemp_KeyPress(
            object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Validar el nombre
        private void textnombrem_KeyPress(
            object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsLetter(e.KeyChar) &&
                !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Validar el teléfono
        private void texttel_KeyPress(
            object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvemp_CellContentClick(
            object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

