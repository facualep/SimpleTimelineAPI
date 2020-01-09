using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Timeline.Models;
using Timeline.Services;

namespace Timeline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HitsController : ControllerBase
    {
        private readonly HitsService _hitsService;

        public HitsController(HitsService hitService)
        {
            _hitsService = hitService;
            //var aux2 = new Hit();
            //aux2.setId();
            //aux2.HitDate = DateTime.Now;
            //aux2.Title = "Todos somos ricos";
            //aux2.Description = "Aunque solo un poco";
            //Console.WriteLine(aux2.ToJson());
            ////var aux = DateTime.Now.ToJson();
            ////Console.WriteLine("DATE :" + aux);
        }

        public ActionResult<List<Hit>> Get() =>
            _hitsService.Get();

        [HttpGet("{id}", Name = "GetHit")]
        public ActionResult<Hit> Get(string id)
        {
            var hit = _hitsService.Get(id);

            if (hit == null)
            {
                return NotFound();
            }

            return hit;
        }

        //[HttpPost]
        //public ActionResult<Hit> Create(DateTime HitDate, string Title,
        //    string Description, List<string> Links )
        //{
        //    Console.WriteLine("DATE :" + HitDate);
        //    var hit = new Hit
        //    {
        //        HitDate = HitDate,
        //        Title = Title,
        //        Description = Description,
        //        Links = Links
        //    };
        //    _hitsService.Create(hit);

        //    return CreatedAtRoute("GetHit", new { id = hit.Id.ToString() });
        //}
        [HttpPost]
        public ActionResult<Hit> Create(Hit hit)
        {
            _hitsService.Create(hit);

            return CreatedAtRoute("GetHit", new { id = hit.Id }, hit);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Hit hitIn)
        {
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            return NoContent();
        }


    }
}
