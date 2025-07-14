namespace WMS.Utilities
{
    public class PageResult
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
        public string PreviousPage { get; set; }
        public string NextPage { get; set; }
    }
}