using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AppEvolution.Prueba.Dominio.Entidades;
using AppEvolution.Prueba.Aplicaciones.Servicios;
using AppEvolution.Prueba.Infraestructura.Datos.Contextos;
using AppEvolution.Prueba.Infraestructura.Datos.Repositorios.Pedidos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppEvolution.Prueba.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        PedidoServicio CrearServicio()
        {
            PruebaEvolutionContexto db = new PruebaEvolutionContexto();
            PedidoRepositorio repo = new PedidoRepositorio(db);
            PedidoServicio servicio = new PedidoServicio(repo);
            return servicio;
        }

        // GET: api/<IncidenteController>
        [HttpGet]
        public ActionResult<List<Pedido>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<IncidenteController>/5
        [HttpGet("{id}")]
        public ActionResult<Pedido> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.SeleccionarPorID(id));
        }

        // POST api/<IncidenteController>
        [HttpPost]
        public ActionResult Post([FromBody] Pedido pedido)
        {
            var servicio = CrearServicio();
            return Ok(servicio.Agregar(pedido));
        }

        // PUT api/<IncidenteController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Pedido pedido)
        {
            var servicio = CrearServicio();
            pedido.PedID = id;
            servicio.Editar(pedido);
            return Ok("Editado Correctamente!!!!!");
        }

        // DELETE api/<IncidenteController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicio();
            servicio.Eliminar(id);
            return Ok("Se elimino correctamente");
        }
    }
}
