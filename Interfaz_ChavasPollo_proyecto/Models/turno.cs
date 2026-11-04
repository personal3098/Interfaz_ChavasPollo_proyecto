using System;
using System.Collections.Generic;

namespace Interfaz_ChavasPollo_proyecto.Models;

public partial class turno
{
    public int id_turnos { get; set; }

    public string nombre_turno { get; set; } = null!;

    public virtual ICollection<empleado> empleados { get; set; } = new List<empleado>();
}
