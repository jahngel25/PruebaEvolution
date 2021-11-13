using System;
using System.Collections.Generic;
using System.Text;

namespace AppEvolution.Prueba.Dominio.Entidades
{
    public partial class Producto
    {
        public Guid ProID { get; set; }
        public string ProDesc { get; set; }
        public decimal ProValor { get; set; }
        public int ProEstado { get; set; }
        public DateTime ProFechaCre { get; set; }
        public DateTime ProFechaActu { get; set; }
    }
}
