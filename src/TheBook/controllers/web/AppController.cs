using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBook.Repository;
using TheBook.ViewModels;

namespace TheBook.controllers.web
{
    public class AppController:Controller
    {
        private IConfigurationRoot _config;
        private ITheBookRepository _repository;
        private ILogger<AppController> _logger;
        public AppController(IConfigurationRoot config
            , ITheBookRepository repository
            ,ILogger<AppController>logger)
        {
            _config = config;
            _repository = repository;
            _logger = logger;
        }
        public IActionResult Login()
        {
            return View();

        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BusinessDetails()
        {
            return View();
        }
        public IActionResult TaskLocation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> TaskLocation(Stop viewModelStop)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.AddNewLocation(Mapper.Map<models.Stop>(viewModelStop));
                    if(await _repository.SaveChangesAsyn())
                    {
                        ModelState.Clear();                        
                    }
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", "something wrong happend with db connection");
                    _logger.LogError($"Cannot add TaskLocation: {ex.Message}");
                }
            }
            return View();
        }
        public IActionResult MemberAssignment()
        {
            
            return View();
        }
        public IActionResult CarAssignment()
        {

            return View();
        }
        public IActionResult MemberProfile()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> MemberProfile(TeamMember viewModelTeamMember)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    _repository.AddNewMember(Mapper.Map<models.TeamMember>(viewModelTeamMember));
                    if (await _repository.SaveChangesAsyn())
                    {
                        ModelState.Clear();
                    }
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "something wrong happend with db connection");
                    _logger.LogError($"Cannot add MemberProfile: {ex.Message}");
                }

            }

            return View();
        }
        public IActionResult TaskUpdate()
        {
            return View();
        }
        public IActionResult CarDetails()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CarDetails(Car viewModelCar)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var test=_repository.AddNewCar(Mapper.Map<models.Car>(viewModelCar));
                    if (await _repository.SaveChangesAsyn())
                    {
                        ModelState.Clear();
                    }
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "something wrong happend with db connection");
                    _logger.LogError($"cannot add new car {ex.Message}");
                }

            }

            return View();
        }
        public IActionResult RoleDetails()
        {
            //var roleViewModel = Mapper.Map<ViewModels.RoleMember>(_repository.GetAllRoles());
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleDetails(RoleMember roleMember)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   
                    _repository.AddNewRole(Mapper.Map<models.RoleMember>(roleMember));              
                    if (await _repository.SaveChangesAsyn())
                    {
                        ModelState.Clear();
                    }
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "something wrong happend with db connection");
                    _logger.LogError($"cannot add RoleDetails: {ex.Message}");
                }

            }

            return View();
        }

    }
}
