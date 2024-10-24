public record BaseFilter
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public BaseFilter()
    {
        PageNumber = 1;
        PageSize = 10;
    }

    public BaseFilter(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}