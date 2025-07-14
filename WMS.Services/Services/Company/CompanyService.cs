using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WMS.Contracts;
using WMS.Dtos;
using WMS.LoggerService;
using WMS.Models;
using WMS.Services.IServices;
using WMS.Utilities;

namespace WMS.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;
        private readonly ILoggerManager _logger;

        public CompanyService(IMapper mapper, ICompanyRepository CompanyRepository, ILoggerManager logger)
        {
            _mapper = mapper;
            _companyRepository = CompanyRepository;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ServiceResult<IEnumerable<CompanyCompactDto>>> GetAllServiceAsync()
        {
            try
            {
                var result = await _companyRepository.GetAllAsync();

                var destObjects = _mapper.Map<List<CompanyCompactDto>>(result);

                if (destObjects?.Count > 0)
                {
                    return new ServiceResult<IEnumerable<CompanyCompactDto>>(true, Handling.RecordsFetchedSuccessfully, destObjects);
                }
                else
                {
                    throw new KeyNotFoundException(Handling.NoRecordsFound);
                }
            }
            catch (KeyNotFoundException e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetAllServiceAsync), e.Message);
                return new ServiceResult<IEnumerable<CompanyCompactDto>>(true, Handling.NoRecordsFound, null);
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetAllServiceAsync), e.Message);
                return new ServiceResult<IEnumerable<CompanyCompactDto>>(true, Handling.FailedToFetchRecords, null);
            }
        }

        public async Task<ServiceResult<CompanyDto>> GetByIdServiceAsync(int id)
        {
            try
            {
                var result = await _companyRepository.GetByIdAsync(id);

                var destObject = _mapper.Map<CompanyDto>(result);

                if (destObject == null)
                {
                    throw new KeyNotFoundException(Handling.NoRecordFound);
                }
                else
                {
                    return new ServiceResult<CompanyDto>(true, Handling.RecordFetchedSuccessfully, destObject);
                }
            }
            catch (KeyNotFoundException e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetByIdServiceAsync), e.Message);
                return new ServiceResult<CompanyDto>(true, Handling.NoRecordFound, null);
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetByIdServiceAsync), e.Message);
                return new ServiceResult<CompanyDto>(true, Handling.FailedToFetchRecord, null);
            }
        }

        public async Task<ServiceResult<CompanyDto>> CreateServiceAsync(CompanyCreateDto createDto)
        {
            try
            {
                var obj = _mapper.Map<Company>(createDto);

                var result = _mapper.Map<CompanyDto>(await _companyRepository.CreateAsync(obj));

                if (result == null)
                {
                    throw new Exception(Handling.CreationFailed);
                }
                else
                {
                    return new ServiceResult<CompanyDto>(true, Handling.CreatedSuccessfully, result);
                }
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(CreateServiceAsync), e.Message);
                return new ServiceResult<CompanyDto>(true, Handling.CreationFailed, null);
            }
        }

        public async Task<ServiceResult<CompanyDto>> UpdateServiceAsync(CompanyEditDto editDto)
        {
            try
            {
                var found = await _companyRepository.GetByIdAsync(editDto.Id);

                if (found == null)
                {
                    throw new KeyNotFoundException(Handling.NoRecordFound);
                }
                else
                {
                    var obj = _mapper.Map(editDto, found);

                    var result = await _companyRepository.UpdateAsync(obj);

                    if (result == null)
                    {
                        throw new Exception(Handling.UpdationFailed);
                    }
                    else
                    {
                        return new ServiceResult<CompanyDto>(true, Handling.UpdatedSuccessfully, _mapper.Map<CompanyDto>(obj));
                    }
                }
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(UpdateServiceAsync), e.Message);
                return new ServiceResult<CompanyDto>(true, Handling.UpdationFailed, null);
            }
        }

        public async Task<ServiceResult<CompanyCompactDto>> DeleteServiceAsync(int id)
        {
            try
            {
                var found = await _companyRepository.GetByIdAsync(id);

                if (found == null)
                {
                    throw new KeyNotFoundException(Handling.NoRecordFound);
                }
                else
                {
                    var result = await _companyRepository.DeleteAsync(found);

                    if (result == null)
                    {
                        throw new Exception(Handling.DeletionFailed);
                    }
                    else
                    {
                        var resultDto = _mapper.Map<CompanyCompactDto>(result);
                        return new ServiceResult<CompanyCompactDto>(true, Handling.DeletedSuccessfully, resultDto);
                    }
                }
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(DeleteServiceAsync), e.Message);
                return new ServiceResult<CompanyCompactDto>(true, Handling.DeletionFailed, null);
            }
        }

        public async Task<ServiceResultPage<PagedList<CompanyCompactDto>>> GetAllPageServiceAsync(PageParameters pageParams)
        {
            try
            {
                var result = await _companyRepository.GetAllAsync();
                var compactDto = _mapper.Map<IEnumerable<CompanyCompactDto>>(result);

                if (compactDto == null)
                {
                    throw new KeyNotFoundException(Handling.NoRecordsFound);
                }
                else
                {
                    var pageResult = PagedList<CompanyCompactDto>.ToPagedList(compactDto, pageParams.PageNumber, pageParams.PageSize);
                    var pageCounts = ServicePage<CompanyCompactDto>.WrapPageCounts(pageResult);

                    return new ServiceResultPage<PagedList<CompanyCompactDto>>(true, Handling.RecordsFetchedSuccessfully, pageCounts, pageResult);
                }
            }
            catch (KeyNotFoundException e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetAllPageServiceAsync), e.Message);
                return new ServiceResultPage<PagedList<CompanyCompactDto>>(true, Handling.NoRecordsFound, null);
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetAllPageServiceAsync), e.Message);
                return new ServiceResultPage<PagedList<CompanyCompactDto>>(true, Handling.FailedToFetchRecords, null);
            }
        }
    }
}