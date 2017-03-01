using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Pickture.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;


namespace Pickture.Controllers
{
    //[EnableCors(origins: "http://localhost:8080/", headers: "*", methods: "*")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    //[EnableCors("AllowNewDevelopmentEnvironment")]
    [DisableCors]
    public class ImageController : Controller
    {

        private PictureDbContext _context;

        public ImageController(PictureDbContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get([FromQuery]int? TakerId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IQueryable<Image> Image = from i in _context.Images
                                              select i;

            if (TakerId != null)
            {
                Image = Image.Where(img => img.TakerId == TakerId);
            }

            if (Image == null)
            {
                return NotFound();
            }

            return Ok(Image);
        }



        // GET api/image/5

        [HttpGet("{id}", Name = "GetImage")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Image image = _context.Images.Single(m => m.ImageId == id);

            if (image == null)
            {
                return NotFound();
            }

            return Ok(image);
        }

        // POST api/images
        [HttpPost]
        [DisableCors]
        public IActionResult Post([FromBody]Image image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Images.Add(image);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ImageExists(image.ImageId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetImage", new { id = image.ImageId }, image);
        }

        // PUT api/images/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Image image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != image.ImageId)
            {
                return BadRequest();
            }

            _context.Entry(image).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageExists(id))
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

        // DELETE api/images/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Image image = _context.Images.SingleOrDefault(m => m.ImageId == id);
            if (image == null)
            {
                return NotFound();
            }

            _context.Images.Remove(image);
            _context.SaveChanges();

            return Ok(image);
        }

        private bool ImageExists(int id)
        {
            return _context.Images.Count(e => e.ImageId == id) > 0;
        }
    }
}
