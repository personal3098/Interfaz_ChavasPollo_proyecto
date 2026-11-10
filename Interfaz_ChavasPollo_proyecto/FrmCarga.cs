using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Interfaz_ChavasPollo_proyecto.Data;
using Microsoft.EntityFrameworkCore;

namespace Interfaz_ChavasPollo_proyecto
{
    public partial class FrmCarga : Form
    {
        public FrmCarga()
        {
            InitializeComponent();
        }
        private async void FrmCarga_Load(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Value = 0;

                // Etapa 1
                lblEstado.Text = "Conectando con SQL Server...";
                await Task.Delay(300);

                using (var db = Conexion.CrearContexto())
                {
                    bool conectado = await db.Database.CanConnectAsync();

                    if (!conectado)
                    {
                        throw new Exception("No se pudo conectar con la base de datos.");
                    }

                    progressBar1.Value = 30;
                    lblPorcentaje.Text = "30%";

                    // Etapa 2
                    lblEstado.Text = "Preparando información...";
                    await Task.Delay(300);

                    int categorias = await db.categorias.CountAsync();
                    progressBar1.Value = 50;
                    lblPorcentaje.Text = "50%";

                    // Etapa 3
                    lblEstado.Text = "Cargando menú...";
                    int menus = await db.menus.CountAsync();
                    progressBar1.Value = 70;
                    lblPorcentaje.Text = "70%";

                    // Etapa 4
                    lblEstado.Text = "Cargando empleados...";
                    int empleados = await db.empleados.CountAsync();
                    progressBar1.Value = 90;
                    lblPorcentaje.Text = "90%";
                }

                // Finalización
                lblEstado.Text = "Iniciando Chavas Pollo...";
                await Task.Delay(300);

                progressBar1.Value = 100;
                lblPorcentaje.Text = "100%";

                await Task.Delay(500);

                this.Hide();

                using (Frmprincipal principal = new Frmprincipal())
                {
                    principal.ShowDialog();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un problema al iniciar el sistema:\n" + ex.Message,
                    "Error de inicio",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Application.Exit();
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
