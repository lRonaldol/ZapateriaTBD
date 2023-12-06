using ZapateriaTBD.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace ZapateriaTBD.DTOS
{
    public class ZapatosDTO
    {
        ZapateriaContext contenedor = new();
        public IEnumerable<Zapatos> GetAll()
        {
            return contenedor.Zapatos.Include(x=>x.IdCategoriasNavigation). OrderBy(x => x.Marca);
        }

        public void Agregar(Zapatos Z)
        {
            if (Z != null)
            {
                contenedor.Zapatos.Add(Z);
                contenedor.SaveChanges();
            }
        }

        public void Eliminar(Zapatos Z)
        {
            if (Z != null)
            {
                contenedor.Zapatos.Remove(Z);

            }
            contenedor.SaveChanges();
        }
        public bool Validar(Zapatos Z, out List<string> Errores)
        {
            Errores = new List<string>();
            if (string.IsNullOrWhiteSpace(Z.Marca))
                Errores.Add("Escribe El Nombre de la Marca");
            if (string.IsNullOrWhiteSpace(Z.Color))
                Errores.Add("Escribe el Color del Zapató");
            if (string.IsNullOrWhiteSpace(Z.Descripcion))
                Errores.Add("Escribe una breve descripcion");
            if (contenedor.Zapatos.Any(x => x.Marca == Z.Marca && x.Id != x.Id))
                Errores.Add("este zapato ya esta registrado");
            if (Z.Precio <= 0)
                Errores.Add("El precio debe ser Mayor a 0");
            if (Z.Talla <= 0)
                Errores.Add("Talla Invalida");
            return Errores.Count == 0;
        }
        public void Editar(Zapatos Z)
        {
            if( Z!=null)
            {
                var zp= contenedor.Zapatos.FirstOrDefault(x => x.Id == Z.Id);
                if( zp != null)
                {
                    zp.Marca = Z.Marca;
                    zp.Id = Z.Id;
                    zp.Descripcion = Z.Descripcion;
                    zp.Color = Z.Color;
                    zp.Precio = Z.Precio;
                    zp.Talla = Z.Talla;
                    zp.IdCategorias = Z.IdCategorias;
                }
                contenedor.SaveChanges();
            }
        }
    }
}
