using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PackIT.Domain.Entities;
using PackIT.Domain.ValueObjects;

namespace PackIT.Infrastructure.EF.Config;

internal sealed class WriteConfiguration
    : IEntityTypeConfiguration<PackingList>,
    IEntityTypeConfiguration<PackingItem>
{
    public void Configure(EntityTypeBuilder<PackingList> builder)
    {
        builder.HasKey(x => x.Id);

        var localizationConverter = new ValueConverter<Localization, string>(x => x.ToString(),
            x => Localization.Create(x));

        var packingListNameConverter = new ValueConverter<PackingListName, string>(x => x.Value!,
            x => new PackingListName(x));

        builder
            .Property(x => x.Id)
            .HasConversion(i => i.Value, i => new PackingListId(i));

        builder
            .Property(typeof(Localization), "_localization")
            .HasConversion(localizationConverter)
            .HasColumnName("Localization");

        builder
            .Property(typeof(PackingListName), "_name")
            .HasConversion(packingListNameConverter)
            .HasColumnName("Name");

        builder.HasMany(typeof(PackingItem), "_items");

        builder.ToTable("packing_lists");
    }

    public void Configure(EntityTypeBuilder<PackingItem> builder)
    {
        builder.Property<Guid>("Id");
        builder.Property(i => i.Name);
        builder.Property(i => i.Qty);
        builder.Property(i => i.IsPacked);
        builder.ToTable("packing_items");
    }
}
