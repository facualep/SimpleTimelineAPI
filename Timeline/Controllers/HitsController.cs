using System;
using System.Collections.Generic;
using System.Net;
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
        }

        public ActionResult<List<Hit>> Get() {
            List<Hit> hits;

            try
            {
                hits = _hitsService.Get();
                return new OkObjectResult(
                    new Response(HttpStatusCode.OK, false, hits)
                );
            }
            catch (Exception)
            {
                return new NotFoundObjectResult(
                    new Response(HttpStatusCode.InternalServerError, true, null, HttpStatusCode.InternalServerError.ToString())
                );
            }
        }

        [HttpGet("{id}", Name = "GetHit")]
        public ActionResult<Hit> Get(string id)
        {
            var hit = _hitsService.Get(id);

            if (hit == null)
            {
                return new NotFoundObjectResult(
                    new Response(HttpStatusCode.NotFound, true, null, HttpStatusCode.NotFound.ToString())
                );
            };


            return new OkObjectResult(
                new Response(HttpStatusCode.OK, false, hit)
                );
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
            try
            {
                _hitsService.Create(hit);
                var response = new Response(HttpStatusCode.Created, false, hit, HttpStatusCode.Created.ToString());

                return CreatedAtRoute("GetHit", new { id = hit.Id }, response);
            }
            catch
            {
                return new BadRequestObjectResult(
                    new Response(HttpStatusCode.BadRequest, true, null, HttpStatusCode.BadRequest.ToString())
                );
            }
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
