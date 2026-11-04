using System;
using System.Linq;
using System.Windows.Forms;
using Interfaz_ChavasPollo_proyecto.Models;

namespace Interfaz_ChavasPollo_proyecto
{
    public partial class frmmenu : Form
    {
        private int idOriginalMenu;

        public frmmenu()
        {
            InitializeComponent();
        }

        private void frmmenu_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            MostrarMenu();
        }

        // Cargar las categorías desde la base de datos
        private void CargarCategorias()
        {
            using (var db = Conexion.CrearContexto())
            {
                var categorias = db.categorias
                    .Select(c => new
                    {
                        c.id_categoria,
                        c.nombre_cat
                    })
                    .ToList();

                cmbcat.DataSource = categorias;
                cmbcat.DisplayMember = "nombre_cat";
                cmbcat.ValueMember = "id_categoria";
                cmbcat.SelectedIndex = -1;
            }
        }

        // Mostrar los platillos registrados
        private void MostrarMenu()
        {
            using (var db = Conexion.CrearContexto())
            {
                var datos = (
                    from m in db.menus
                    join c in db.categorias
                    on m.id_categoria equals c.id_categoria
                    select new
                    {
                        m.id_menu,
                        m.nombre_platillo,
                        m.precio,
                        m.id_categoria,
                        c.nombre_cat
                    }
                ).ToList();

                dgvmenu.DataSource = datos;

                dgvmenu.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvmenu.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvmenu.ReadOnly = true;
                dgvmenu.AllowUserToAddRows = false;

                dgvmenu.Columns["nombre_platillo"].FillWeight = 200;
                dgvmenu.Columns["id_categoria"].Visible = false;
            }
        }

        // Agregar un nuevo platillo
        private void butagr_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textmen.Text) ||
                string.IsNullOrWhiteSpace(textnommen.Text) ||
                string.IsNullOrWhiteSpace(textprecio.Text))
            {
                MessageBox.Show("Complete todos los campos.");
                return;
            }

            if (textnommen.Text.Any(char.IsDigit))
            {
                MessageBox.Show(
                    "El nombre del producto no puede contener números.");

                textnommen.Focus();
                return;
            }

            if (!int.TryParse(textmen.Text, out int id))
            {
                MessageBox.Show("Ingrese un ID válido.");
                textmen.Focus();
                return;
            }

            if (!decimal.TryParse(textprecio.Text, out decimal precio))
            {
                MessageBox.Show("Ingrese un precio válido.");
                textprecio.Focus();
                return;
            }

            if (precio < 0)
            {
                MessageBox.Show("El precio no puede ser negativo.");
                textprecio.Focus();
                return;
            }

            if (cmbcat.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una categoría.");
                return;
            }

            using (var db = Conexion.CrearContexto())
            {
                // Comprobar si el ID ya existe
                bool existe = db.menus.Any(m => m.id_menu == id);

                if (existe)
                {
                    MessageBox.Show(
                        "El número de ID que escribió ya está registrado.");

                    textmen.Focus();
                    return;
                }

                // Crear el objeto del nuevo platillo
                var nuevoMenu = new menu
                {
                    id_menu = id,
                    nombre_platillo = textnommen.Text.Trim(),
                    precio = precio,
                    id_categoria = Convert.ToInt32(cmbcat.SelectedValue)
                };

                db.menus.Add(nuevoMenu);

                db.SaveChanges();

                MessageBox.Show(
                    "Platillo agregado correctamente.",
                    "Menú",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            LimpiarCampos();
            MostrarMenu();
        }

        // Seleccionar un platillo de la tabla
        private void dgvmenu_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvmenu.Rows[e.RowIndex];

            idOriginalMenu =
                Convert.ToInt32(fila.Cells["id_menu"].Value);

            textmen.Text =
                fila.Cells["id_menu"].Value.ToString();

            textnommen.Text =
                fila.Cells["nombre_platillo"].Value.ToString();

            textprecio.Text =
                fila.Cells["precio"].Value.ToString();

            cmbcat.SelectedValue =
                Convert.ToInt32(fila.Cells["id_categoria"].Value);

            // El ID no se modifica porque es la clave primaria
            textmen.ReadOnly = true;
        }

        // Modificar un platillo existente
        private void btnmodi_Click(object sender, EventArgs e)
        {
            if (idOriginalMenu <= 0)
            {
                MessageBox.Show("Seleccione un platillo de la tabla.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textnommen.Text) ||
                string.IsNullOrWhiteSpace(textprecio.Text))
            {
                MessageBox.Show("Complete todos los campos.");
                return;
            }

            if (textnommen.Text.Any(char.IsDigit))
            {
                MessageBox.Show(
                    "El nombre del producto no puede contener números.");

                textnommen.Focus();
                return;
            }

            if (!decimal.TryParse(textprecio.Text, out decimal precio))
            {
                MessageBox.Show("Ingrese un precio válido.");
                textprecio.Focus();
                return;
            }

            if (precio < 0)
            {
                MessageBox.Show("El precio no puede ser negativo.");
                textprecio.Focus();
                return;
            }

            if (cmbcat.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una categoría.");
                return;
            }

            using (var db = Conexion.CrearContexto())
            {
                var platillo = db.menus.Find(idOriginalMenu);

                if (platillo == null)
                {
                    MessageBox.Show("No se encontró el platillo.");
                    return;
                }

                platillo.nombre_platillo = textnommen.Text.Trim();
                platillo.precio = precio;
                platillo.id_categoria =
                    Convert.ToInt32(cmbcat.SelectedValue);

                db.SaveChanges();

                MessageBox.Show(
                    "Platillo modificado correctamente.",
                    "Menú",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            LimpiarCampos();
            MostrarMenu();
        }

        // Eliminar un platillo
        private void buteli_Click(object sender, EventArgs e)
        {
            if (idOriginalMenu <= 0)
            {
                MessageBox.Show("Seleccione un platillo de la tabla.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar este platillo?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                using (var db = Conexion.CrearContexto())
                {
                    var platillo = db.menus.Find(idOriginalMenu);

                    if (platillo == null)
                    {
                        MessageBox.Show("No se encontró el platillo.");
                        return;
                    }

                    db.menus.Remove(platillo);

                    db.SaveChanges();

                    MessageBox.Show(
                        "Platillo eliminado correctamente.",
                        "Menú",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                LimpiarCampos();
                MostrarMenu();
            }
        }

        private void textnommen_TextChanged(object sender, EventArgs e)
        {

        }

        // Buscar platillos por nombre
        private void butbusca_Click(object sender, EventArgs e)
        {
            using (var db = Conexion.CrearContexto())
            {
                string busqueda = textbusca.Text.Trim();

                var consulta =
                    from m in db.menus
                    join c in db.categorias
                    on m.id_categoria equals c.id_categoria
                    select new
                    {
                        m.id_menu,
                        m.nombre_platillo,
                        m.precio,
                        m.id_categoria,
                        c.nombre_cat
                    };

                if (!string.IsNullOrWhiteSpace(busqueda))
                {
                    consulta = consulta.Where(m =>
                        m.nombre_platillo.Contains(busqueda));
                }

                dgvmenu.DataSource = consulta.ToList();

                dgvmenu.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvmenu.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvmenu.ReadOnly = true;
                dgvmenu.AllowUserToAddRows = false;

                dgvmenu.Columns["nombre_platillo"].FillWeight = 200;
                dgvmenu.Columns["id_categoria"].Visible = false;
            }
        }

        // Limpiar los campos del formulario
        private void LimpiarCampos()
        {
            textmen.Clear();
            textnommen.Clear();
            textprecio.Clear();

            cmbcat.SelectedIndex = -1;

            idOriginalMenu = 0;

            textmen.ReadOnly = false;

            textmen.Focus();
        }

        // Permitir únicamente números en el ID
        private void textmen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Permitir letras y espacios en el nombre
        private void textnommen_KeyPress(
            object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsLetter(e.KeyChar) &&
                !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Permitir números y separador decimal en el precio
        private void textprecio_KeyPress(
            object sender, KeyPressEventArgs e)
        {
            char separador = System.Globalization.CultureInfo
                .CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != separador)
            {
                e.Handled = true;
            }

            if (e.KeyChar == separador &&
                textprecio.Text.Contains(separador))
            {
                e.Handled = true;
            }
        }
    }
}


