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
    public class ZoneService : IZoneService
    {
        private readonly IMapper _mapper;
        private readonly IZoneRepository _zoneRepository;
        private readonly ILoggerManager _logger;

        public ZoneService(IMapper mapper, IZoneRepository ZoneRepository, ILoggerManager logger)
        {
            _mapper = mapper;
            _zoneRepository = ZoneRepository;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ServiceResult<IEnumerable<ZoneCompactDto>>> GetAllServiceAsync()
        {
            try
            {
                var result = await _zoneRepository.GetAllAsync();

                var destObjects = _mapper.Map<List<ZoneCompactDto>>(result);

                if (destObjects?.Count > 0)
                {
                    return new ServiceResult<IEnumerable<ZoneCompactDto>>(true, Handling.RecordsFetchedSuccessfully, destObjects);
                }
                else
                {
                    throw new KeyNotFoundException(Handling.NoRecordsFound);
                }
            }
            catch (KeyNotFoundException e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetAllServiceAsync), e.Message);
                return new ServiceResult<IEnumerable<ZoneCompactDto>>(true, Handling.NoRecordsFound, null);
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetAllServiceAsync), e.Message);
                return new ServiceResult<IEnumerable<ZoneCompactDto>>(true, Handling.FailedToFetchRecords, null);
            }
        }

        public async Task<ServiceResult<ZoneDto>> GetByIdServiceAsync(int id)
        {
            try
            {
                var result = await _zoneRepository.GetByIdAsync(id);

                var destObject = _mapper.Map<ZoneDto>(result);

                if (destObject == null)
                {
                    throw new KeyNotFoundException(Handling.NoRecordFound);
                }
                else
                {
                    return new ServiceResult<ZoneDto>(true, Handling.RecordFetchedSuccessfully, destObject);
                }
            }
            catch (KeyNotFoundException e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetByIdServiceAsync), e.Message);
                return new ServiceResult<ZoneDto>(true, Handling.NoRecordFound, null);
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetByIdServiceAsync), e.Message);
                return new ServiceResult<ZoneDto>(true, Handling.FailedToFetchRecord, null);
            }
        }

        public async Task<ServiceResult<ZoneDto>> CreateServiceAsync(ZoneCreateDto createDto)
        {
            try
            {
                var obj = _mapper.Map<Zone>(createDto);

                var result = _mapper.Map<ZoneDto>(await _zoneRepository.CreateAsync(obj));

                if (result == null)
                {
                    throw new Exception(Handling.CreationFailed);
                }
                else
                {
                    return new ServiceResult<ZoneDto>(true, Handling.CreatedSuccessfully, result);
                }
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(CreateServiceAsync), e.Message);
                return new ServiceResult<ZoneDto>(true, Handling.CreationFailed, null);
            }
        }

        public async Task<ServiceResult<ZoneDto>> UpdateServiceAsync(ZoneEditDto editDto)
        {
            try
            {
                var found = await _zoneRepository.GetByIdAsync(editDto.Id);

                if (found == null)
                {
                    throw new KeyNotFoundException(Handling.NoRecordFound);
                }
                else
                {
                    var obj = _mapper.Map(editDto, found);

                    var result = await _zoneRepository.UpdateAsync(obj);

                    if (result == null)
                    {
                        throw new Exception(Handling.UpdationFailed);
                    }
                    else
                    {
                        return new ServiceResult<ZoneDto>(true, Handling.UpdatedSuccessfully, _mapper.Map<ZoneDto>(obj));
                    }
                }
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(UpdateServiceAsync), e.Message);
                return new ServiceResult<ZoneDto>(true, Handling.UpdationFailed, null);
            }
        }

        public async Task<ServiceResult<ZoneCompactDto>> DeleteServiceAsync(int id)
        {
            try
            {
                var found = await _zoneRepository.GetByIdAsync(id);

                if (found == null)
                {
                    throw new KeyNotFoundException(Handling.NoRecordFound);
                }
                else
                {
                    var result = await _zoneRepository.DeleteAsync(found);

                    if (result == null)
                    {
                        throw new Exception(Handling.DeletionFailed);
                    }
                    else
                    {
                        var resultDto = _mapper.Map<ZoneCompactDto>(result);
                        return new ServiceResult<ZoneCompactDto>(true, Handling.DeletedSuccessfully, resultDto);
                    }
                }
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(DeleteServiceAsync), e.Message);
                return new ServiceResult<ZoneCompactDto>(true, Handling.DeletionFailed, null);
            }
        }

        public async Task<ServiceResultPage<PagedList<ZoneCompactDto>>> GetAllPageServiceAsync(PageParameters pageParams)
        {
            try
            {
                var result = await _zoneRepository.GetAllAsync();
                var compactDto = _mapper.Map<IEnumerable<ZoneCompactDto>>(result);

                if (compactDto == null)
                {
                    throw new KeyNotFoundException(Handling.NoRecordsFound);
                }
                else
                {
                    var pageResult = PagedList<ZoneCompactDto>.ToPagedList(compactDto, pageParams.PageNumber, pageParams.PageSize);
                    var pageCounts = ServicePage<ZoneCompactDto>.WrapPageCounts(pageResult);

                    return new ServiceResultPage<PagedList<ZoneCompactDto>>(true, Handling.RecordsFetchedSuccessfully, pageCounts, pageResult);
                }
            }
            catch (KeyNotFoundException e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetAllPageServiceAsync), e.Message);
                return new ServiceResultPage<PagedList<ZoneCompactDto>>(true, Handling.NoRecordsFound, null);
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetAllPageServiceAsync), e.Message);
                return new ServiceResultPage<PagedList<ZoneCompactDto>>(true, Handling.FailedToFetchRecords, null);
            }
        }
    }
}