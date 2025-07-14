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
    public class VendorService : IVendorService
    {
        private readonly IMapper _mapper;
        private readonly IVendorRepository _vendorRepository;
        private readonly ILoggerManager _logger;

        public VendorService(IMapper mapper, IVendorRepository VendorRepository, ILoggerManager logger)
        {
            _mapper = mapper;
            _vendorRepository = VendorRepository;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ServiceResult<IEnumerable<VendorCompactDto>>> GetAllServiceAsync()
        {
            try
            {
                var result = await _vendorRepository.GetAllAsync();

                var destObjects = _mapper.Map<List<VendorCompactDto>>(result);

                if (destObjects?.Count > 0)
                {
                    return new ServiceResult<IEnumerable<VendorCompactDto>>(true, Handling.RecordsFetchedSuccessfully, destObjects);
                }
                else
                {
                    throw new KeyNotFoundException(Handling.NoRecordsFound);
                }
            }
            catch (KeyNotFoundException e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetAllServiceAsync), e.Message);
                return new ServiceResult<IEnumerable<VendorCompactDto>>(true, Handling.NoRecordsFound, null);
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetAllServiceAsync), e.Message);
                return new ServiceResult<IEnumerable<VendorCompactDto>>(true, Handling.FailedToFetchRecords, null);
            }
        }

        public async Task<ServiceResult<VendorDto>> GetByIdServiceAsync(int id)
        {
            try
            {
                var result = await _vendorRepository.GetByIdAsync(id);

                var destObject = _mapper.Map<VendorDto>(result);

                if (destObject == null)
                {
                    throw new KeyNotFoundException(Handling.NoRecordFound);
                }
                else
                {
                    return new ServiceResult<VendorDto>(true, Handling.RecordFetchedSuccessfully, destObject);
                }
            }
            catch (KeyNotFoundException e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetByIdServiceAsync), e.Message);
                return new ServiceResult<VendorDto>(true, Handling.NoRecordFound, null);
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetByIdServiceAsync), e.Message);
                return new ServiceResult<VendorDto>(true, Handling.FailedToFetchRecord, null);
            }
        }

        public async Task<ServiceResult<VendorDto>> CreateServiceAsync(VendorCreateDto createDto)
        {
            try
            {
                var obj = _mapper.Map<Vendor>(createDto);

                var result = _mapper.Map<VendorDto>(await _vendorRepository.CreateAsync(obj));

                if (result == null)
                {
                    throw new Exception(Handling.CreationFailed);
                }
                else
                {
                    return new ServiceResult<VendorDto>(true, Handling.CreatedSuccessfully, result);
                }
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(CreateServiceAsync), e.Message);
                return new ServiceResult<VendorDto>(true, Handling.CreationFailed, null);
            }
        }

        public async Task<ServiceResult<VendorDto>> UpdateServiceAsync(VendorEditDto editDto)
        {
            try
            {
                var found = await _vendorRepository.GetByIdAsync(editDto.Id);

                if (found == null)
                {
                    throw new KeyNotFoundException(Handling.NoRecordFound);
                }
                else
                {
                    var obj = _mapper.Map(editDto, found);

                    var result = await _vendorRepository.UpdateAsync(obj);

                    if (result == null)
                    {
                        throw new Exception(Handling.UpdationFailed);
                    }
                    else
                    {
                        return new ServiceResult<VendorDto>(true, Handling.UpdatedSuccessfully, _mapper.Map<VendorDto>(obj));
                    }
                }
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(UpdateServiceAsync), e.Message);
                return new ServiceResult<VendorDto>(true, Handling.UpdationFailed, null);
            }
        }

        public async Task<ServiceResult<VendorCompactDto>> DeleteServiceAsync(int id)
        {
            try
            {
                var found = await _vendorRepository.GetByIdAsync(id);

                if (found == null)
                {
                    throw new KeyNotFoundException(Handling.NoRecordFound);
                }
                else
                {
                    var result = await _vendorRepository.DeleteAsync(found);

                    if (result == null)
                    {
                        throw new Exception(Handling.DeletionFailed);
                    }
                    else
                    {
                        var resultDto = _mapper.Map<VendorCompactDto>(result);
                        return new ServiceResult<VendorCompactDto>(true, Handling.DeletedSuccessfully, resultDto);
                    }
                }
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(DeleteServiceAsync), e.Message);
                return new ServiceResult<VendorCompactDto>(true, Handling.DeletionFailed, null);
            }
        }

        public async Task<ServiceResultPage<PagedList<VendorCompactDto>>> GetAllPageServiceAsync(PageParameters pageParams)
        {
            try
            {
                var result = await _vendorRepository.GetAllAsync();
                var compactDto = _mapper.Map<IEnumerable<VendorCompactDto>>(result);

                if (compactDto == null)
                {
                    throw new KeyNotFoundException(Handling.NoRecordsFound);
                }
                else
                {
                    var pageResult = PagedList<VendorCompactDto>.ToPagedList(compactDto, pageParams.PageNumber, pageParams.PageSize);
                    var pageCounts = ServicePage<VendorCompactDto>.WrapPageCounts(pageResult);

                    return new ServiceResultPage<PagedList<VendorCompactDto>>(true, Handling.RecordsFetchedSuccessfully, pageCounts, pageResult);
                }
            }
            catch (KeyNotFoundException e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetAllPageServiceAsync), e.Message);
                return new ServiceResultPage<PagedList<VendorCompactDto>>(true, Handling.NoRecordsFound, null);
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetAllPageServiceAsync), e.Message);
                return new ServiceResultPage<PagedList<VendorCompactDto>>(true, Handling.FailedToFetchRecords, null);
            }
        }
    }
}