using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AppEvolution.Prueba.Dominio.Entidades;
using AppEvolution.Prueba.Dominio.Interfaces.Repositorios.Producto;
using AppEvolution.Prueba.Infraestructura.Datos.Contextos;

namespace AppEvolution.Prueba.Infraestructura.Datos.Repositorios.Productos
{
    public class ProductoRepositorio : IRepositorioProducto<Producto, Guid>
    {
        private PruebaEvolutionContexto db;

        public ProductoRepositorio(PruebaEvolutionContexto _db)
        {
            db = _db;
        }

        public Producto Agregar(Producto entidad)
        {
            DateTime fecha = DateTime.Now;

            entidad.ProID = Guid.NewGuid();
            entidad.ProEstado = 1;
            entidad.ProFechaCre = fecha;
            entidad.ProFechaActu = fecha;
            db.Productos.Add(entidad);
            return entidad;
        }

        public void Editar(Producto entidad)
        {            
            var ProductoSeleccionado = db.Productos.Where(c => c.ProID == entidad.ProID).FirstOrDefault();
            if (ProductoSeleccionado != null)
            {
                ProductoSeleccionado.ProDesc = entidad.ProDesc;
                ProductoSeleccionado.ProValor = entidad.ProValor;
                ProductoSeleccionado.ProEstado = entidad.ProEstado;
                ProductoSeleccionado.ProFechaActu = entidad.ProFechaActu;

                db.Entry(ProductoSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(Guid entidadId)
        {
            var ProductoSeleccionado = db.Productos.Where(c => c.ProID == entidadId).FirstOrDefault();
            if (ProductoSeleccionado != null)
            {
                db.Remove(ProductoSeleccionado);
            }
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public List<Producto> Listar()
        {
            return db.Productos.ToList();
        }

        public Producto SeleccionarPorID(Guid entidadId)
        {
            var ProductoSeleccionado = db.Productos.Where(c => c.ProID == entidadId).FirstOrDefault();
            return ProductoSeleccionado;
        }
    }
}
