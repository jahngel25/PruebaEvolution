using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AppEvolution.Prueba.Dominio.Entidades;
using AppEvolution.Prueba.Dominio.Interfaces.Repositorios.Pedido;
using AppEvolution.Prueba.Infraestructura.Datos.Contextos;

namespace AppEvolution.Prueba.Infraestructura.Datos.Repositorios.Pedidos
{
    public class PedidoRepositorio : IRepositorioPedido<Pedido, Guid>
    {
        private PruebaEvolutionContexto db;

        public PedidoRepositorio(PruebaEvolutionContexto _db)
        {
            db = _db;
        }

        public Pedido Agregar(Pedido entidad)
        {
            DateTime fecha = DateTime.Now;
            
            entidad.PedID = Guid.NewGuid();
            entidad.PedTotal = entidad.PedVrUnit * entidad.PedCant;
            double iva = Convert.ToInt32(entidad.PedTotal) * 0.19;
            entidad.PedIVA = Convert.ToInt32(iva);
            entidad.PedSubTot = entidad.PedTotal - entidad.PedIVA;
            entidad.PedEstado = 1;
            entidad.PedFechaCre = fecha;
            entidad.PedFechaActu = fecha;

            db.Pedidos.Add(entidad);
            return entidad;
        }

        public void Editar(Pedido entidad)
        {
            var PedidoSeleccionado = db.Pedidos.Where(c => c.PedID == entidad.PedID).FirstOrDefault();
            if (PedidoSeleccionado != null)
            {
                PedidoSeleccionado.PedUsu = entidad.PedUsu;
                PedidoSeleccionado.PedProdID = entidad.PedProdID;
                PedidoSeleccionado.PedVrUnit = entidad.PedVrUnit;
                PedidoSeleccionado.PedCant = entidad.PedCant;
                PedidoSeleccionado.PedSubTot = entidad.PedSubTot;
                PedidoSeleccionado.PedIVA = entidad.PedIVA;
                PedidoSeleccionado.PedTotal = entidad.PedTotal;
                PedidoSeleccionado.PedEstado = entidad.PedEstado;
                PedidoSeleccionado.PedFechaActu = entidad.PedFechaActu;

                db.Entry(PedidoSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(Guid entidadId)
        {
            var PedidoSeleccionado = db.Pedidos.Where(c => c.PedID == entidadId).FirstOrDefault();
            if (PedidoSeleccionado != null)
            {
                db.Remove(PedidoSeleccionado);
            }
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public List<Pedido> Listar()
        {
            return db.Pedidos.ToList();
        }

        public Pedido SeleccionarPorID(Guid entidadId)
        {
            var PedidoSeleccionado = db.Pedidos.Where(c => c.PedID == entidadId).FirstOrDefault();
            return PedidoSeleccionado;
        }
    }
}
