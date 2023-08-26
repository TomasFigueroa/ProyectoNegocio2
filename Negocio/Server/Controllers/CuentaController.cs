using BlazorCrud.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio.Bdata.Data;
using Negocio.Bdata.Data.Entity;
using Negocio.Shared.DTO;

namespace Negocio.Server.Controllers
{

    [ApiController]
    [Route("api/cuenta")]
    public class CuentaController : ControllerBase
    {
        private readonly Context context;

        public CuentaController(Context context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Cuenta>>> Get()
        {
            return await context.cuentas.ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Cuenta>> Get(int Id)
        {
            var existe = await context.cuentas.AnyAsync(x => x.id == Id);
            if (!existe)
            {
                return NotFound($"La Cuenta {Id} no existe");
            }
            return await context.cuentas.FirstOrDefaultAsync(x => x.id == Id);
        }
        [HttpPost]
        public async Task<ActionResult<int>> Post(CuentaDTO cuenta)
        {
            Cuenta x = new Cuenta();
            var entidad = await context.cuentas.FirstOrDefaultAsync(x => x.NumeroCuenta == cuenta.NumeroCuenta);

            if (entidad != null) 
            {
                return BadRequest("Ya existe una Cuenta con ese número");
            }
            try
            {
               
                x.SaldoTotal = cuenta.SaldoTotal;
                x.NumeroCuenta = cuenta.NumeroCuenta;
                x.Cuotas = cuenta.Cuotas;   

                context.cuentas.Add(x);
                await context.SaveChangesAsync();
                return x.id;

            }
            catch (Exception ex) { return BadRequest(ex); }


        }
        [HttpPut]
        public async Task<IActionResult> Editar(CuentaDTO cuenta, int Nc)
        {
            var responseApi = new ResponseAPI<int>();
            try
            {
                var dbcuenta = await context.cuentas.FirstOrDefaultAsync(e => e.NumeroCuenta == Nc);
                if (dbcuenta != null)
                {
                    dbcuenta.SaldoTotal = cuenta.SaldoTotal;
                    dbcuenta.NumeroCuenta = cuenta.NumeroCuenta;
                    dbcuenta.Cuotas = cuenta.Cuotas;
                  
                    context.cuentas.Update(dbcuenta);
                    await context.SaveChangesAsync();
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbcuenta.NumeroCuenta;

                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Cuenta no encontrada";
                }
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);
        }
        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var existe = await context.cuentas.AnyAsync(x => x.id == Id);
            if (!existe)
            {
                return NotFound($"La Cuenta de id={Id} no existe");
            }
            Cuenta pepe = new Cuenta();
            pepe.id = Id;

            context.Remove(pepe);

            await context.SaveChangesAsync();

            return Ok();
        }
    }

}
