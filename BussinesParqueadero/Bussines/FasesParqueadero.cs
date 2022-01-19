using EntitiesParqueadero.AppDbContext;
using EntitiesParqueadero.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesParqueadero.Bussines
{
    public class FasesParqueadero
    {
        public Vehiculo InsertVehiculo(ApplicationDbContext context, Vehiculo vehiculo)
        {
            //vehiculo.HoraEntrada = DateTime.Now;
            vehiculo.HoraSalida = null;
            context.Vehiculo.Add(vehiculo);
            context.SaveChanges();
            return vehiculo;
        }

        public async Task<ActionResult<string>> CobroParqueadero(SP_COBRO_PARQUEADERO spCobro, string cadenaCon)
        {
            using (SqlConnection conn = new SqlConnection(cadenaCon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_COBRO_PARQUEADERO", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdVehiculo", spCobro.IdVehiculo));
                cmd.Parameters.Add(new SqlParameter("@HoraSalida", spCobro.HoraSalida));
                cmd.Parameters.Add(new SqlParameter("@Descuento", spCobro.Descuento));
                cmd.Parameters.Add(new SqlParameter("@CodigoDescuento", spCobro.CodigoDescuento));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            return "Ok";
        }

        public async Task<Parqueadero> getParqueadero(int idVehiculo, ApplicationDbContext context)
        {
            Parqueadero parqueadero = new Parqueadero();
            parqueadero = await context.Parqueadero.Where(pq => pq.IdVehiculo == idVehiculo).FirstOrDefaultAsync();
            return parqueadero;
        }

        public List<Parqueadero> InventarioParqueadero(ApplicationDbContext context)
        {
            return context.Parqueadero.ToList();
        }
    }
}
