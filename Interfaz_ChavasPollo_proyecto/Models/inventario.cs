using System;
using System.Collections.Generic;

namespace Interfaz_ChavasPollo_proyecto.Models;

public partial class inventario
{
    public int id_inv { get; set; }

    public string nombre_prod { get; set; } = null!;

    public int cantidad { get; set; }

    public int id_unidad { get; set; }

    public int id_proveedor { get; set; }

    public virtual proveedore id_proveedorNavigation { get; set; } = null!;

    public virtual unidad_medidum id_unidadNavigation { get; set; } = null!;
}
