using System;
using System.Linq;
using System.Windows.Forms;

namespace Interfaz_ChavasPollo_proyecto
{
    public partial class Frmhistorial : Form
    {
        public Frmhistorial()
        {
            InitializeComponent();
        }

        // Cargar las órdenes al abrir el formulario
        private void Frmhistorial_Load(object sender, EventArgs e)
        {
            CargarOrdenes();
        }

        // Mostrar todas las órdenes registradas
        private void CargarOrdenes()
        {
            using (var db = Conexion.CrearContexto())
            {
                var datos = (
                    from o in db.ordenes
                    join emp in db.empleados
                    on o.id_empleado equals emp.id_empleado
                    join f in db.facturacions
                    on o.id_orden equals f.id_orden
                    orderby o.id_orden descending
                    select new
                    {
                        o.id_orden,
                        o.fecha,
                        empleado = emp.nombre,
                        f.total
                    }
                ).ToList();

                dgvhisto.DataSource = datos;

                dgvhisto.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvhisto.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvhisto.ReadOnly = true;
                dgvhisto.AllowUserToAddRows = false;
            }
        }

        // Botón para actualizar el historial
        private void butcargar_Click(object sender, EventArgs e)
        {
            CargarOrdenes();
        }

        // Buscar órdenes por rango de fechas
        private void butbusc_Click(object sender, EventArgs e)
        {
            DateTime desde = dtpdesde.Value.Date;

            // Se utiliza el día siguiente como límite exclusivo
            DateTime hasta = dtphasta.Value.Date.AddDays(1);

            if (desde > dtphasta.Value.Date)
            {
                MessageBox.Show(
                    "La fecha inicial no puede ser posterior a la fecha final.");

                return;
            }

            using (var db = Conexion.CrearContexto())
            {
                var datos = (
                    from o in db.ordenes
                    join emp in db.empleados
                    on o.id_empleado equals emp.id_empleado
                    join f in db.facturacions
                    on o.id_orden equals f.id_orden
                    where o.fecha >= desde && o.fecha < hasta
                    orderby o.id_orden descending
                    select new
                    {
                        o.id_orden,
                        o.fecha,
                        empleado = emp.nombre,
                        f.total
                    }
                ).ToList();

                dgvhisto.DataSource = datos;

                dgvhisto.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvhisto.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvhisto.ReadOnly = true;
                dgvhisto.AllowUserToAddRows = false;
            }
        }

        // Abrir los detalles al hacer doble clic en una orden
        private void dgvhisto_CellDoubleClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int idOrden = Convert.ToInt32(
                dgvhisto.Rows[e.RowIndex]
                .Cells["id_orden"].Value);

            Frmdetallesordenes frm =
                new Frmdetallesordenes(idOrden);

            frm.Show();
        }

        // Eliminar todo el historial
        private void buteli_Click(object sender, EventArgs e)
        {
            // Primera confirmación
            DialogResult r1 = MessageBox.Show(
                " ADVERTENCIA:\n\n" +
                "Vas a eliminar TODO el historial de órdenes.\n" +
                "Esta acción es IRREPARABLE.",
                "PRIMERA CONFIRMACIÓN",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (r1 != DialogResult.Yes)
                return;

            // Segunda confirmación
            DialogResult r2 = MessageBox.Show(
                "ÚLTIMA ADVERTENCIA:\n\n" +
                "Esta acción NO se puede deshacer.\n" +
                "Se perderán TODAS las ventas permanentemente.\n\n" +
                "¿Seguro que desea continuar?",
                "CONFIRMACIÓN FINAL",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error);

            if (r2 != DialogResult.Yes)
                return;

            try
            {
                using (var db = Conexion.CrearContexto())
                {
                    // Iniciar una transacción
                    using (var transaccion =
                        db.Database.BeginTransaction())
                    {
                        // Obtener todos los registros
                        var detalles = db.detalleordenes.ToList();
                        var facturas = db.facturacions.ToList();
                        var ordenes = db.ordenes.ToList();

                        // Eliminar primero los detalles
                        db.detalleordenes.RemoveRange(detalles);

                        // Después las facturas
                        db.facturacions.RemoveRange(facturas);

                        // Finalmente las órdenes
                        db.ordenes.RemoveRange(ordenes);

                        // Guardar los cambios
                        db.SaveChanges();

                        // Confirmar la transacción
                        transaccion.Commit();
                    }
                }

                // Limpiar la tabla del formulario
                dgvhisto.DataSource = null;

                MessageBox.Show(
                    "Se ha eliminado todo el historial correctamente.",
                    "Eliminación completada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al eliminar el historial: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}


