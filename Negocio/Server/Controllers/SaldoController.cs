using BlazorCrud.Shared;
using Microsoft.AspNetCore.Mvc;
using Negocio.Bdata.Data.Entity;
using Negocio.Bdata.Data;
using Negocio.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace Negocio.Server.Controllers
{
    [ApiController]
    [Route("api/saldo")]
    public class SaldoController : ControllerBase
    {
        private readonly Context context;
        public SaldoController(Context context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Saldo>>> Get()
        {
            return await context.saldos.ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Saldo>> Get(int id)
        {
            var existe = await context.saldos.AnyAsync(x => x.Idsaldo == id);
            if (!existe)
            {
                return NotFound($"El saldo {id} no existe");
            }
            return await context.saldos.FirstOrDefaultAsync(x => x.Idsaldo == id);
        }
        [HttpPost]
        public async Task<ActionResult<int>> Post(SaldoDTO saldo)
        {
            var entidad = await context.saldos.FirstOrDefaultAsync(x => x.Idsaldo == saldo.Idsaldo);

            if (entidad != null)
            {
                return BadRequest("Ya existe un saldo con ese número");
            }
            try
            {
                Saldo x = new Saldo();
                x.Idsaldo = saldo.Idsaldo;
                x.SaldoF = saldo.SaldoF;
                x.SaldoR = saldo.SaldoR;

                context.saldos.Add(x);
                await context.SaveChangesAsync();
                return x.Idsaldo;

            }
            catch (Exception ex) { return BadRequest(ex); }


        }
        [HttpPut]
        public async Task<IActionResult> Editar(SaldoDTO saldoDT, int dni)
        {
            var responseApi = new ResponseAPI<int>();
            try
            {
                var saldoDTO = await context.saldos.FirstOrDefaultAsync(e => e.Idsaldo == dni);
                if (saldoDTO != null)
                {
                    saldoDTO.Idsaldo = saldoDT.Idsaldo;
                    saldoDTO.SaldoF = saldoDT.SaldoF;
                    saldoDTO.SaldoR = saldoDT.SaldoR;
              
                    context.saldos.Update(saldoDTO);
                    await context.SaveChangesAsync();
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = saldoDTO.Idsaldo;

                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Saldo no encontrada";
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
            var existe = await context.saldos.AnyAsync(x => x.id == Id);
            if (!existe)
            {
                return NotFound($"El saldo de id={Id} no existe");
            }
            Saldo pepe = new Saldo();
            pepe.id = Id;

            context.Remove(pepe);

            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
