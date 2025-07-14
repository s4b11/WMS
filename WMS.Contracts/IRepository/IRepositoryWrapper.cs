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