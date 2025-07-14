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
    public class CurrencyService : ICurrencyService
    {
        private readonly IMapper _mapper;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly ILoggerManager _logger;

        public CurrencyService(IMapper mapper, ICurrencyRepository CurrencyRepository, ILoggerManager logger)
        {
            _mapper = mapper;
            _currencyRepository = CurrencyRepository;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ServiceResult<IEnumerable<CurrencyCompactDto>>> GetAllServiceAsync()
        {
            try
            {
                var result = await _currencyRepository.GetAllAsync();

                var destObjects = _mapper.Map<List<CurrencyCompactDto>>(result);

                if (destObjects?.Count > 0)
                {
                    return new ServiceResult<IEnumerable<CurrencyCompactDto>>(true, Handling.RecordsFetchedSuccessfully, destObjects);
                }
                else
                {
                    throw new KeyNotFoundException(Handling.NoRecordsFound);
                }
            }
            catch (KeyNotFoundException e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetAllServiceAsync), e.Message);
                return new ServiceResult<IEnumerable<CurrencyCompactDto>>(true, Handling.NoRecordsFound, null);
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetAllServiceAsync), e.Message);
                return new ServiceResult<IEnumerable<CurrencyCompactDto>>(true, Handling.FailedToFetchRecords, null);
            }
        }

        public async Task<ServiceResult<CurrencyDto>> GetByIdServiceAsync(int id)
        {
            try
            {
                var result = await _currencyRepository.GetByIdAsync(id);

                var destObject = _mapper.Map<CurrencyDto>(result);

                if (destObject == null)
                {
                    throw new KeyNotFoundException(Handling.NoRecordFound);
                }
                else
                {
                    return new ServiceResult<CurrencyDto>(true, Handling.RecordFetchedSuccessfully, destObject);
                }
            }
            catch (KeyNotFoundException e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetByIdServiceAsync), e.Message);
                return new ServiceResult<CurrencyDto>(true, Handling.NoRecordFound, null);
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetByIdServiceAsync), e.Message);
                return new ServiceResult<CurrencyDto>(true, Handling.FailedToFetchRecord, null);
            }
        }

        public async Task<ServiceResult<CurrencyDto>> CreateServiceAsync(CurrencyCreateDto createDto)
        {
            try
            {
                var obj = _mapper.Map<Currency>(createDto);

                var result = _mapper.Map<CurrencyDto>(await _currencyRepository.CreateAsync(obj));

                if (result == null)
                {
                    throw new Exception(Handling.CreationFailed);
                }
                else
                {
                    return new ServiceResult<CurrencyDto>(true, Handling.CreatedSuccessfully, result);
                }
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(CreateServiceAsync), e.Message);
                return new ServiceResult<CurrencyDto>(true, Handling.CreationFailed, null);
            }
        }

        public async Task<ServiceResult<CurrencyDto>> UpdateServiceAsync(CurrencyEditDto editDto)
        {
            try
            {
                var found = await _currencyRepository.GetByIdAsync(editDto.Id);

                if (found == null)
                {
                    throw new KeyNotFoundException(Handling.NoRecordFound);
                }
                else
                {
                    var obj = _mapper.Map(editDto, found);

                    var result = await _currencyRepository.UpdateAsync(obj);

                    if (result == null)
                    {
                        throw new Exception(Handling.UpdationFailed);
                    }
                    else
                    {
                        return new ServiceResult<CurrencyDto>(true, Handling.UpdatedSuccessfully, _mapper.Map<CurrencyDto>(obj));
                    }
                }
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(UpdateServiceAsync), e.Message);
                return new ServiceResult<CurrencyDto>(true, Handling.UpdationFailed, null);
            }
        }

        public async Task<ServiceResult<CurrencyCompactDto>> DeleteServiceAsync(int id)
        {
            return new ServiceResult<CurrencyCompactDto>(true, Handling.DeletionFailed, null);
        }

        public async Task<ServiceResultPage<PagedList<CurrencyCompactDto>>> GetAllPageServiceAsync(PageParameters pageParams)
        {
            try
            {
                var result = await _currencyRepository.GetAllAsync();
                var compactDto = _mapper.Map<IEnumerable<CurrencyCompactDto>>(result);

                if (compactDto == null)
                {
                    throw new KeyNotFoundException(Handling.NoRecordsFound);
                }
                else
                {
                    var pageResult = PagedList<CurrencyCompactDto>.ToPagedList(compactDto, pageParams.PageNumber, pageParams.PageSize);
                    var pageCounts = ServicePage<CurrencyCompactDto>.WrapPageCounts(pageResult);

                    return new ServiceResultPage<PagedList<CurrencyCompactDto>>(true, Handling.RecordsFetchedSuccessfully, pageCounts, pageResult);
                }
            }
            catch (KeyNotFoundException e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetAllPageServiceAsync), e.Message);
                return new ServiceResultPage<PagedList<CurrencyCompactDto>>(true, Handling.NoRecordsFound, null);
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetAllPageServiceAsync), e.Message);
                return new ServiceResultPage<PagedList<CurrencyCompactDto>>(true, Handling.FailedToFetchRecords, null);
            }
        }
    }
}