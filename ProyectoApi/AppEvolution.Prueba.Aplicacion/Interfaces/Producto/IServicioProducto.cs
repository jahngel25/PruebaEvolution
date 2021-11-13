using System;
using System.Collections.Generic;
using System.Text;

using AppEvolution.Prueba.Dominio.Interfaces;

namespace AppEvolution.Prueba.Aplicaciones.Interfaces.Producto
{
    public interface IServicioProducto<TEntidad, TEntidadID>
        : IAgregar<TEntidad>, IListar<TEntidad, TEntidadID>, IEditar<TEntidad>, IEliminar<TEntidadID>
    {
    }
}
