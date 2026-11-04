using System;
using System.Collections.Generic;

namespace Interfaz_ChavasPollo_proyecto.Models;

public partial class menu
{
    public int id_menu { get; set; }

    public string nombre_platillo { get; set; } = null!;

    public decimal precio { get; set; }

    public int id_categoria { get; set; }

    public virtual ICollection<detalleordene> detalleordenes { get; set; } = new List<detalleordene>();

    public virtual categoria id_categoriaNavigation { get; set; } = null!;
}
