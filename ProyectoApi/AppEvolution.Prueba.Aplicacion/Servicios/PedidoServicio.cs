using System;
using System.Collections.Generic;
using System.Text;

using AppEvolution.Prueba.Dominio.Entidades;
using AppEvolution.Prueba.Dominio.Interfaces.Repositorios.Pedido;
using AppEvolution.Prueba.Aplicaciones.Interfaces.Pedido;


namespace AppEvolution.Prueba.Aplicaciones.Servicios
{
    public class PedidoServicio : IServicioPedido<Pedido, Guid>
    {
        private readonly IRepositorioPedido<Pedido, Guid> repoPedido;

        public PedidoServicio(IRepositorioPedido<Pedido, Guid> _repoPedido)
        {
            repoPedido = _repoPedido;
        }

        public Pedido Agregar(Pedido entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El Pedido es requerido  ");

            var resultIncidente = repoPedido.Agregar(entidad);
            repoPedido.GuardarTodosLosCambios();
            return resultIncidente;
        }

        public void Editar(Pedido entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El Pedido es requerido  ");

            repoPedido.Editar(entidad);
            repoPedido.GuardarTodosLosCambios();
        }

        public void Eliminar(Guid entidadId)
        {
            repoPedido.Eliminar(entidadId);
        }

        public List<Pedido> Listar()
        {
            return repoPedido.Listar();
        }

        public Pedido SeleccionarPorID(Guid entidadId)
        {
            return repoPedido.SeleccionarPorID(entidadId);
        }
    }
}
