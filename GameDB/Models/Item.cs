using System;
using System.Collections.Generic;

namespace GameDB.Models;

public partial class Item
{
    public int ItemId { get; set; }

    public string ItemName { get; set; } = null!;

    public string ItemType { get; set; } = null!;

    public string Rarity { get; set; } = null!;

    public virtual ICollection<ItemAttribute> ItemAttributes { get; set; } = new List<ItemAttribute>();

    public virtual ICollection<PlayerEquipment> PlayerEquipments { get; set; } = new List<PlayerEquipment>();

    public virtual ICollection<PlayerItem> PlayerItems { get; set; } = new List<PlayerItem>();
}
