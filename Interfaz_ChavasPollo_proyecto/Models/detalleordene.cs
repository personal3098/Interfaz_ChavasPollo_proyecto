using System;
using System.Collections.Generic;

namespace Interfaz_ChavasPollo_proyecto.Models;

public partial class detalleordene
{
    public int id_detalle { get; set; }

    public int id_orden { get; set; }

    public int id_menu { get; set; }

    public int cantidad { get; set; }

    public virtual menu id_menuNavigation { get; set; } = null!;

    public virtual ordene id_ordenNavigation { get; set; } = null!;
}
