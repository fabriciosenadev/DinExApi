using AutoMapper;
using DinExApi.API.DTO;
using DinExApi.Business.Interfaces;
using DinExApi.Domain.Models;
using DinExApi.Infrastructure.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DinExApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaunchesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILaunchService _launchService;

        public LaunchesController(IMapper mapper, ILaunchService launchService)
        {
            _mapper = mapper;
            _launchService = launchService;
        }

        // GET: api/Launches
        [HttpGet]
        public async Task<IActionResult> GetLaunch()
        {
            var launches = _mapper.Map<IEnumerable<Launch>>(await _launchService.FindAllAsync());

            return Ok(launches);
        }

        // GET: api/Launches/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLaunch(int id)
        {
            var launch = await _launchService.FindByIdAsync(id);

            if (launch == null)
            {
                return NotFound();
            }

            return Ok(launch);
        }

        // PUT: api/Launches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLaunch(int id, LaunchDTO launch)
        {
            if (id != launch.Id)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // POST: api/Launches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostLaunch(LaunchDTO launchDTO)
        {
            var launch = _mapper.Map<Launch>(launchDTO);
            await _launchService.AddAsync(launch);

            return Ok();
        }

        // DELETE: api/Launches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLaunch(int id)
        {
            var launch = await _launchService.DeleteAsync(id);

            if (launch == ErrorCode.Empty)
                return Ok();

            return BadRequest();
        }
    }
}
