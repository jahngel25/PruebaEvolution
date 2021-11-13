using System;
using System.Collections.Generic;
using System.Text;

namespace AppEvolution.Prueba.Dominio.Entidades
{
    public class Usuario
    {
        public Guid UsuID { get; set; }
        public string UsuNombre { get; set; }
        public string UsuPass { get; set; }
        public int UsuEstado { get; set; }
        public DateTime UsuFechaCre { get; set; }
        public DateTime UsuFechaActu { get; set; }
    }
}
