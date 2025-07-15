using AutoMapper;
using WMS.Contracts;
using WMS.Services.IServices;

namespace WMS.Services
{
    public class BaseWrapperService : IBaseWrapperService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repository;
        private readonly ILoggerManager _logger;

        //Initialize repositories from the wrapper in constructor
        private readonly ICountryRepository _countryRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IVendorRepository _vendorRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICarrierRepository _carrierRepository;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IUomRepository _uomRepository;
        private readonly IZoneRepository _zoneRepository;

        private ICountryService _countryService;
        private ICompanyService _companyService;
        private IVendorService _vendorService;
        private ICustomerService _customerService;
        private ICarrierService _carrierService;
        private ICurrencyService _currencyService;
        private IUomService _uomService;
        private IZoneService _zoneService;

        public BaseWrapperService(IMapper mapper, IRepositoryWrapper repositoryWrapper, ILoggerManager logger)
        {
            _mapper = mapper;
            _repository = repositoryWrapper;
            _logger = logger;
        }

        //Country
        public ICountryService Country
        {
            get
            {
                if (_countryService == null)
                {
                    _countryService = new CountryService(_mapper, _countryRepository, _logger);
                }
                return _countryService;
            }
        }

        //Company
        public ICompanyService Company
        {
            get
            {
                if (_companyService == null)
                {
                    _companyService = new CompanyService(_mapper, _companyRepository, _logger);
                }
                return _companyService;
            }
        }

        //Vendor
        public IVendorService Vendor
        {
            get
            {
                if (_vendorService == null)
                {
                    _vendorService = new VendorService(_mapper, _vendorRepository, _logger);
                }
                return _vendorService;
            }
        }

        //Customer
        public ICustomerService Customer
        {
            get
            {
                if (_customerService == null)
                {
                    _customerService = new CustomerService(_mapper, _customerRepository, _logger);
                }
                return _customerService;
            }
        }

        //Carrier
        public ICarrierService Carrier
        {
            get
            {
                if (_carrierService == null)
                {
                    _carrierService = new CarrierService(_mapper, _carrierRepository, _logger);
                }
                return _carrierService;
            }
        }

        //Currency
        public ICurrencyService Currency
        {
            get
            {
                if (_currencyService == null)
                {
                    _currencyService = new CurrencyService(_mapper, _currencyRepository, _logger);
                }
                return _currencyService;
            }
        }

        //Uom
        public IUomService Uom
        {
            get
            {
                if (_uomService == null)
                {
                    _uomService = new UomService(_mapper, _uomRepository, _logger);
                }
                return _uomService;
            }
        }

        //Zone
        public IZoneService Zone
        {
            get
            {
                if (_zoneService == null)
                {
                    _zoneService = new ZoneService(_mapper, _zoneRepository, _logger);
                }
                return _zoneService;
            }
        }
    }
}