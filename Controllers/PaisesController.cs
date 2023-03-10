using ListaDePaises.API.Entities;
using ListaDePaises.API.Models;
using ListaDePaises.API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListaDePaises.API.Controllers
{
    [Route("api/lista-paises")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        // DB Context
        private readonly PaisesDbContext _context;

        public PaisesController(PaisesDbContext context) // Recebendo via Injecao de dependencia
        {
            _context = context;
        }

        #region HTTP GET - api/lista-paises 

        [HttpGet]
        public IActionResult GetAll() 
        { 
            var paisesLista = _context.Paises.ToList();

            return Ok(paisesLista);
        }

        #endregion

        #region HTTP GET por ID - api/lista-paises/1 
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var listaPais = _context.Paises.SingleOrDefault(lp => lp.Id == id);   

            if (listaPais == null)
            {
                return NotFound();
            }

            return Ok(listaPais);
        }

        #endregion

        #region HTTP POST - api/lista-paises 

        [HttpPost]
        public IActionResult Post(AddPaisesInputModel model)
        {
            var paises = new Paises(model.Nome, model.Continente);

            _context.Paises.Add(paises);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = paises.Id}, model);   
        }
        #endregion

        #region HTTP PUT - api/lista-paises/1

        [HttpPut("{id}")]
        public IActionResult Put(int id, AddPaisesInputModel model)
        {
            var paisesUpdate = _context.Paises.SingleOrDefault(pu => pu.Id == id);

            if (paisesUpdate == null)
            {
                return NotFound();
            }

            paisesUpdate.Update(model.Nome, model.Continente);

            ///_context.Paises.Update(paisesUpdate); // Ver se precisa por ser do EF
            _context.SaveChanges();

            return NoContent();
        }

        #endregion

        #region HTTP DELETE api/lista-paises/1

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var paisesDelete = _context.Paises.SingleOrDefault(pd => pd.Id == id);

            if (paisesDelete == null)
            {
                return NotFound();
            }

            _context.Paises.Remove(paisesDelete);
            _context.SaveChanges();

            return NoContent(); 
        }
        #endregion
    }
}
