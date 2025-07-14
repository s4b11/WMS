using WMS.Contracts.ICarrier;
using WMS.Contracts.ICompany;
using WMS.Contracts.ICountry;
using WMS.Contracts.ICurrency;
using WMS.Contracts.ICustomer;
using WMS.Contracts.IUom;
using WMS.Contracts.IVendor;
using WMS.Contracts.IZone;

namespace WMS.Contracts
{
    public interface IRepositoryWrapper
    {
        ICountryRepository Country { get; }

        ICompanyRepository Company { get; }

        IVendorRepository Vendor { get; }

        ICustomerRepository Customer { get; }

        ICarrierRepository Carrier { get; }

        ICurrencyRepository Currency { get; }

        IUomRepository Uom { get; }

        IZoneRepository Zone { get; }
    }
}