namespace PackIT.Application.Services;

public interface IPackingListService
{
    Task<bool> ExistsByNameAsync(string name);
}
