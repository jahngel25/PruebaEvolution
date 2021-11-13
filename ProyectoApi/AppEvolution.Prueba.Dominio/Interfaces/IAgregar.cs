using System;
using System.Collections.Generic;
using System.Text;

namespace AppEvolution.Prueba.Dominio.Interfaces
{
    public interface IAgregar<TEntidad>
    {
        TEntidad Agregar(TEntidad entidad);
    }
}
