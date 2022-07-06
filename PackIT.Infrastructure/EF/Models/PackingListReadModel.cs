﻿using PackIT.Application.DTO;
using PackIT.Domain.ValueObjects;

namespace PackIT.Infrastructure.EF.Models;

internal class PackingListReadModel
{
    public Guid Id { get; set; }
    public int Veresion { get; set; }
    public string? Name { get; set; }
    public LocalizationReadModel? Localization { get; set; }
    public ICollection<PackingItemReadModel>? Items { get; set; }
}