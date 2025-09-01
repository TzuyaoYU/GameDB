using System;
using System.Collections.Generic;

namespace GameDB.Models;

public partial class ItemAttribute
{
    public int ItemAttributeId { get; set; }

    public int ItemId { get; set; }

    public string AttributeName { get; set; } = null!;

    public decimal AttributeValue { get; set; }

    public virtual Item Item { get; set; } = null!;
}
