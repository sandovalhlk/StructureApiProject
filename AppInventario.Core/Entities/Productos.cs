using System;
using System.Collections.Generic;

namespace AppInventario.InfraStructure.Data
{
    public partial class Productos
    {
        public Productos()
        {
            OrdenProductos = new HashSet<OrdenProductos>();
        }

        public int ProductoId { get; set; }
        public int? LineaProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? CantDisponible { get; set; }
        public double? Precio { get; set; }

        public virtual LineaProductos LineaProducto { get; set; }
        public virtual ICollection<OrdenProductos> OrdenProductos { get; set; }
    }
}
