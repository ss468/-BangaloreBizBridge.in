using InvestHub.Core.Dto;
using InvestHub.Core.Entities;
using InvestHub.Core.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvestHub.API.Controllers
{
    [Route("api/Pitch")]
    public class EnterprenerController : Controller
    {
        private readonly IPitchService _pitchService;

        public EnterprenerController(IPitchService pitchService)
        {
            _pitchService = pitchService;
        }

        [HttpPost("Create")]
        public IActionResult CreatePitch([FromBody] PitchDto pitchDto)
        {
            try
            {
                _pitchService.CreatePitch(pitchDto);
                return Ok("Pitch created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("GetAllPitch")]
        public IActionResult GetPitch([FromQuery]PitchType? type)
        {
            try
            {
                var pitch = _pitchService.GetPitchs(type);
                return Ok(pitch);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("{pitchId}")]
        public IActionResult GetPitch(string pitchId)
        {
            try
            {
                var pitch = _pitchService.GetPitchById(pitchId);
                return Ok(pitch);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut("{pitchId}")]
        public IActionResult UpdatePitch(string pitchId, [FromBody] PitchDto updatePitchDto)
        {
            try
            {
                _pitchService.UpdatePitch(pitchId, updatePitchDto);
                return Ok("Pitch updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{pitchId}")]
        public IActionResult DeletePitch(string pitchId)
        {
            try
            {
                _pitchService.DeletePitch(pitchId);
                return Ok("Pitch deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
