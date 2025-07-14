using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WMS.Api.Controllers;
using WMS.Api.Extensions;
using WMS.Dtos;
using WMS.Services.IServices;
using WMS.Utilities;

namespace WMS.Api.Controllers
{
    [Authorize]
    public class ZoneController : ApiBaseController
    {
        private readonly IZoneService _service;

        public ZoneController(IZoneService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<ZoneCompactDto>>>> Get()
        {
            return new ResponseHelper().GetResponse(await _service.GetAllServiceAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ZoneDto>>> Get([FromRoute] int id)
        {
            return new ResponseHelper().GetResponse(await _service.GetByIdServiceAsync(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse<ZoneDto>>> Post(ZoneCreateDto createDto)
        {
            return new ResponseHelper().GetResponse(await _service.CreateServiceAsync(createDto));
        }

        [HttpPut]
        public async Task<ActionResult<ApiResponse<ZoneDto>>> Put(ZoneEditDto editDto)
        {
            return new ResponseHelper().GetResponse(await _service.UpdateServiceAsync(editDto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<ZoneCompactDto>>> Delete(int id)
        {
            return new ResponseHelper().GetResponse(await _service.DeleteServiceAsync(id));
        }

        [HttpGet]
        [Route("GetAllZonePage")]
        public async Task<ActionResult<ApiResponse<PagedList<ZoneCompactDto>>>> GetAllZonePage([FromQuery] PageParameters pageParams)
        {
            return new ResponseHelper().GetResponse(await _service.GetAllPageServiceAsync(pageParams));
        }
    }
}