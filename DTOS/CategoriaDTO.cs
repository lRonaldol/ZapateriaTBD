using ZapateriaTBD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZapateriaTBD.DTOS
{
    internal class CategoriaDTO
    {
        ZapateriaContext context = new ZapateriaContext();

        public IEnumerable<Categorias> GetAll()
        {
            return context.Categorias.OrderBy(c => c.Nombre);
        }
    } 
}
