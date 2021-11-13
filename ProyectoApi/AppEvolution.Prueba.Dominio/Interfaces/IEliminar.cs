using System;
using System.Collections.Generic;
using System.Text;

namespace AppEvolution.Prueba.Dominio.Interfaces
{
    public interface IEliminar<TEntidadID>
    {
        void Eliminar(TEntidadID entidadId);
    }
}
