using System;
using System.Collections.Generic;

namespace Interfaz_ChavasPollo_proyecto.Models;

public partial class ordene
{
    public int id_orden { get; set; }

    public DateTime? fecha { get; set; }

    public int id_empleado { get; set; }

    public virtual ICollection<detalleordene> detalleordenes { get; set; } = new List<detalleordene>();

    public virtual ICollection<facturacion> facturacions { get; set; } = new List<facturacion>();

    public virtual empleado id_empleadoNavigation { get; set; } = null!;
}
