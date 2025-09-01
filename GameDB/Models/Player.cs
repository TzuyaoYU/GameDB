using System;
using System.Collections.Generic;

namespace GameDB.Models;

public partial class Player
{
    public int PlayerId { get; set; }

    public string Username { get; set; } = null!;

    public string? Nickname { get; set; }

    public int Level { get; set; }

    public DateTime JoinDate { get; set; }

    public virtual ICollection<PlayerEquipment> PlayerEquipments { get; set; } = new List<PlayerEquipment>();

    public virtual ICollection<PlayerItem> PlayerItems { get; set; } = new List<PlayerItem>();
}
