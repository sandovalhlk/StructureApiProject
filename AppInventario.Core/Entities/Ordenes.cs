using System;
using System.Collections.Generic;

namespace AppInventario.InfraStructure.Data
{
    public partial class Ordenes
    {
        public Ordenes()
        {
            OrdenProductos = new HashSet<OrdenProductos>();
            Pagos = new HashSet<Pagos>();
        }

        public int OrdenId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaOrden { get; set; }
        public int Estado { get; set; }
        public string Comentarios { get; set; }

        public virtual Clientes Cliente { get; set; }
        public virtual ICollection<OrdenProductos> OrdenProductos { get; set; }
        public virtual ICollection<Pagos> Pagos { get; set; }
    }
}
