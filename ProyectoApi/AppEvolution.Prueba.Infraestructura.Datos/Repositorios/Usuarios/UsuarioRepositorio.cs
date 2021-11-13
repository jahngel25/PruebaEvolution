using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AppEvolution.Prueba.Dominio.Entidades;
using AppEvolution.Prueba.Dominio.Interfaces.Repositorios.Usuario;
using AppEvolution.Prueba.Dominio.Interfaces.Repositorios;
using AppEvolution.Prueba.Infraestructura.Datos.Contextos;

namespace AppEvolution.Prueba.Infraestructura.Datos.Repositorios.Usuarios
{
    public class UsuarioRepositorio : IRepositorioBase<Usuario, Guid>
    {
        private PruebaEvolutionContexto db;

        public UsuarioRepositorio(PruebaEvolutionContexto _db)
        {
            db = _db;
        }

        public Usuario Agregar(Usuario entidad)
        {
            DateTime fecha = DateTime.Now;

            entidad.UsuID = Guid.NewGuid();
            entidad.UsuEstado = 1;
            entidad.UsuFechaCre = fecha;
            entidad.UsuFechaActu = fecha;
            db.Usuarios.Add(entidad);
            return entidad;
        }

        public void Editar(Usuario entidad)
        {
            var UsuarioSeleccionado = db.Usuarios.Where(c => c.UsuID == entidad.UsuID).FirstOrDefault();
            if (UsuarioSeleccionado != null)
            {
                UsuarioSeleccionado.UsuNombre = entidad.UsuNombre;
                UsuarioSeleccionado.UsuPass = entidad.UsuPass;
                UsuarioSeleccionado.UsuEstado = entidad.UsuEstado;
                UsuarioSeleccionado.UsuFechaActu = entidad.UsuFechaActu;

                db.Entry(UsuarioSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(Guid entidadId)
        {
            var UsuarioSeleccionado = db.Usuarios.Where(c => c.UsuID == entidadId).FirstOrDefault();
            if (UsuarioSeleccionado != null)
            {
                db.Remove(UsuarioSeleccionado);
            }
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return db.Usuarios.ToList();
        }

        public Usuario SeleccionarPorID(Guid entidadId)
        {
            var UsuarioSeleccionado = db.Usuarios.Where(c => c.UsuID == entidadId).FirstOrDefault();
            return UsuarioSeleccionado;
        }
    }
}
