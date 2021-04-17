using demoMongoDB.Models;
using demoMongoDB.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationController : ControllerBase
    {
        private readonly InformationService _informationService;
        public InformationController(InformationService informationService)
        {
            _informationService = informationService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _informationService.GetAll());
        }
        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var customer = await _informationService.Get(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Information info)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _informationService.Create(info);
            return Ok(info.id);
        }
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Information info)
        {
            var information = await _informationService.Get(id);
            if (information == null)
            {
                return NotFound();
            }
            await _informationService.Update(id, info);
            return NoContent();
        }
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Active(string id, Information info)
        {
            var information = await _informationService.Get(id);
            if (information == null)
            {
                return NotFound();
            }
            await _informationService.Update(id, info);
            return NoContent();
        }
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Disable(string id, Information info)
        {
            var information = await _informationService.Get(id);
            if (information == null)
            {
                return NotFound();
            }
            await _informationService.Update(id, info);
            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var customer = await _informationService.Get(id);
            if (customer == null)
            {
                return NotFound();
            }
            await _informationService.Delete(id);
            return NoContent();
        }
    }
}

