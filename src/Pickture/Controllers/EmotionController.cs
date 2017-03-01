using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Pickture.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using Microsoft.ProjectOxford.Common;
using Microsoft.ProjectOxford.Emotion;


namespace Pickture.Controllers
{
        [Route("api/[controller]")]
        [Produces("application/json")]
        [EnableCors("AllowNewDevelopmentEnvironment")]
        public class EmotionsController : Controller
        {

            private PictureDbContext _context;

            public EmotionsController(PictureDbContext context)
            {
                _context = context;
            }

            // GET: api/values
            [HttpGet]
            public IActionResult Get()
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                IQueryable<object> emotion = from i in _context.Emotions
                                             select i;

                if (emotion == null)
                {
                    return NotFound();
                }

                return Ok(emotion);
            }

            // GET api/values/5
            [HttpGet("{id}", Name = "GetEmotion")]
            public IActionResult Get(int id)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Emotion emotions = _context.Emotions.Single(m => m.EmotionId == id);

                if (emotions == null)
                {
                    return NotFound();
                }

                return Ok(emotions);
            }


  
  
       

        //public async Task<ActionResult> Post(responseBody)
        //{
        //    Content = await responsebody;
        //    return CreatedAtRoute("GetEmotion", new { id = emotion.EmotionId }, emotion); ;
        //}
        // POST api/values
        [HttpPost]

       
        //public async IActionResult Task([FromBody]Emotion emotion)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        _context.Emotions.Add(emotion);
        //        try
        //        {
        //            _context.SaveChanges();
        //        }
        //        catch (DbUpdateException)
        //        {
        //            if (EmotionExists(emotion.EmotionId))
        //            {
        //                return new StatusCodeResult(StatusCodes.Status409Conflict);
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return CreatedAtRoute("GetEmotion", new { id = emotion.EmotionId }, emotion);
        //    }

            // PUT api/values/5
            [HttpPut("{id}")]
            public IActionResult Put(int id, [FromBody] Emotion emotion)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != emotion.EmotionId)
                {
                    return BadRequest();
                }

                _context.Entry(emotion).State = EntityState.Modified;

                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmotionExists(id))
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

                Emotion emotion = _context.Emotions.Single(m => m.EmotionId == id);
                if (emotion == null)
                {
                    return NotFound();
                }

                _context.Emotions.Remove(emotion);
                _context.SaveChanges();

                return Ok(emotion);
            }

            private bool EmotionExists(int id)
            {
                return _context.Emotions.Count(e => e.EmotionId == id) > 0;
            }
        }
    }
