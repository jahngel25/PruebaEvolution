using System;
using System.Collections.Generic;
using System.Text;

using AppEvolution.Prueba.Dominio.Interfaces;

namespace AppEvolution.Prueba.Aplicaciones.Interfaces.Pedido
{
    public interface IServicioPedido<TEntidad, TEntidadID>
        : IAgregar<TEntidad>, IListar<TEntidad, TEntidadID>, IEditar<TEntidad>, IEliminar<TEntidadID>
    {
    }
}
