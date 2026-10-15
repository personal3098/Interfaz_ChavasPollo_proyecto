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
    public partial class Frmhistorial : Form
    {
        public Frmhistorial()
        {
            InitializeComponent();
            CargarOrdenes();
        }
        SqlConnection cn =
    new SqlConnection(Conexion.cadena);

        private void Frmhistorial_Load(object sender, EventArgs e)
        {

        }

        private void CargarOrdenes()
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                string sql = @"
        SELECT 
            o.id_orden,
            o.fecha,
            e.nombre AS empleado,
            f.total
        FROM ordenes o
        INNER JOIN empleados e ON o.id_empleado = e.id_empleado
        INNER JOIN facturacion f ON o.id_orden = f.id_orden
        ORDER BY o.id_orden DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                DataTable dt = new DataTable();

                da.Fill(dt);
                da.Fill(dt);

                dgvhisto.AutoSizeColumnsMode =
                 DataGridViewAutoSizeColumnsMode.Fill;

                dgvhisto.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvhisto.ReadOnly = true;


                dgvhisto.DataSource = dt;
            }
        }

        private void butcargar_Click(object sender, EventArgs e)
        {
            CargarOrdenes();
        }

        private void butbusc_Click(object sender, EventArgs e)
        {

            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                string sql = @"
        SELECT 
            o.id_orden,
            o.fecha,
            e.nombre,
            f.total
        FROM ordenes o
        INNER JOIN empleados e ON o.id_empleado = e.id_empleado
        INNER JOIN facturacion f ON o.id_orden = f.id_orden
        WHERE o.fecha BETWEEN @desde AND @hasta
        ORDER BY o.id_orden DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, cn);

                da.SelectCommand.Parameters.AddWithValue("@desde", dtpdesde.Value);
                da.SelectCommand.Parameters.AddWithValue("@hasta", dtphasta.Value);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvhisto.DataSource = dt;
            }
        }

        private void dgvhisto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idOrden = Convert.ToInt32(dgvhisto.Rows[e.RowIndex].Cells[0].Value);

                Frmdetallesordenes frm = new Frmdetallesordenes(idOrden);
                frm.Show();
            }
        }

        private void buteli_Click(object sender, EventArgs e)
        {

            
             //1. PRIMERA ADVERTENCIA
            
            DialogResult r1 = MessageBox.Show(
                "⚠ ADVERTENCIA:\n\nVas a eliminar !TODO! el historial de órdenes.\nEsta accion es IRREPARABLE.",
                "PRIMERA CONFIRMACION",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (r1 != DialogResult.Yes)
                return;

            // =========================
            // 2. SEGUNDA ADVERTENCIA (CRÍTICA)
            // =========================
            DialogResult r2 = MessageBox.Show(
                " ÚLTIMA ADVERTENCIA:\n\nEsta acción NO se puede deshacer.\nSe perderán TODAS las ventas permanentemente.\n\n¿Seguro que desea continuar?",
                "Confirmación final",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error);

            if (r2 != DialogResult.Yes)
                return;

            // =========================
            // 3. BORRADO EN BASE DE DATOS
            // =========================
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.cadena))
                {
                    cn.Open();

                    // IMPORTANTE: primero detalle, luego facturación, luego orden
                    SqlCommand cmd1 = new SqlCommand("DELETE FROM detalleordenes", cn);
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("DELETE FROM facturacion", cn);
                    cmd2.ExecuteNonQuery();

                    SqlCommand cmd3 = new SqlCommand("DELETE FROM ordenes", cn);
                    cmd3.ExecuteNonQuery();
                }

                // =========================
                // 4. LIMPIAR INTERFAZ
                // =========================
                dgvhisto.DataSource = null;
                dgvhisto.Rows.Clear();

                MessageBox.Show("OK se ha eliminado TODO el historial",
                    "Se ha hecho",
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

