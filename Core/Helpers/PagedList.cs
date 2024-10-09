namespace Core.Helpers;

public class PagedList<T>(List<T> items, int pageIndex, int totalPages)
{
    public List<T> Items { get; } = items;
    private int PageIndex { get;} = pageIndex;
    private int TotalPages { get;} = totalPages;
    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageIndex < TotalPages;
}