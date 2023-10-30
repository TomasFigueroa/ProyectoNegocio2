using BlazorCrud.Shared;
using Microsoft.AspNetCore.Mvc;
using Negocio.Bdata.Data.Entity;
using Negocio.Bdata.Data;
using Negocio.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace Negocio.Server.Controllers
{
    [ApiController]
    [Route("api/venta")]
    public class Ventacontroller : ControllerBase
    {
       
      
            private readonly Context context;

            public Ventacontroller(Context context)
            {
                this.context = context;
            }
            [HttpGet]
            public async Task<ActionResult<List<Venta>>> Get()
            {
                return await context.ventas.ToListAsync();
            }
            [HttpGet("{id:int}")]
            public async Task<ActionResult<Venta>> Get(int Id)
            {
                var existe = await context.ventas.AnyAsync(x => x.id == Id);
                if (!existe)
                {
                    return NotFound($"La Venta {Id} no existe");
                }
                return await context.ventas.FirstOrDefaultAsync(x => x.id == Id);
            }
            [HttpPost]
            public async Task<ActionResult<int>> Post(VentaDTO venta)
            {
                Venta x = new Venta();
               
                try
                {

                    x.Saldo_Total = venta.codigo_venta;
                    x.descripcion = venta.descripcion;
                   x.Idpersona= venta.idpersona;

                    context.ventas.Add(x);
                    await context.SaveChangesAsync();
                    return x.id;

                }
                catch (Exception ex) { return BadRequest(ex); }


            }
            [HttpPut]
            public async Task<IActionResult> Editar(VentaDTO venta, int Nc)
            {
                var responseApi = new ResponseAPI<int>();
                try
                {
                    var dbventa = await context.ventas.FirstOrDefaultAsync(e => e.id == Nc);
                    if (dbventa != null)
                    {
                             dbventa.Saldo_Total = venta.codigo_venta;

                             dbventa.descripcion = venta.descripcion;



                    context.ventas.Update(dbventa);
                        await context.SaveChangesAsync();
                        responseApi.EsCorrecto = true;
                        responseApi.Valor = dbventa.id;

                    }
                    else
                    {
                        responseApi.EsCorrecto = false;
                        responseApi.Mensaje = "Venta no encontrada";
                    }
                }
                catch (Exception ex)
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = ex.Message;
                }
                return Ok(responseApi);
            }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Venta entidad, int id)
        {
            if (id != entidad.id)
            {
                return BadRequest("El id de la venta no corresponde.");
            }

            var existe = await context.ventas.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"La venta de id={id} no existe");
            }

            context.Update(entidad);
            await context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{Id:int}")]
            public async Task<ActionResult> Delete(int Id)
            {
                var existe = await context.ventas.AnyAsync(x => x.id == Id);
                if (!existe)
                {
                    return NotFound($"La Cuenta de id={Id} no existe");
                }
                Venta pepe = new Venta();
                pepe.id = Id;

                context.Remove(pepe);

                await context.SaveChangesAsync();

                return Ok();
            }
        
    }
}
