using System;
using System.Collections.Generic;

namespace sistemaGestioDeDatos.Web.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly Fecha { get; set; }

    public decimal? Cuenta { get; set; }

    public string? Clave { get; set; }

}


