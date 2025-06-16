using HotelSearch.Application.Contracts;
using HotelSearch.Application.Payloads.Requests;
using HotelSearch.Application.Payloads.Responses;
using HotelSearch.Service.Payloads.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HotelSearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private IBaseService<AddUpdateHotelRequest, GetHotelResponse, PaginateRequest> _service;
        public HotelController(IBaseService<AddUpdateHotelRequest, GetHotelResponse, PaginateRequest> service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddUpdateHotelRequest data)
        {
            var id = await _service.AddAsync(data);

            return CreatedAtAction(nameof(GetById), new { id }, new { id });
        }

        [HttpPost("paginated")]
        public async Task<IActionResult> GetPaginated(PaginateRequest request)
        {
            var result = await _service.GetPaginatedAsync(request);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, AddUpdateHotelRequest data)
        {
            await _service.UpdateAsync(id, data);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDelete(Guid id)
        {
            await _service.SoftDeleteAsync(id);

            return NoContent();
        }
    }
}
