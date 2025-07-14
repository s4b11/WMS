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
    public class CompanyController : ApiBaseController
    {
        private readonly ICompanyService _service;

        public CompanyController(ICompanyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<CompanyCompactDto>>>> Get()
        {
            return new ResponseHelper().GetResponse(await _service.GetAllServiceAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<CompanyDto>>> Get([FromRoute] int id)
        {
            return new ResponseHelper().GetResponse(await _service.GetByIdServiceAsync(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse<CompanyDto>>> Post(CompanyCreateDto createDto)
        {
            return new ResponseHelper().GetResponse(await _service.CreateServiceAsync(createDto));
        }

        [HttpPut]
        public async Task<ActionResult<ApiResponse<CompanyDto>>> Put(CompanyEditDto editDto)
        {
            return new ResponseHelper().GetResponse(await _service.UpdateServiceAsync(editDto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<CompanyCompactDto>>> Delete(int id)
        {
            return new ResponseHelper().GetResponse(await _service.DeleteServiceAsync(id));
        }

        [HttpGet]
        [Route("GetAllCompanyPage")]
        public async Task<ActionResult<ApiResponse<PagedList<CompanyCompactDto>>>> GetAllCompanyPage([FromQuery] PageParameters pageParams)
        {
            return new ResponseHelper().GetResponse(await _service.GetAllPageServiceAsync(pageParams));
        }
    }
}