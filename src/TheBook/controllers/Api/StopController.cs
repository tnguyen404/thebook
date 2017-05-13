using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBook.Repository;
using TheBook.Service;

namespace TheBook.controllers.Api
{
    [Route("api/trips/{nameOfTrip}/stops")]
    public class StopController:Controller
    {
        private GeoCoordsService _geoService;
        private ILogger<StopController> _logger;
        private ITheBookRepository _repository;

        public StopController(ITheBookRepository repository
            ,ILogger<StopController>logger,GeoCoordsService geoService)
        {
            _repository = repository;
            _logger = logger;
            _geoService = geoService;
        }
        [HttpGet("")]
        public IActionResult Get(string nameOfTrip)
        {
            try
            {
                var trip = _repository.GetTripByName(nameOfTrip);

                return Ok(Mapper.Map<IEnumerable<ViewModels.Stop>>(trip.Stops.OrderBy(t => t.StopStatus).ToList()));
            }
            catch (Exception ex)
            {
                _logger.LogError($"can not get trip information {ex.Message}");
            }
            return BadRequest("bad data");
        }
        [HttpPost]
        public async Task<IActionResult> Post(string nameOfTrip,[FromBody]ViewModels.Stop viewStopModel)
        {
            try
            {
                //if the view model is valid
                if (ModelState.IsValid)
                {
                    var newStop = Mapper.Map<models.Stop>(viewStopModel);
                    //lookup the Geocode here
                    var result = await _geoService.GetCoordsAsync("VNPT Bình Dươngsss");
                    //save stop to DB
                    _repository.AddNewStop(nameOfTrip,newStop);
                    if (await _repository.SaveChangesAsyn())
                    {
                        //return if everything will be ok
                        var updateViewModel = Mapper.Map<ViewModels.Stop>(newStop);
                        return Created($"api/trips/{nameOfTrip}/stops/{newStop.Name}", updateViewModel);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"can not add stop ({viewStopModel.Longitude},{viewStopModel.Latitude}) information {ex.Message}");              
            }
            return BadRequest("bad data");
        }
    }
}
