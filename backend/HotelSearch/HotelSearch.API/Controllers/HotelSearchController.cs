using HotelSearch.Application.Contracts;
using HotelSearch.Application.Payloads.Requests;
using HotelSearch.Application.Payloads.Responses;
using Microsoft.AspNetCore.Mvc;

namespace HotelSearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelSearchController : ControllerBase
    {
        private IHotelSearchService<GetHotelDistanceResponse, PaginateHotelRequest> _service;
        public HotelSearchController(IHotelSearchService<GetHotelDistanceResponse, PaginateHotelRequest> service)
        {
            _service = service;
        }

        [HttpPost("paginated")]
        public async Task<IActionResult> GetPaginated(PaginateHotelRequest request)
        {
            var result = await _service.GetSortedHotelsServerSideAsync(request);

            return Ok(result);
        }
    }
}
