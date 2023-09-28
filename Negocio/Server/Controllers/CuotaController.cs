using BlazorCrud.Shared;
using Microsoft.AspNetCore.Mvc;
using Negocio.Bdata.Data.Entity;
using Negocio.Bdata.Data;
using Negocio.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace Negocio.Server.Controllers
{
    [ApiController]
    [Route("api/cuota")]
    public class CuotaController : ControllerBase
    {
       
            private readonly Context context;

            public CuotaController(Context context)
            {
                this.context = context;
            }
            [HttpGet]
            public async Task<ActionResult<List<Cuota>>> Get()
            {
                return await context.cuotas.ToListAsync();
            }
            [HttpGet("{id:int}")]
            public async Task<ActionResult<List<Cuota>>> Get(int id)
            {
                var existe = await context.cuotas.AnyAsync(x => x.Idventa == id);
                if (!existe)
                {
                    return NotFound($"La Venta {id} no existe");
                }
                return await context.cuotas.ToListAsync();
            }
            [HttpPost]
            public async Task<ActionResult<int>> Post(CuotaDTO cuota)
            {
                Cuota x = new Cuota();
              
                try
                {
                   x.codigo_cuotas = cuota.Codigo_cuotas;
                    x.Numero_cuotas = cuota.Numero_cuotas;
                    x.total = cuota.total;
                    x.Idventa = cuota.idpersona;



                    context.cuotas.Add(x);
                    await context.SaveChangesAsync();
                    return x.Id;
               

            }
                catch (Exception ex) { return BadRequest(ex); }


            }
            [HttpPut]
            public async Task<IActionResult> Editar(CuotaDTO cuota, int Nc)
            {
                var responseApi = new ResponseAPI<int>();
                try
                {
                    var dbcuota = await context.cuotas.FirstOrDefaultAsync(e => e.Idventa == Nc);
                    if (dbcuota != null)
                    {
                        dbcuota.codigo_cuotas = cuota.Codigo_cuotas;
                        dbcuota.Numero_cuotas = cuota.Numero_cuotas;
                        dbcuota.total = cuota.total;




                        context.cuotas.Update(dbcuota);
                        await context.SaveChangesAsync();
                        responseApi.EsCorrecto = true;
                        responseApi.Valor = dbcuota.Id;

                    }
                    else
                    {
                        responseApi.EsCorrecto = false;
                        responseApi.Mensaje = "cuota no encontrada";
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
            public async Task<ActionResult> Delete(int id)
            {
                var existe = await context.cuotas.AnyAsync(x => x.Id == id);
                if (!existe)
                {
                    return NotFound($"La Cuota de id={id} no existe");
                }
                Cuota pepe = new Cuota();
                pepe.Id = id;
             
                context.Remove(pepe);

                await context.SaveChangesAsync();

                return Ok();
            }

        
    }
}
