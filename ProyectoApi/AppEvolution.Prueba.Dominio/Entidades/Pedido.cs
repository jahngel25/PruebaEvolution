using System;
using System.Collections.Generic;
using System.Text;

namespace AppEvolution.Prueba.Dominio.Entidades
{
    public partial class Pedido
    {
        public Guid PedID { get; set; }
        public Guid PedUsu { get; set; }
        public Guid PedProdID { get; set; }
        public decimal PedVrUnit { get; set; }
        public int PedCant { get; set; }
        public decimal PedSubTot { get; set; }
        public decimal PedIVA { get; set; }
        public decimal PedTotal { get; set; }
        public int PedEstado { get; set; }
        public DateTime PedFechaCre { get; set; }
        public DateTime PedFechaActu { get; set; }
    }
}
