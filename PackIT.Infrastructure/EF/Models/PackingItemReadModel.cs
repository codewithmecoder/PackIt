namespace PackIT.Infrastructure.EF.Models;

internal class PackingItemReadModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public uint Qty { get; set; }
    public bool IsPacked { get; set; }

    public PackingListReadModel PackingList { get; set; } = new PackingListReadModel();
}
