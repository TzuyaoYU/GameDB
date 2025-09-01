using System;
using System.Collections.Generic;

namespace GameDB.Models;

public partial class PlayerEquipment
{
    public int PlayerEquipmentId { get; set; }

    public int PlayerId { get; set; }

    public int ItemId { get; set; }

    public string EquipmentSlot { get; set; } = null!;

    public virtual Item Item { get; set; } = null!;

    public virtual Player Player { get; set; } = null!;
}
