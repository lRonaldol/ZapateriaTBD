using System;
using System.Collections.Generic;

namespace ZapateriaTBD.Models;

public partial class Categorias
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Zapatos> Zapatos { get; set; } = new List<Zapatos>();
}
