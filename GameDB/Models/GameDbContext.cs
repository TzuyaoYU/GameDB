using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GameDB.Models;

public partial class GameDbContext : DbContext
{
    public GameDbContext()
    {
    }

    public GameDbContext(DbContextOptions<GameDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemAttribute> ItemAttributes { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<PlayerEquipment> PlayerEquipments { get; set; }

    public virtual DbSet<PlayerItem> PlayerItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-TTEP6T6\\SQLEXPRESS;Initial Catalog=GameDB;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Items__727E83EBB165F437");

            entity.HasIndex(e => e.ItemName, "UQ__Items__4E4373F718235BA2").IsUnique();

            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.ItemName).HasMaxLength(100);
            entity.Property(e => e.ItemType).HasMaxLength(20);
            entity.Property(e => e.Rarity).HasMaxLength(10);
        });

        modelBuilder.Entity<ItemAttribute>(entity =>
        {
            entity.HasKey(e => e.ItemAttributeId).HasName("PK__ItemAttr__D46890B4F42D5789");

            entity.Property(e => e.ItemAttributeId).HasColumnName("ItemAttributeID");
            entity.Property(e => e.AttributeName).HasMaxLength(50);
            entity.Property(e => e.AttributeValue).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemAttributes)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK_ItemAttributes_Items");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.PlayerId).HasName("PK__Players__4A4E74A88C246FA9");

            entity.HasIndex(e => e.Username, "UQ__Players__536C85E4615F4D1B").IsUnique();

            entity.Property(e => e.PlayerId).HasColumnName("PlayerID");
            entity.Property(e => e.JoinDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Level).HasDefaultValue(1);
            entity.Property(e => e.Nickname).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<PlayerEquipment>(entity =>
        {
            entity.HasKey(e => e.PlayerEquipmentId).HasName("PK__PlayerEq__2D115E63547035F3");

            entity.ToTable("PlayerEquipment");

            entity.HasIndex(e => new { e.PlayerId, e.EquipmentSlot }, "UQ_PlayerEquipment_PlayerID_Slot").IsUnique();

            entity.Property(e => e.PlayerEquipmentId).HasColumnName("PlayerEquipmentID");
            entity.Property(e => e.EquipmentSlot).HasMaxLength(20);
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.PlayerId).HasColumnName("PlayerID");

            entity.HasOne(d => d.Item).WithMany(p => p.PlayerEquipments)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlayerEquipment_Items");

            entity.HasOne(d => d.Player).WithMany(p => p.PlayerEquipments)
                .HasForeignKey(d => d.PlayerId)
                .HasConstraintName("FK_PlayerEquipment_Players");
        });

        modelBuilder.Entity<PlayerItem>(entity =>
        {
            entity.HasKey(e => e.PlayerItemId).HasName("PK__PlayerIt__5651B305241138B2");

            entity.HasIndex(e => new { e.PlayerId, e.ItemId }, "UQ_PlayerItems_PlayerID_ItemID").IsUnique();

            entity.Property(e => e.PlayerItemId).HasColumnName("PlayerItemID");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.PlayerId).HasColumnName("PlayerID");
            entity.Property(e => e.Quantity).HasDefaultValue(1);

            entity.HasOne(d => d.Item).WithMany(p => p.PlayerItems)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK_PlayerItems_Items");

            entity.HasOne(d => d.Player).WithMany(p => p.PlayerItems)
                .HasForeignKey(d => d.PlayerId)
                .HasConstraintName("FK_PlayerItems_Players");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
