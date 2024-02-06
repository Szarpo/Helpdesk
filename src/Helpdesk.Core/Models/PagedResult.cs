namespace Helpdesk.Core.Models;

public class PagedResult<T>
{
    public List<T> Items { get; set; }
    public int TotalPages { get; set; }
    public int ItemsFrom { get; set; }
    public int ItemsTo { get; set; }
    public int TotalItemsCount { get; set; }

    public PagedResult(List<T> items,int totalPages, int pageSize, int pageNumber)
    {
        Items = items;
        TotalPages = totalPages;
        ItemsFrom = pageSize * (pageNumber - 1) + 1;
        ItemsTo = ItemsFrom * pageSize -1;
        TotalItemsCount = (int)Math.Ceiling(TotalPages / (double)pageSize);
    }
}