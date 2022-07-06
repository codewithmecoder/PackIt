using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PackIT.Infrastructure.EF.Models;

namespace PackIT.Infrastructure.EF.Config;

internal sealed class ReadConfiguration
    : IEntityTypeConfiguration<PackingListReadModel>,
    IEntityTypeConfiguration<PackingItemReadModel>
{
    public void Configure(EntityTypeBuilder<PackingListReadModel> builder)
    {
        builder.ToTable("packing_lists");
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Localization)
            .HasConversion(x => x!.ToString(), x => LocalizationReadModel.Create(x!));

        builder
            .HasMany(x => x.Items)
            .WithOne(x => x.PackingList);
    }

    public void Configure(EntityTypeBuilder<PackingItemReadModel> builder)
    {
        builder.ToTable("packing_items");
    }
}
