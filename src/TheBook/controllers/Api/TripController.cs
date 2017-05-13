using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBook.ViewModels;
using TheBook.Repository;
using AutoMapper;

namespace TheBook.controllers.Api
{
    [Route("api/trips")]
    public class TripController:Controller
    {
        private ITheBookRepository _repository;

        public TripController(ITheBookRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("")]
        public IActionResult Get()
        {
            //return Ok(new Trip() {
            //    Name="Hello I am from api"
            //});
            return Ok(_repository.GetAllCars());
        }
        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]Trip theTrip)
        {

            if (ModelState.IsValid)
            {
                var newTrip = Mapper.Map<models.Trip>(theTrip);
                _repository.AddTrip(newTrip);
                if(await _repository.SaveChangesAsyn())
                {
                    return Created($"api/trip/{theTrip.Name}", Mapper.Map<ViewModels.Trip>(newTrip));
                }
               
            }
            //return Ok(true);
            return BadRequest(ModelState);
        }
    }
}
