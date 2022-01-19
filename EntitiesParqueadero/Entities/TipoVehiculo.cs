using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesParqueadero.Entities
{
    public class TipoVehiculo
    {
        [Key]
        public int IdTipoVehiculo { get; set; }
        public string Tipo { get; set; }
    }
}
