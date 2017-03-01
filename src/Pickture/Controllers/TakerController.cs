using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pickture.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Pickture.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [EnableCors("AllowNewDevelopmentEnvironment")]
    public class TakerController : Controller
    {
        private PictureDbContext _context;

        public TakerController(PictureDbContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get([FromQuery] string takerName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IQueryable<Taker> users = from user in _context.Takers
                                      select user;

            if (takerName != null)
            {
                users = users.Where(g => g.TakerName == takerName);
            }

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);

        }

        //GET api/values/5
        [HttpGet("{id}", Name = "GetTaker")]
        public IActionResult Get(int id)
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

            return Ok(taker);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Taker taker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var existingUser = from g in _context.Takers
                               where g.TakerId == taker.TakerId
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

            return CreatedAtRoute("GetTaker", new {id = taker.TakerId }, taker);
        }

        // PUT api/values/5
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

        // DELETE api/values/5
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