using EntitiesParqueadero.AppDbContext;
using EntitiesParqueadero.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesParqueadero.Bussines
{
    public class BussinesTipoVehiculo
    {
        public List<TipoVehiculo> TipoVehiculoList(ApplicationDbContext context)
        {
            List<TipoVehiculo> lstTiposV = context.TipoVehiculo.ToList();

            return lstTiposV;
        }
    }
}
