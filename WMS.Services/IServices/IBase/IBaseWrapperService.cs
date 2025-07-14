namespace WMS.Services.IServices
{
    public interface IBaseWrapperService
    {
        ICountryService Country { get; }

        ICompanyService Company { get; }

        IVendorService Vendor { get; }

        ICustomerService Customer { get; }

        ICarrierService Carrier { get; }

        ICurrencyService Currency { get; }

        IUomService Uom { get; }

        IZoneService Zone { get; }
    }
}