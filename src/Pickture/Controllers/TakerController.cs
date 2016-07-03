using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pickture.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;


namespace Pickture.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [EnableCors("AllowDevelopmentEnvironment")]
    public class GeekController : Controller
    {
        private PictureDbContext _context;

        public GeekController(PictureDbContext context)
        {
            _context = context;
        }

        // GET: api/taker
        [HttpGet]
        public IActionResult Get([FromQuery] int TakerId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IQueryable<Taker> Taker = from taker in _context.Takers
                                     select new Taker
                                     {
                                         TakerId = taker.TakerId,
                                         TakerName = taker.TakerName,
                                         EmailAddress = taker.EmailAddress,
                     
                                     };

            if (Taker != null)
            {
                Taker = Taker.Where(g => g.TakerId == TakerId);
            }

            if (Taker == null)
            {
                return NotFound();
            }

            return Ok(Taker);
        }

       
        // POST api/taker
        [HttpPost]
        public IActionResult Post([FromBody]Taker taker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var existingUser = from g in _context.Takers
                               where g.TakerName == taker.TakerName
                               select g;

            if (existingUser.Count<Taker>() > 0)
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }


            _context.Takers.Add(taker);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TakerExists(taker.TakerId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetGeek", new { id = taker.TakerId }, taker);
        }

        // PUT api/taker/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Taker taker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taker.TakerId)
            {
                return BadRequest();
            }

            _context.Entry(taker).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TakerExists(taker.TakerId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }

        // DELETE api/taker/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Taker taker = _context.Takers.Single(m => m.TakerId == id);
            if (taker == null)
            {
                return NotFound();
            }

            _context.Takers.Remove(taker);
            _context.SaveChanges();

            return Ok(taker);
        }

        private bool TakerExists(int id)
        {
            return _context.Takers.Count(e => e.TakerId == id) > 0;
        }

    }
}
