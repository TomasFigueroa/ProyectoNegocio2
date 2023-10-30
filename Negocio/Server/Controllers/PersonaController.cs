using BlazorCrud.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio.Bdata.Data;
using Negocio.Bdata.Data.Entity;
using Negocio.Shared.DTO;

namespace Negocio.Server.Controllers
{
    [ApiController]
    [Route("api/personas")]
    public class PersonaController : ControllerBase
    {
        private readonly Context context;
        public PersonaController(Context context)
        {
            this.context = context;
        }
        [HttpGet] 
        public async Task<ActionResult<List<Personas>>> Get()
        {
            return await context.personas.ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Personas>> Get(int id)
        {
            var existe = await context.personas.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"La persona {id} no existe");
            }
            return await context.personas.FirstOrDefaultAsync(x => x.Id == id);
        }
        [HttpPost]
        public async Task<ActionResult<int>> Post(PersonaDTO persona)
        {
            var entidad = await context.personas.FirstOrDefaultAsync(x => x.DNI == persona.DNI);

            if (entidad != null)
            {
                return BadRequest("Ya existe una Persona con ese DNI");
            }
            try
            {
                Personas x = new Personas();
                x.DNI = persona.DNI;
                x.Nombre = persona.Nombre;
                x.Telefono = persona.Telefono;
                x.Email = persona.Email;
                x.Direccion = persona.Direccion;

                context.personas.Add(x);
                await context.SaveChangesAsync();
                return x.Id;

            }
            catch (Exception ex) { return BadRequest(ex); }
           
            
        }
        [HttpPut]
        public async Task<IActionResult> Editar(PersonaDTO personaDTO, int dni)
        {
            var responseApi = new ResponseAPI<int>();
            try
            {
                var dbPersona = await context.personas.FirstOrDefaultAsync(e => e.DNI == dni.ToString());
                if (dbPersona != null)
                {
                    dbPersona.DNI = personaDTO.DNI;
                    dbPersona.Nombre = personaDTO.Nombre;
                    dbPersona.Telefono = personaDTO.Telefono;
                    dbPersona.Email = personaDTO.Email;
                    dbPersona.Direccion = personaDTO.Direccion;
                    context.personas.Update(dbPersona);
                    await context.SaveChangesAsync();
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbPersona.Id;

                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Persona no encontrada";
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
        public async Task<ActionResult> Put(Personas entidad, int id)
        {
            if (id != entidad.Id)
            {
                return BadRequest("El id de la Persona no corresponde.");
            }

            var existe = await context.personas.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"La Personas de id={id} no existe");
            }

            context.Update(entidad);
            await context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.personas.AnyAsync(x => x.Id == id);
            if (!existe)
            {

                return NotFound($"La Persona No Existe");
            }
            
            Personas pepe = new Personas();
            pepe.Id = id;

            context.Remove(pepe);

            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
