using System;
using System.Collections.Generic;

namespace Interfaz_ChavasPollo_proyecto.Models;

public partial class facturacion
{
    public int id_factura { get; set; }

    public int id_orden { get; set; }

    public DateTime? fecha_factura { get; set; }

    public decimal? total { get; set; }

    public virtual ordene id_ordenNavigation { get; set; } = null!;
}
