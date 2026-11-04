using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;


namespace Interfaz_ChavasPollo_proyecto
{
    public partial class Frminventario : Form
    {
        //De esta manera cargamos las acciones al inicia en este caso cargar improv se va a ejecutar al abrir el form
        public Frminventario()
        {
            InitializeComponent();
            
        }
        // Aqui estamos llamando la clase conexion para no tener que escribir tanto en cada form cada ves que querramos cargar los datos de sql
        //Para mas info vea la clase conexion
        SqlConnection cn =
    new SqlConnection(Conexion.cadena);
        private void Frminventario_Load(object sender, EventArgs e)
        {

            Cargarprov();
            //ProbarConexionEF();
            CargarUnidades();
            MostrarInventario();

        }
        //para provar la conexion con entity
        //private void ProbarConexionEF()
        //{
        //  try
        //          {
        //            using (var db = Conexion.CrearContexto())
        //         {
        //           int cantidad = db.inventarios.Count();
        //
        //         MessageBox.Show(
        //           "Conexión exitosa con Entity Framework.\n" +
        //         "Productos encontrados: " + cantidad,
        //       "Chavas Pollo",
        //     MessageBoxButtons.OK,
        //   MessageBoxIcon.Information
        //);
        //}
        //}
        //catch (Exception ex)
        //{
        //  MessageBox.Show(
        //    "Error al conectar:\n" + ex.Message,
        //  "Error",
        //MessageBoxButtons.OK,
        // MessageBoxIcon.Error
        //);
        // }
        // }

        //Aqui se llaman y cargan los datos de la tabla ya creada en sql tambien esta esta ubicada en
        //el load por que se va a usar con instrucciones y no al iniciar el form, escribimos el codigo de igual forma el cual hariamos
        //en sql en este caso dice seleccionar id unidad nombrre unidad de la tabla unidad de medida 
        //lo adapta y lo muestra en una datatable
        //y por los combobox le añadimos de donde proviene el source en este caso la datatable creada y solo le pedimos
        //que los muestre con el codigo de comando display member y que tome como referencia el valuemember para 
        //ubicarlo en una posicion
        private void CargarUnidades()
        {
            using (var db = Conexion.CrearContexto())
            {
                var unidades = db.unidad_medida
                    .Select(u => new
                    {
                        u.id_unidad,
                        u.nombrre_unidad
                    })
                    .ToList();

                cmbuni.DataSource = unidades;
                cmbuni.DisplayMember = "nombrre_unidad";
                cmbuni.ValueMember = "id_unidad";

                cmbuni.SelectedIndex = -1;
            }
        }
        // El metodo cargar para llamar mas datos de la tabla con la diferencia de que este se hara al iniciar el form 
        //por eso esta ubicado cerca de inicializar componente misma idea para el combobox proveedor
        private void Cargarprov()
        {
            using (var db = Conexion.CrearContexto())
            {
                var proveedores = db.proveedores
                    .Select(p => new
                    {
                        p.id_proveedor,
                        p.nombre_prov
                    })
                    .ToList();

                cmbprov.DataSource = proveedores;
                cmbprov.DisplayMember = "nombre_prov";
                cmbprov.ValueMember = "id_proveedor";

                cmbprov.SelectedIndex = -1;
            }
        }
        // De esta manera llamamos y cargamos el inventario a este form esto lo vamos a ocupar mas tarde,
        //la manera de identificar es casi la misma Select las celdas de la tabla inventario con la diferencia
        //que aqui se hara un inner join para que pueda mostrar datos de otra tabla en este caso unidad de medida
        //y proveedores ya que los vamos a usar todo en un datatable
        private void MostrarInventario()
        {
            using (var db = Conexion.CrearContexto())
            {
                var datos = (
                    from i in db.inventarios
                    join u in db.unidad_medida
                        on i.id_unidad equals u.id_unidad
                    join p in db.proveedores
                        on i.id_proveedor equals p.id_proveedor
                    select new
                    {
                        i.id_inv,
                        i.nombre_prod,
                        i.cantidad,
                        i.id_unidad,
                        i.id_proveedor,
                        u.nombrre_unidad,
                        p.nombre_prov
                    }
                ).ToList();

                dgvinv.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvinv.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvinv.ReadOnly = true;

                dgvinv.AllowUserToAddRows = false;

                dgvinv.DataSource = datos;

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
            // Validar campos vacíos
            if (string.IsNullOrWhiteSpace(textid.Text) ||
                string.IsNullOrWhiteSpace(textnombrep.Text) ||
                string.IsNullOrWhiteSpace(textcant.Text))
            {
                MessageBox.Show("Complete todos los campos.");
                return;
            }

            // Validar ID
            if (!int.TryParse(textid.Text, out int id))
            {
                MessageBox.Show("El ID debe ser un número válido.");
                textid.Focus();
                return;
            }

            // Validar cantidad
            if (!int.TryParse(textcant.Text, out int cantidad))
            {
                MessageBox.Show("La cantidad debe ser un número válido.");
                textcant.Focus();
                return;
            }

            // Validar nombre
            if (textnombrep.Text.Any(char.IsDigit))
            {
                MessageBox.Show("El nombre no puede contener números.");
                textnombrep.Focus();
                return;
            }

            // Validar ComboBox
            if (cmbuni.SelectedValue == null ||
                cmbprov.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una unidad y un proveedor.");
                return;
            }

            try
            {
                using (var db = Conexion.CrearContexto())
                {
                    // Comprobar si existe el ID
                    bool existe = db.inventarios.Any(i => i.id_inv == id);

                    if (existe)
                    {
                        MessageBox.Show("El ID ingresado ya está registrado.");
                        textid.Focus();
                        return;
                    }

                    // Crear el nuevo producto
                    var producto = new Models.inventario
                    {
                        id_inv = id,
                        nombre_prod = textnombrep.Text.Trim(),
                        cantidad = cantidad,
                        id_unidad = Convert.ToInt32(cmbuni.SelectedValue),
                        id_proveedor = Convert.ToInt32(cmbprov.SelectedValue)
                    };

                    // Agregar a Entity Framework
                    db.inventarios.Add(producto);

                    // Guardar en SQL Server
                    db.SaveChanges();

                    MessageBox.Show(
                        "Producto agregado exitosamente.",
                        "Acción completada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }


                LimpiarCampos();
                MostrarInventario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo agregar el producto:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
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
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvinv.Rows[e.RowIndex];

            idOriginal = Convert.ToInt32(fila.Cells["id_inv"].Value);

            textid.Text = fila.Cells["id_inv"].Value.ToString();

            textnombrep.Text =
                fila.Cells["nombre_prod"].Value.ToString();

            textcant.Text =
                fila.Cells["cantidad"].Value.ToString();

            cmbuni.SelectedValue =
                Convert.ToInt32(fila.Cells["id_unidad"].Value);

            cmbprov.SelectedValue =
                Convert.ToInt32(fila.Cells["id_proveedor"].Value);

            // No permitir cambiar la clave primaria
            textid.ReadOnly = true;
        }



        //El metodo para modificar siempre con consulta para seleccionar las celdas de dicha tabla pero 
        //en este caso es update para actualizar los datos ingresados tambien se creo id original
        //cuyo proposito es guardar los valores anteriores para que la accion pueda ser reemplazada con 
        //nuevo id
        private void btnmodi_Click_1(object sender, EventArgs e)
        {
            if (idOriginal <= 0)
            {
                MessageBox.Show("Seleccione un producto para modificar.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textnombrep.Text) ||
                string.IsNullOrWhiteSpace(textcant.Text))
            {
                MessageBox.Show("Complete todos los campos.");
                return;
            }

            if (!int.TryParse(textcant.Text, out int cantidad))
            {
                MessageBox.Show("La cantidad debe ser numérica.");
                return;
            }

            if (textnombrep.Text.Any(char.IsDigit))
            {
                MessageBox.Show("El nombre no puede contener números.");
                return;
            }

            if (cmbuni.SelectedValue == null ||
                cmbprov.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una unidad y un proveedor.");
                return;
            }

            try
            {
                using (var db = Conexion.CrearContexto())
                {
                    var producto = db.inventarios.Find(idOriginal);

                    if (producto == null)
                    {
                        MessageBox.Show("No se encontró el producto.");
                        return;
                    }

                    producto.nombre_prod = textnombrep.Text.Trim();

                    producto.cantidad = cantidad;

                    producto.id_unidad =
                        Convert.ToInt32(cmbuni.SelectedValue);

                    producto.id_proveedor =
                        Convert.ToInt32(cmbprov.SelectedValue);

                    db.SaveChanges();

                    MessageBox.Show(
                        "Producto modificado correctamente.",
                        "Acción realizada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }

                LimpiarCampos();
                MostrarInventario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al modificar:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        //aqui se creo idoriginal para ser llamado y que guarde valores
        private int idOriginal;

        //Modo para eliminar ya que es una accion para borrar valores se le agrego una advertencia
        //de si o no
        private void button3_Click(object sender, EventArgs e)
        {
            if (idOriginal <= 0)
            {
                MessageBox.Show("Seleccione un producto para eliminar.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar este producto?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    using (var db = Conexion.CrearContexto())
                    {
                        var producto = db.inventarios.Find(idOriginal);

                        if (producto == null)
                        {
                            MessageBox.Show("El producto ya no existe.");
                            return;
                        }

                        db.inventarios.Remove(producto);

                        db.SaveChanges();

                        MessageBox.Show(
                            "Producto eliminado correctamente.",
                            "Borrado completado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }

                    LimpiarCampos();
                    MostrarInventario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "No se pudo eliminar el producto.\n" +
                        "Compruebe si está relacionado con otros registros.\n\n" +
                        ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }
        // metodo para buscar los valores esta configurado de tal manera que muestre todo lo relacionado con
        //lo ingresado inclusive si es una letra, Tiene su propio textbox que solo se utiliza para buscar
        private void button4_Click(object sender, EventArgs e)
        {
            string busqueda = textbusc.Text.Trim();

            using (var db = Conexion.CrearContexto())
            {
                var consulta =
                    from i in db.inventarios
                    join u in db.unidad_medida
                        on i.id_unidad equals u.id_unidad
                    join p in db.proveedores
                        on i.id_proveedor equals p.id_proveedor
                    select new
                    {
                        i.id_inv,
                        i.nombre_prod,
                        i.cantidad,
                        i.id_unidad,
                        i.id_proveedor,
                        u.nombrre_unidad,
                        p.nombre_prov
                    };

                if (!string.IsNullOrWhiteSpace(busqueda))
                {
                    consulta = consulta.Where(i =>
                        i.nombre_prod.Contains(busqueda));
                }

                dgvinv.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvinv.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvinv.ReadOnly = true;

                dgvinv.AllowUserToAddRows = false;

                dgvinv.DataSource = consulta.ToList();

                dgvinv.Columns["id_unidad"].Visible = false;
                dgvinv.Columns["id_proveedor"].Visible = false;
            }
        }
        private void LimpiarCampos()
        {
            textid.Clear();
            textnombrep.Clear();
            textcant.Clear();

            cmbuni.SelectedIndex = -1;
            cmbprov.SelectedIndex = -1;

            idOriginal = 0;

            textid.ReadOnly = false;

            textid.Focus();
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

