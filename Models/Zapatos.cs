using System;
using System.Collections.Generic;

namespace ZapateriaTBD.Models;

public partial class Zapatos
{
    public int Id { get; set; }

    public string Marca { get; set; } = null!;

    public int Talla { get; set; }

    public decimal Precio { get; set; }

    public string? Color { get; set; }

    public string? Descripcion { get; set; }
}
