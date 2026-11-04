using System;
using System.Collections.Generic;

namespace Interfaz_ChavasPollo_proyecto.Models;

public partial class unidad_medidum
{
    public int id_unidad { get; set; }

    public string nombrre_unidad { get; set; } = null!;

    public virtual ICollection<inventario> inventarios { get; set; } = new List<inventario>();
}
