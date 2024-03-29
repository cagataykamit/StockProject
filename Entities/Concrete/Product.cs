using Core.Entities;
using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class Product : IEntity
{
    public int ProductId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int? Quantity { get; set; }

    public int? CategoryId { get; set; }

    public bool Deleted { get; set; }
}