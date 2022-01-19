using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesParqueadero.Entities
{
    public class Parqueadero
    {
        [Key]
        public int IdParqueadero { get; set; }
        public int Descuento { get; set; }
        public string CodigoDescuento { get; set; }
        public float ValorDescuento { get; set; }
        public float ValorTotal { get; set; }
        public int IdVehiculo { get; set; }
    }
}
