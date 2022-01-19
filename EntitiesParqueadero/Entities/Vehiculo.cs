using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesParqueadero.Entities
{
    public class Vehiculo
    {
        [Key]
        public int IdVehiculo { get; set; }
        //[Required(ErrorMessage = "IdTipoVehiculo es obligatorio")]
        public int IdTipoVehiculo { get; set; }
        //[Required(ErrorMessage = "Placa es obligatorio")]
        public string Placa { get; set; }
        //[Required(ErrorMessage = "HoraEntrada es obligatorio")]
        public DateTime HoraEntrada { get; set; }
        public DateTime? HoraSalida { get; set; }
    }
}
