using System;
using System.Collections.Generic;

namespace AppInventario.InfraStructure.Data
{
    public partial class LineaProductos
    {
        public LineaProductos()
        {
            Productos = new HashSet<Productos>();
        }

        public int LineaProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
    }
}
