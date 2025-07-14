using WMS.Utilities;

namespace WMS.Utilities
{
    public static class ServicePage<T>
    {
        public static PageResult WrapPageCounts(PagedList<T> ts)
        {
            PageResult pr = new PageResult();
            pr.TotalCount = ts.TotalCount;
            pr.CurrentPage = ts.CurrentPage;
            pr.PageSize = ts.PageSize;
            pr.TotalPages = ts.TotalPages;
            pr.HasNext = ts.HasNext;
            pr.HasPrevious = ts.HasPrevious;
            pr.PreviousPage = ts.PreviousPage;
            pr.NextPage = ts.NextPage;

            return pr;
        }
    }
}