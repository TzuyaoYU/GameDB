using System;
using System.Collections.Generic;

namespace GameDB.Models;

public partial class PlayerItem
{
    public int PlayerItemId { get; set; }

    public int PlayerId { get; set; }

    public int ItemId { get; set; }

    public int Quantity { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual Player Player { get; set; } = null!;
}
