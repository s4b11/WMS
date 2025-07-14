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
    public class CustomerController : ApiBaseController
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<CustomerCompactDto>>>> Get()
        {
            return new ResponseHelper().GetResponse(await _service.GetAllServiceAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<CustomerDto>>> Get([FromRoute] int id)
        {
            return new ResponseHelper().GetResponse(await _service.GetByIdServiceAsync(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse<CustomerDto>>> Post(CustomerCreateDto createDto)
        {
            return new ResponseHelper().GetResponse(await _service.CreateServiceAsync(createDto));
        }

        [HttpPut]
        public async Task<ActionResult<ApiResponse<CustomerDto>>> Put(CustomerEditDto editDto)
        {
            return new ResponseHelper().GetResponse(await _service.UpdateServiceAsync(editDto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<CustomerCompactDto>>> Delete(int id)
        {
            return new ResponseHelper().GetResponse(await _service.DeleteServiceAsync(id));
        }

        [HttpGet]
        [Route("GetAllCustomerPage")]
        public async Task<ActionResult<ApiResponse<PagedList<CustomerCompactDto>>>> GetAllCustomerPage([FromQuery] PageParameters pageParams)
        {
            return new ResponseHelper().GetResponse(await _service.GetAllPageServiceAsync(pageParams));
        }
    }
}