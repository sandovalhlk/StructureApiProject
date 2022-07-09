using System;
using System.Collections.Generic;

namespace AppInventario.InfraStructure.Data
{
    public partial class Pagos
    {
        public int PagoId { get; set; }
        public int OrdenId { get; set; }
        public DateTime FechaPago { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }

        public virtual Ordenes Orden { get; set; }
    }
}
