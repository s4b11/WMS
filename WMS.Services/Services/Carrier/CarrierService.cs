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
    public class CarrierService : ICarrierService
    {
        private readonly IMapper _mapper;
        private readonly ICarrierRepository _carrierRepository;
        private readonly ILoggerManager _logger;

        public CarrierService(IMapper mapper, ICarrierRepository carrierRepository, ILoggerManager logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _carrierRepository = carrierRepository ?? throw new ArgumentNullException(nameof(carrierRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ServiceResult<IEnumerable<CarrierCompactDto>>> GetAllServiceAsync()
        {
            try
            {
                var result = await _carrierRepository.GetAllAsync();

                var destObjects = _mapper.Map<List<CarrierCompactDto>>(result);

                if (destObjects?.Count > 0)
                {
                    return new ServiceResult<IEnumerable<CarrierCompactDto>>(true, Handling.RecordsFetchedSuccessfully, destObjects);
                }
                else
                {
                    throw new KeyNotFoundException(Handling.NoRecordsFound);
                }
            }
            catch (KeyNotFoundException e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetAllServiceAsync), e.Message);
                return new ServiceResult<IEnumerable<CarrierCompactDto>>(true, Handling.NoRecordsFound, null);
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetAllServiceAsync), e.Message);
                return new ServiceResult<IEnumerable<CarrierCompactDto>>(true, Handling.FailedToFetchRecords, null);
            }
        }

        public async Task<ServiceResult<CarrierDto>> GetByIdServiceAsync(int id)
        {
            try
            {
                var result = await _carrierRepository.GetByIdAsync(id);

                var destObject = _mapper.Map<CarrierDto>(result);

                if (destObject == null)
                {
                    throw new KeyNotFoundException(Handling.NoRecordFound);
                }
                else
                {
                    return new ServiceResult<CarrierDto>(true, Handling.RecordFetchedSuccessfully, destObject);
                }
            }
            catch (KeyNotFoundException e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetByIdServiceAsync), e.Message);
                return new ServiceResult<CarrierDto>(true, Handling.NoRecordFound, null);
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetByIdServiceAsync), e.Message);
                return new ServiceResult<CarrierDto>(true, Handling.FailedToFetchRecord, null);
            }
        }

        public async Task<ServiceResult<CarrierDto>> CreateServiceAsync(CarrierCreateDto createDto)
        {
            try
            {
                var obj = _mapper.Map<Carrier>(createDto);

                var result = _mapper.Map<CarrierDto>(await _carrierRepository.CreateAsync(obj));

                if (result == null)
                {
                    throw new Exception(Handling.CreationFailed);
                }
                else
                {
                    return new ServiceResult<CarrierDto>(true, Handling.CreatedSuccessfully, result);
                }
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(CreateServiceAsync), e.Message);
                return new ServiceResult<CarrierDto>(true, Handling.CreationFailed, null);
            }
        }

        public async Task<ServiceResult<CarrierDto>> UpdateServiceAsync(CarrierEditDto editDto)
        {
            try
            {
                var found = await _carrierRepository.GetByIdAsync(editDto.Id);

                if (found == null)
                {
                    throw new KeyNotFoundException(Handling.NoRecordFound);
                }
                else
                {
                    var obj = _mapper.Map(editDto, found);

                    var result = await _carrierRepository.UpdateAsync(obj);

                    if (result == null)
                    {
                        throw new Exception(Handling.UpdationFailed);
                    }
                    else
                    {
                        return new ServiceResult<CarrierDto>(true, Handling.UpdatedSuccessfully, _mapper.Map<CarrierDto>(obj));
                    }
                }
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(UpdateServiceAsync), e.Message);
                return new ServiceResult<CarrierDto>(true, Handling.UpdationFailed, null);
            }
        }

        public async Task<ServiceResult<CarrierCompactDto>> DeleteServiceAsync(int id)
        {
            try
            {
                var found = await _carrierRepository.GetByIdAsync(id);

                if (found == null)
                {
                    throw new KeyNotFoundException(Handling.NoRecordFound);
                }
                else
                {
                    var result = await _carrierRepository.DeleteAsync(found);

                    if (result == null)
                    {
                        throw new Exception(Handling.DeletionFailed);
                    }
                    else
                    {
                        var resultDto = _mapper.Map<CarrierCompactDto>(result);
                        return new ServiceResult<CarrierCompactDto>(true, Handling.DeletedSuccessfully, resultDto);
                    }
                }
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(DeleteServiceAsync), e.Message);
                return new ServiceResult<CarrierCompactDto>(true, Handling.DeletionFailed, null);
            }
        }

        public async Task<ServiceResultPage<PagedList<CarrierCompactDto>>> GetAllPageServiceAsync(PageParameters pageParams)
        {
            try
            {
                var result = await _carrierRepository.GetAllAsync();
                var compactDto = _mapper.Map<IEnumerable<CarrierCompactDto>>(result);

                if (compactDto == null)
                {
                    throw new KeyNotFoundException(Handling.NoRecordsFound);
                }
                else
                {
                    var pageResult = PagedList<CarrierCompactDto>.ToPagedList(compactDto, pageParams.PageNumber, pageParams.PageSize);
                    var pageCounts = ServicePage<CarrierCompactDto>.WrapPageCounts(pageResult);

                    return new ServiceResultPage<PagedList<CarrierCompactDto>>(true, Handling.RecordsFetchedSuccessfully, pageCounts, pageResult);
                }
            }
            catch (KeyNotFoundException e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetAllPageServiceAsync), e.Message);
                return new ServiceResultPage<PagedList<CarrierCompactDto>>(true, Handling.NoRecordsFound, null);
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetAllPageServiceAsync), e.Message);
                return new ServiceResultPage<PagedList<CarrierCompactDto>>(true, Handling.FailedToFetchRecords, null);
            }
        }
    }
}