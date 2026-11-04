using System;
using System.Collections.Generic;

namespace Interfaz_ChavasPollo_proyecto.Models;

public partial class role
{
    public int id_rol { get; set; }

    public string nombre_rol { get; set; } = null!;

    public virtual ICollection<empleado> empleados { get; set; } = new List<empleado>();
}
