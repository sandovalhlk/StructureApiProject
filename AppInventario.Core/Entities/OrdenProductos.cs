using System;
using System.Collections.Generic;

namespace AppInventario.InfraStructure.Data
{
    public partial class OrdenProductos
    {
        public int OrdenProductoId { get; set; }
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public double Cantidad { get; set; }
        public double PrecioUnitario { get; set; }

        public virtual Ordenes Orden { get; set; }
        public virtual Productos Producto { get; set; }
    }
}
