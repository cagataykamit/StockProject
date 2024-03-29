using Core.Entities;
using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class Category : IEntity
{
    public int CategoryId { get; set; }

    public string? Title { get; set; }

    public int? MinimumQuantity { get; set; }

    public bool Deleted { get; set; }
}