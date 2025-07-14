using WMS.Contracts;
using WMS.Contracts.ICarrier;
using WMS.Contracts.ICompany;
using WMS.Contracts.ICountry;
using WMS.Contracts.ICurrency;
using WMS.Contracts.ICustomer;
using WMS.Contracts.IUom;
using WMS.Contracts.IVendor;
using WMS.Contracts.IZone;
using WMS.DataLayer;


namespace WMS.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private WMSDbContext _repoContext;
        private ICountryRepository _country;
        private ICompanyRepository _company;
        private IVendorRepository _vendor;
        private ICustomerRepository _customer;
        private ICarrierRepository _carrier;
        private ICurrencyRepository _currency;
        private IUomRepository _uom;
        private IZoneRepository _zone;

        public RepositoryWrapper(WMSDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        //Country
        public ICountryRepository Country
        {
            get
            {
                if (_country == null)
                {
                    _country = new CountryRepository(_repoContext);
                }
                return _country;
            }
        }

        //Company
        public ICompanyRepository Company
        {
            get
            {
                if (_company == null)
                {
                    _company = new CompanyRepository(_repoContext);
                }
                return _company;
            }
        }

        //Vendor
        public IVendorRepository Vendor
        {
            get
            {
                if (_vendor == null)
                {
                    _vendor = new VendorRepository(_repoContext);
                }
                return _vendor;
            }
        }

        //Customer
        public ICustomerRepository Customer
        {
            get
            {
                if (_customer == null)
                {
                    _customer = new CustomerRepository(_repoContext);
                }
                return _customer;
            }
        }

        //Carrier
        public ICarrierRepository Carrier
        {
            get
            {
                if (_carrier == null)
                {
                    _carrier = new CarrierRepository(_repoContext);
                }
                return _carrier;
            }
        }

        //Currency
        public ICurrencyRepository Currency
        {
            get
            {
                if (_currency == null)
                {
                    _currency = new CurrencyRepository(_repoContext);
                }
                return _currency;
            }
        }

        //Uom
        public IUomRepository Uom
        {
            get
            {
                if (_uom == null)
                {
                    _uom = new UomRepository(_repoContext);
                }
                return _uom;
            }

        }

        //Zone
        public IZoneRepository Zone
        {
            get
            {
                if (_zone == null)
                {
                    _zone = new ZoneRepository(_repoContext);
                }
                return _zone;
            }

        }
    }
}
