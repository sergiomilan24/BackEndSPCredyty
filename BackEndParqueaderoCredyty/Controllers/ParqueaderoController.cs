using BussinesParqueadero.Bussines;
using EntitiesParqueadero.AppDbContext;
using EntitiesParqueadero.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndParqueaderoCredyty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParqueaderoController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private BussinesTipoVehiculo bussinesTipoVehiculo;
        private FasesParqueadero fasesParqueadero;
        private readonly IConfiguration configuration;
        public ParqueaderoController(ApplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            bussinesTipoVehiculo = new BussinesTipoVehiculo();
            fasesParqueadero = new FasesParqueadero();
            this.configuration = configuration;
        }

        /// <summary>
        /// Servicio: informa que tipos de vehiculos hay para seleccionar (°Automovil, °Motocicleta, °Bicicleta)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<TipoVehiculo>> ListTipoVehiculo()
        {
            try
            {
                List<TipoVehiculo> lstTiposVehiculos = bussinesTipoVehiculo.TipoVehiculoList(context);
                return lstTiposVehiculos;
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }

        }

        /// <summary>
        /// Servicio 1 de la prueba: Registro sencillo del vehiculo
        /// </summary>
        /// <param name="vehiculo"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RegistroVehiculo([FromBody] Vehiculo vehiculo)
        {
            try
            {
                fasesParqueadero.InsertVehiculo(context, vehiculo);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        /// <summary>
        /// Servicio 2 de la prueba: Registro con sp para la logica del cobro
        /// </summary>
        /// <param name="spCobro"></param>
        /// <returns></returns>
        [HttpPost("sp")]
        public async Task<ActionResult<Parqueadero>> CobroParqueadero([FromBody] SP_COBRO_PARQUEADERO spCobro)
        {
            try
            {
                string cadenaCon = configuration["ConnectionStrings:DefaultConnection"];
                await fasesParqueadero.CobroParqueadero(spCobro, cadenaCon);
                Parqueadero parqueadero = new Parqueadero();
                parqueadero =await fasesParqueadero.getParqueadero(spCobro.IdVehiculo, context);
                return Ok(parqueadero);
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        /// <summary>
        /// Servicio 3 de la prueba: Carga el inventario del parqueadero
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        public ActionResult<List<Parqueadero>> InventarioCobrosParq()
        {
            try
            {
                return fasesParqueadero.InventarioParqueadero(context);
            }catch(Exception ex)
            {
                throw new Exception("", ex);
            }
        }
    }
}