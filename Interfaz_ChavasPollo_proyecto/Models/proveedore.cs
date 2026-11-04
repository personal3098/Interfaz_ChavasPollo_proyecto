using System;
using System.Collections.Generic;

namespace Interfaz_ChavasPollo_proyecto.Models;

public partial class proveedore
{
    public int id_proveedor { get; set; }

    public string nombre_prov { get; set; } = null!;

    public virtual ICollection<inventario> inventarios { get; set; } = new List<inventario>();
}
