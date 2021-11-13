using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AppEvolution.Prueba.Dominio.Entidades;
using AppEvolution.Prueba.Aplicaciones.Servicios;
using AppEvolution.Prueba.Infraestructura.Datos.Contextos;
using AppEvolution.Prueba.Infraestructura.Datos.Repositorios.Productos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppEvolution.Prueba.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        ProductoServicio CrearServicio()
        {
            PruebaEvolutionContexto db = new PruebaEvolutionContexto();
            ProductoRepositorio repo = new ProductoRepositorio(db);
            ProductoServicio servicio = new ProductoServicio(repo);
            return servicio;
        }

        // GET: api/<IncidenteController>
        [HttpGet]
        public ActionResult<List<Producto>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<IncidenteController>/5
        [HttpGet("{id}")]
        public ActionResult<Producto> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.SeleccionarPorID(id));
        }

        // POST api/<IncidenteController>
        [HttpPost]
        public ActionResult Post([FromBody] Producto producto)
        {
            var servicio = CrearServicio();
            return Ok(servicio.Agregar(producto));
        }

        // PUT api/<IncidenteController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Producto producto)
        {
            var servicio = CrearServicio();
            producto.ProID = id;
            servicio.Editar(producto);
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
