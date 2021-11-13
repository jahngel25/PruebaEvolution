using System;
using System.Collections.Generic;
using System.Text;

using AppEvolution.Prueba.Dominio.Entidades;
using AppEvolution.Prueba.Dominio.Interfaces.Repositorios.Producto;
using AppEvolution.Prueba.Aplicaciones.Interfaces.Producto;


namespace AppEvolution.Prueba.Aplicaciones.Servicios
{
    public class ProductoServicio : IServicioProducto<Producto, Guid>
    {
        private readonly IRepositorioProducto<Producto, Guid> repoProducto;

        public ProductoServicio(IRepositorioProducto<Producto, Guid> _repoProducto)
        {
            repoProducto = _repoProducto;
        }

        public Producto Agregar(Producto entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El Producto es requerido  ");

            var resultIncidente = repoProducto.Agregar(entidad);
            repoProducto.GuardarTodosLosCambios();
            return resultIncidente;
        }

        public void Editar(Producto entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El Producto es requerido  ");

            repoProducto.Editar(entidad);
            repoProducto.GuardarTodosLosCambios();
        }

        public void Eliminar(Guid entidadId)
        {
            repoProducto.Eliminar(entidadId);
        }

        public List<Producto> Listar()
        {
            return repoProducto.Listar();
        }

        public Producto SeleccionarPorID(Guid entidadId)
        {
            return repoProducto.SeleccionarPorID(entidadId);
        }
    }
}
