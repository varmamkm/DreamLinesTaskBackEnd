using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DL.DTO;
using DL.Infrastructure.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DL.API.Controllers
{
    [Route("api/cruise")]
    [ApiController]
    public class CruiseController : ControllerBase
    {
        private readonly ICruiseService cruiseService;

        public CruiseController(ICruiseService cruiseService)
        {
            this.cruiseService = cruiseService;
        }

        [HttpGet]
        [Route("getcruiselines")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCruiseLines()
        {
            var result = await cruiseService.GetCruiseLines();

            return Ok(result);
        }

        [HttpGet]
        [Route("getships/{companyId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetShips(int companyId)
        {
            var result = await cruiseService.GetShips(companyId);

            return Ok(result);
        }

        [HttpGet]
        [Route("getcabincategory/{shipId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCabinCategory(int shipId)
        {
            var result = await cruiseService.GetCabinCategory(shipId);

            return Ok(result);
        }

        [HttpGet]
        [Route("getports")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPorts()
        {
            var result = await cruiseService.GetPorts();

            return Ok(result);
        }

        [HttpPost]
        [Route("createtrip")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateTrip(TripDTO obj)
        {
            if (obj.CompanyId == 0
                || obj.ShipId == 0 
                || obj.CabinTypeId == 0 
                || obj.DapartureDate == null)
            {
                 return BadRequest("Cruise, Ship & Cabintype are required");
            }

            var result = await cruiseService.CreateTrip(obj);

            return Ok(result);
        }
    }
}