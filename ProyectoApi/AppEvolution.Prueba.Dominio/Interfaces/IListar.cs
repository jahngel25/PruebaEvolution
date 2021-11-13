using System;
using System.Collections.Generic;
using System.Text;

namespace AppEvolution.Prueba.Dominio.Interfaces
{
    public interface IListar<TEntidad, TEntidadID>
    {
        List<TEntidad> Listar();

        TEntidad SeleccionarPorID(TEntidadID entidadId);
    }
}
