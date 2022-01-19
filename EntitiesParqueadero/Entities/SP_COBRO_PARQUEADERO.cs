using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesParqueadero.Entities
{
    public class SP_COBRO_PARQUEADERO
    {
        public int IdVehiculo { get; set; }
        public DateTime HoraSalida { get; set; }
        public int Descuento { get; set; }
        public string? CodigoDescuento { get; set; }
    }
}
