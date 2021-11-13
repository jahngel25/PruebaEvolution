using System;
using System.Collections.Generic;
using System.Text;

namespace AppEvolution.Prueba.Dominio.Interfaces.Repositorios.Pedido
{
    public interface IRepositorioPedido<TEntidad, TEntidadID>
        : IAgregar<TEntidad>, IListar<TEntidad, TEntidadID>, IEditar<TEntidad>, IEliminar<TEntidadID>, ITransaccion
    {
    }
}
