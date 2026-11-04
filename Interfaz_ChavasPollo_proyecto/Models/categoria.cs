using System;
using System.Collections.Generic;

namespace Interfaz_ChavasPollo_proyecto.Models;

public partial class categoria
{
    public int id_categoria { get; set; }

    public string nombre_cat { get; set; } = null!;

    public virtual ICollection<menu> menus { get; set; } = new List<menu>();
}
