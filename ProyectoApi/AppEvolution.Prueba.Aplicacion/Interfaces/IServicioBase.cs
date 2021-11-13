using System;
using System.Collections.Generic;
using System.Text;

using AppEvolution.Prueba.Dominio.Interfaces;

namespace AppEvolution.Prueba.Aplicaciones.Interfaces
{
    public interface IServicioBase<TEntidad, TEntidadID>
        : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>
    {
    }
}
