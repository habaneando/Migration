namespace Migration.Common;

public class PaginationException : ApplicationException
{
    public PaginationException(
        int pageNumber,
        int pageSize,
        int totalItems)
        : base($"Invalid pagination for pageNumber:{pageNumber}, pageSize:{pageSize} and totalItems:{totalItems}")
    {
    }
}
