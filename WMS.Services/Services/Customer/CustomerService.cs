using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WMS.Contracts;
using WMS.Contracts.ICustomer;
using WMS.Contracts.ILogger;
using WMS.Dtos;
using WMS.LoggerService;
using WMS.Models;
using WMS.Models.Models.CustomerModel;
using WMS.Services.IServices;
using WMS.Utilities;

namespace WMS.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly ILoggerManager _logger;

        public CustomerService(IMapper mapper, ICustomerRepository CustomerRepository, ILoggerManager logger)
        {
            _mapper = mapper;
            _customerRepository = CustomerRepository;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ServiceResult<IEnumerable<CustomerCompactDto>>> GetAllServiceAsync()
        {
            try
            {
                var result = await _customerRepository.GetAllAsync();

                var destObjects = _mapper.Map<List<CustomerCompactDto>>(result);

                if (destObjects?.Count > 0)
                {
                    return new ServiceResult<IEnumerable<CustomerCompactDto>>(true, Handling.RecordsFetchedSuccessfully, destObjects);
                }
                else
                {
                    throw new KeyNotFoundException(Handling.NoRecordsFound);
                }
            }
            catch (KeyNotFoundException e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetAllServiceAsync), e.Message);
                return new ServiceResult<IEnumerable<CustomerCompactDto>>(true, Handling.NoRecordsFound, null);
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetAllServiceAsync), e.Message);
                return new ServiceResult<IEnumerable<CustomerCompactDto>>(true, Handling.FailedToFetchRecords, null);
            }
        }

        public async Task<ServiceResult<CustomerDto>> GetByIdServiceAsync(int id)
        {
            try
            {
                var result = await _customerRepository.GetByIdAsync(id);

                var destObject = _mapper.Map<CustomerDto>(result);

                if (destObject == null)
                {
                    throw new KeyNotFoundException(Handling.NoRecordFound);
                }
                else
                {
                    return new ServiceResult<CustomerDto>(true, Handling.RecordFetchedSuccessfully, destObject);
                }
            }
            catch (KeyNotFoundException e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetByIdServiceAsync), e.Message);
                return new ServiceResult<CustomerDto>(true, Handling.NoRecordFound, null);
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetByIdServiceAsync), e.Message);
                return new ServiceResult<CustomerDto>(true, Handling.FailedToFetchRecord, null);
            }
        }

        public async Task<ServiceResult<CustomerDto>> CreateServiceAsync(CustomerCreateDto createDto)
        {
            try
            {
                var obj = _mapper.Map<Customer>(createDto);

                var result = _mapper.Map<CustomerDto>(await _customerRepository.CreateAsync(obj));

                if (result == null)
                {
                    throw new Exception(Handling.CreationFailed);
                }
                else
                {
                    return new ServiceResult<CustomerDto>(true, Handling.CreatedSuccessfully, result);
                }
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(CreateServiceAsync), e.Message);
                return new ServiceResult<CustomerDto>(true, Handling.CreationFailed, null);
            }
        }

        public async Task<ServiceResult<CustomerDto>> UpdateServiceAsync(CustomerEditDto editDto)
        {
            try
            {
                var found = await _customerRepository.GetByIdAsync(editDto.Id);

                if (found == null)
                {
                    throw new KeyNotFoundException(Handling.NoRecordFound);
                }
                else
                {
                    var obj = _mapper.Map(editDto, found);

                    var result = await _customerRepository.UpdateAsync(obj);

                    if (result == null)
                    {
                        throw new Exception(Handling.UpdationFailed);
                    }
                    else
                    {
                        return new ServiceResult<CustomerDto>(true, Handling.UpdatedSuccessfully, _mapper.Map<CustomerDto>(obj));
                    }
                }
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(UpdateServiceAsync), e.Message);
                return new ServiceResult<CustomerDto>(true, Handling.UpdationFailed, null);
            }
        }

        public async Task<ServiceResult<CustomerCompactDto>> DeleteServiceAsync(int id)
        {
            try
            {
                var found = await _customerRepository.GetByIdAsync(id);

                if (found == null)
                {
                    throw new KeyNotFoundException(Handling.NoRecordFound);
                }
                else
                {
                    var result = await _customerRepository.DeleteAsync(found);

                    if (result == null)
                    {
                        throw new Exception(Handling.DeletionFailed);
                    }
                    else
                    {
                        var resultDto = _mapper.Map<CustomerCompactDto>(result);
                        return new ServiceResult<CustomerCompactDto>(true, Handling.DeletedSuccessfully, resultDto);
                    }
                }
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(DeleteServiceAsync), e.Message);
                return new ServiceResult<CustomerCompactDto>(true, Handling.DeletionFailed, null);
            }
        }

        public async Task<ServiceResultPage<PagedList<CustomerCompactDto>>> GetAllPageServiceAsync(PageParameters pageParams)
        {
            try
            {
                var result = await _customerRepository.GetAllAsync();
                var compactDto = _mapper.Map<IEnumerable<CustomerCompactDto>>(result);

                if (compactDto == null)
                {
                    throw new KeyNotFoundException(Handling.NoRecordsFound);
                }
                else
                {
                    var pageResult = PagedList<CustomerCompactDto>.ToPagedList(compactDto, pageParams.PageNumber, pageParams.PageSize);
                    var pageCounts = ServicePage<CustomerCompactDto>.WrapPageCounts(pageResult);

                    return new ServiceResultPage<PagedList<CustomerCompactDto>>(true, Handling.RecordsFetchedSuccessfully, pageCounts, pageResult);
                }
            }
            catch (KeyNotFoundException e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetAllPageServiceAsync), e.Message);
                return new ServiceResultPage<PagedList<CustomerCompactDto>>(true, Handling.NoRecordsFound, null);
            }
            catch (Exception e)
            {
                await _logger.LogErrorAsync(nameof(CarrierService), nameof(GetAllPageServiceAsync), e.Message);
                return new ServiceResultPage<PagedList<CustomerCompactDto>>(true, Handling.FailedToFetchRecords, null);
            }
        }
    }
}