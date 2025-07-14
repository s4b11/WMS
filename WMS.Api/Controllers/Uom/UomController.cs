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
    public class UomController : ApiBaseController
    {
        private readonly IUomService _service;

        public UomController(IUomService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<UomCompactDto>>>> Get()
        {
            return new ResponseHelper().GetResponse(await _service.GetAllServiceAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<UomDto>>> Get([FromRoute] int id)
        {
            return new ResponseHelper().GetResponse(await _service.GetByIdServiceAsync(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse<UomDto>>> Post(UomCreateDto createDto)
        {
            return new ResponseHelper().GetResponse(await _service.CreateServiceAsync(createDto));
        }

        [HttpPut]
        public async Task<ActionResult<ApiResponse<UomDto>>> Put(UomEditDto editDto)
        {
            return new ResponseHelper().GetResponse(await _service.UpdateServiceAsync(editDto));
        }

        [HttpDelete("{id}")]


        public async Task<ActionResult<ApiResponse<UomCompactDto>>> Delete(int id)
        {
            return new ResponseHelper().GetResponse(await _service.DeleteServiceAsync(id));
        }

        [HttpGet]
        [Route("GetAllUomPage")]
        public async Task<ActionResult<ApiResponse<PagedList<UomCompactDto>>>> GetAllUomPage([FromQuery] PageParameters pageParams)
        {
            return new ResponseHelper().GetResponse(await _service.GetAllPageServiceAsync(pageParams));
        }
    }
}