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
    public class CountryController : ApiBaseController
    {
        private readonly ICountryService _service;

        public CountryController(ICountryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<CountryCompactDto>>>> Get()
        {
            return new ResponseHelper().GetResponse(await _service.GetAllServiceAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<CountryDto>>> Get([FromRoute] int id)
        {
            return new ResponseHelper().GetResponse(await _service.GetByIdServiceAsync(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse<CountryDto>>> Post(CountryCreateDto createDto)
        {
            return new ResponseHelper().GetResponse(await _service.CreateServiceAsync(createDto));
        }

        [HttpPut]
        public async Task<ActionResult<ApiResponse<CountryDto>>> Put(CountryEditDto editDto)
        {
            return new ResponseHelper().GetResponse(await _service.UpdateServiceAsync(editDto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<CountryCompactDto>>> Delete(int id)
        {
            return new ResponseHelper().GetResponse(await _service.DeleteServiceAsync(id));
        }

        [HttpGet]
        [Route("GetAllCountryPage")]
        public async Task<ActionResult<ApiResponse<PagedList<CountryCompactDto>>>> GetAllCountryPage([FromQuery] PageParameters pageParams)
        {
            return new ResponseHelper().GetResponse(await _service.GetAllPageServiceAsync(pageParams));
        }
    }
}