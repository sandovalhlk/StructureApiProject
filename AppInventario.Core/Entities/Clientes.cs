using AppInventario.Core.Entities;
using System.Collections.Generic;

namespace AppInventario.InfraStructure.Data
{
    public partial class Clientes : BaseEntity
    {
        public Clientes()
        {
            Ordenes = new HashSet<Ordenes>();
        }

       
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Ordenes> Ordenes { get; set; }
    }
}
