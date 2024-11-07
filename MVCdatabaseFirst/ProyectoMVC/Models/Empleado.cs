using System;
using System.Collections.Generic;

namespace ProyectoMVC.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? FechaIngreso { get; set; }
}
