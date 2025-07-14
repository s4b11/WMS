using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WMS.Contracts;
using WMS.Contracts.IUom;
using WMS.Contracts.ILogger;
using WMS.Dtos;
using WMS.LoggerService;
using WMS.Models;
using WMS.Models.Models.UomModel;
using WMS.Services.IServices;
using WMS.Utilities;

namespace WMS.Services
{
    public class UomService : IUomService
    {
        private readonly IMapper _mapper;
        private readonly IUomRepository _uomRepository;
        private readonly ILoggerManager _logger;

        public UomService(IMapper mapper, IUomRepository UomRepository, ILoggerManager logger)
        {
            _mapper = mapper;
            _uomRepository = UomRepository;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ServiceResult<IEnumerable<UomCompactDto>>> GetAllServiceAsync()
        {
            try
            {
                var result = await _uomRepository.GetAllAsync();

                var destObjects = _mapper.Map<List<UomCompactDto>>(result);

                if (destObjects?.Count > 0)
                {
                    return new ServiceResult<IEnumerable<UomCompactDto>>(true, Handling.RecordsFetchedSuccessfully, destObjects);
                }
                else
                {
                    throw new KeyNotFoundException(Handling.NoRecordsFound);
                }
            }
            catch (KeyNotFoundException e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetAllServiceAsync), e.Message);
                return new ServiceResult<IEnumerable<UomCompactDto>>(true, Handling.NoRecordsFound, null);
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetAllServiceAsync), e.Message);
                return new ServiceResult<IEnumerable<UomCompactDto>>(true, Handling.FailedToFetchRecords, null);
            }
        }

        public async Task<ServiceResult<UomDto>> GetByIdServiceAsync(int id)
        {
            try
            {
                var result = await _uomRepository.GetByIdAsync(id);

                var destObject = _mapper.Map<UomDto>(result);

                if (destObject == null)
                {
                    throw new KeyNotFoundException(Handling.NoRecordFound);
                }
                else
                {
                    return new ServiceResult<UomDto>(true, Handling.RecordFetchedSuccessfully, destObject);
                }
            }
            catch (KeyNotFoundException e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetByIdServiceAsync), e.Message);
                return new ServiceResult<UomDto>(true, Handling.NoRecordFound, null);
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetByIdServiceAsync), e.Message);
                return new ServiceResult<UomDto>(true, Handling.FailedToFetchRecord, null);
            }
        }

        public async Task<ServiceResult<UomDto>> CreateServiceAsync(UomCreateDto createDto)
        {
            try
            {
                var obj = _mapper.Map<Uom>(createDto);

                var result = _mapper.Map<UomDto>(await _uomRepository.CreateAsync(obj));

                if (result == null)
                {
                    throw new Exception(Handling.CreationFailed);
                }
                else
                {
                    return new ServiceResult<UomDto>(true, Handling.CreatedSuccessfully, result);
                }
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(CreateServiceAsync), e.Message);
                return new ServiceResult<UomDto>(true, Handling.CreationFailed, null);
            }
        }

        public async Task<ServiceResult<UomDto>> UpdateServiceAsync(UomEditDto editDto)
        {
            try
            {
                var found = await _uomRepository.GetByIdAsync(editDto.Id);

                if (found == null)
                {
                    throw new KeyNotFoundException(Handling.NoRecordFound);
                }
                else
                {
                    var obj = _mapper.Map(editDto, found);

                    var result = await _uomRepository.UpdateAsync(obj);

                    if (result == null)
                    {
                        throw new Exception(Handling.UpdationFailed);
                    }
                    else
                    {
                        return new ServiceResult<UomDto>(true, Handling.UpdatedSuccessfully, _mapper.Map<UomDto>(obj));
                    }
                }
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(UpdateServiceAsync), e.Message);
                return new ServiceResult<UomDto>(true, Handling.UpdationFailed, null);
            }
        }

        public async Task<ServiceResult<UomCompactDto>> DeleteServiceAsync(int id)
        {
            try
            {
                var found = await _uomRepository.GetByIdAsync(id);

                if (found == null)
                {
                    throw new KeyNotFoundException(Handling.NoRecordFound);
                }
                else
                {
                    var result = await _uomRepository.DeleteAsync(found);

                    if (result == null)
                    {
                        throw new Exception(Handling.DeletionFailed);
                    }
                    else
                    {
                        var resultDto = _mapper.Map<UomCompactDto>(result);
                        return new ServiceResult<UomCompactDto>(true, Handling.DeletedSuccessfully, resultDto);
                    }
                }
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(DeleteServiceAsync), e.Message);
                return new ServiceResult<UomCompactDto>(true, Handling.DeletionFailed, null);
            }
        }

        public async Task<ServiceResultPage<PagedList<UomCompactDto>>> GetAllPageServiceAsync(PageParameters pageParams)
        {
            try
            {
                var result = await _uomRepository.GetAllAsync();
                var compactDto = _mapper.Map<IEnumerable<UomCompactDto>>(result);

                if (compactDto == null)
                {
                    throw new KeyNotFoundException(Handling.NoRecordsFound);
                }
                else
                {
                    var pageResult = PagedList<UomCompactDto>.ToPagedList(compactDto, pageParams.PageNumber, pageParams.PageSize);
                    var pageCounts = ServicePage<UomCompactDto>.WrapPageCounts(pageResult);

                    return new ServiceResultPage<PagedList<UomCompactDto>>(true, Handling.RecordsFetchedSuccessfully, pageCounts, pageResult);
                }
            }
            catch (KeyNotFoundException e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetAllPageServiceAsync), e.Message);
                return new ServiceResultPage<PagedList<UomCompactDto>>(true, Handling.NoRecordsFound, null);
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetAllPageServiceAsync), e.Message);
                return new ServiceResultPage<PagedList<UomCompactDto>>(true, Handling.FailedToFetchRecords, null);
            }
        }
    }
}