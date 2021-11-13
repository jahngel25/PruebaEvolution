using System;
using System.Collections.Generic;
using System.Text;

using AppEvolution.Prueba.Dominio.Entidades;
using AppEvolution.Prueba.Dominio.Interfaces.Repositorios;
using AppEvolution.Prueba.Dominio.Interfaces.Repositorios.Usuario;
using AppEvolution.Prueba.Aplicaciones.Interfaces.Pedido;
using AppEvolution.Prueba.Aplicaciones.Interfaces;

namespace AppEvolution.Prueba.Aplicaciones.Servicios
{
    //Se utiliza servicio base para dar ejemplo de no ser necesario crear un servicio para la entidad se maneja el base
    public class UsuarioServicio : IServicioBase<Usuario, Guid>
    {
        private readonly IRepositorioBase<Usuario, Guid> repoUsuario;

        public UsuarioServicio(IRepositorioBase<Usuario, Guid> _repoUsuario)
        {
            repoUsuario = _repoUsuario;
        }

        public Usuario Agregar(Usuario entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El Usuario es requerido  ");

            var resultIncidente = repoUsuario.Agregar(entidad);
            repoUsuario.GuardarTodosLosCambios();
            return resultIncidente;
        }

        public void Editar(Usuario entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El Usuario es requerido  ");

            repoUsuario.Editar(entidad);
            repoUsuario.GuardarTodosLosCambios();
        }

        public void Eliminar(Guid entidadId)
        {
            repoUsuario.Eliminar(entidadId);
        }

        public List<Usuario> Listar()
        {
            return repoUsuario.Listar();
        }

        public Usuario SeleccionarPorID(Guid entidadId)
        {
            return repoUsuario.SeleccionarPorID(entidadId);
        }
    }
}
