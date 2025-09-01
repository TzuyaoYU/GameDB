using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameDB.Models;
using Microsoft.EntityFrameworkCore;

namespace GameDB
{
    public partial class PlayerDetailForm : Form
    {
        private readonly int _currentPlayerId;

        public PlayerDetailForm(int playerID)
        {
            InitializeComponent();
            _currentPlayerId = playerID;
        }

        private void PlayerDetailForm_Load(object sender, EventArgs e)
        {
            LoadAllData();
        }
        private void LoadAllData()
        {
            using (var context = new GameDbContext())
            {
                // 1. 載入玩家基本資料
                var player = context.Players.Find(_currentPlayerId);
                if (player == null)
                {
                    MessageBox.Show("找不到玩家資料！");
                    this.Close();
                    return;
                }
                lblPlayerInfo.Text = $"玩家 [{player.Nickname ?? player.Username}] (ID: {player.PlayerId}) 的背包與裝備";

                // 2. 載入背包資料 (PlayerItems)
                var inventory = context.PlayerItems
                    .Where(pi => pi.PlayerId == _currentPlayerId)
                    .Include(pi => pi.Item) // 順便載入關聯的 Item 資料
                    .Select(pi => new
                    {
                        pi.PlayerItemId,
                        pi.ItemId,
                        pi.Item.ItemName,
                        pi.Quantity,
                        pi.Item.ItemType
                    }).ToList();
                dgvInventory.DataSource = inventory;
                // 隱藏不需給使用者看的 ID 欄位
                dgvInventory.Columns["PlayerItemId"].Visible = false;
                dgvInventory.Columns["ItemId"].Visible = false;


                // 3. 載入裝備資料 (PlayerEquipment)
                var equipment = context.PlayerEquipments
                    .Where(pe => pe.PlayerId == _currentPlayerId)
                    .Include(pe => pe.Item)
                    .Select(pe => new
                    {
                        pe.ItemId,
                        pe.EquipmentSlot,
                        pe.Item.ItemName,
                        pe.Item.Rarity
                    }).ToList();
                dgvEquipment.DataSource = equipment;
                dgvEquipment.Columns["ItemId"].Visible = false;
            }
        }

        private void btnEquip_Click(object sender, EventArgs e)
        {
            if (dgvInventory.CurrentRow == null) return;

            int playerItemId = (int)dgvInventory.CurrentRow.Cells["PlayerItemId"].Value;
            string itemType = dgvInventory.CurrentRow.Cells["ItemType"].Value.ToString();

            // 只有武器和防具可以裝備
            if (itemType != "武器" && itemType != "防具")
            {
                MessageBox.Show("只有武器和防具可以被裝備！");
                return;
            }

            using (var context = new GameDbContext())
            using (var transaction = context.Database.BeginTransaction()) // <-- 開始交易
            {
                try
                {
                    var playerItem = context.PlayerItems.Find(playerItemId);
                    if (playerItem == null || playerItem.Quantity <= 0) return;

                    // 決定裝備槽位 (簡易版邏輯)
                    string slot = (itemType == "武器") ? "武器" : "身體"; // 簡化邏輯，防具都裝到身體

                    // 檢查該槽位是否已有裝備，若有則先卸下
                    var currentEquipment = context.PlayerEquipments
                        .FirstOrDefault(pe => pe.PlayerId == _currentPlayerId && pe.EquipmentSlot == slot);
                    if (currentEquipment != null)
                    {
                        // (進階) 這裡可以呼叫卸下的邏輯，我們先簡化處理
                        MessageBox.Show($"請先卸下 [{slot}] 位置的裝備！");
                        return;
                    }

                    // 更新背包數量
                    playerItem.Quantity--;
                    if (playerItem.Quantity == 0)
                    {
                        context.PlayerItems.Remove(playerItem);
                    }

                    // 新增到裝備表
                    var newEquipment = new PlayerEquipment
                    {
                        PlayerId = _currentPlayerId,
                        ItemId = playerItem.ItemId,
                        EquipmentSlot = slot
                    };
                    context.PlayerEquipments.Add(newEquipment);

                    context.SaveChanges(); // 儲存所有變動
                    transaction.Commit(); // <-- 提交交易
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // <-- 如果發生任何錯誤，復原所有操作
                    MessageBox.Show("裝備失敗: " + ex.Message);
                }
            }
            LoadAllData(); // 重新整理畫面
        }

        private void btnUnequip_Click(object sender, EventArgs e)
        {
            if (dgvEquipment.CurrentRow == null) return;

            int itemId = (int)dgvEquipment.CurrentRow.Cells["ItemId"].Value;
            string slot = dgvEquipment.CurrentRow.Cells["EquipmentSlot"].Value.ToString();

            using (var context = new GameDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    // 從裝備表移除
                    var equipmentToRemove = context.PlayerEquipments
                        .First(pe => pe.PlayerId == _currentPlayerId && pe.EquipmentSlot == slot);
                    context.PlayerEquipments.Remove(equipmentToRemove);

                    // 加回背包
                    var itemInInventory = context.PlayerItems
                        .FirstOrDefault(pi => pi.PlayerId == _currentPlayerId && pi.ItemId == itemId);

                    if (itemInInventory != null)
                    {
                        itemInInventory.Quantity++;
                    }
                    else
                    {
                        var newItemInInventory = new PlayerItem
                        {
                            PlayerId = _currentPlayerId,
                            ItemId = itemId,
                            Quantity = 1
                        };
                        context.PlayerItems.Add(newItemInInventory);
                    }

                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("卸下失敗: " + ex.Message);
                }
            }
            LoadAllData(); // 重新整理畫面
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            // 使用 using 確保 selectForm 物件在使用完畢後會被正確釋放
            using (var selectForm = new SelectItemForm())
            {
                // 使用 .ShowDialog() 來彈出視窗，程式會在這裡暫停直到視窗關閉
                if (selectForm.ShowDialog() == DialogResult.OK)
                {
                    // 如果使用者是按下了「確定」按鈕，我們就從公開屬性讀取選擇的結果
                    int itemId = selectForm.SelectedItemId;
                    int quantity = selectForm.SelectedQuantity;

                    // 執行新增到背包的資料庫邏輯
                    using (var context = new GameDbContext())
                    {
                        // 檢查玩家背包裡是否已經有此道具
                        var itemInInventory = context.PlayerItems.FirstOrDefault(pi => pi.PlayerId == _currentPlayerId && pi.ItemId == itemId);

                        if (itemInInventory != null)
                        {
                            // 如果有，就直接增加數量
                            itemInInventory.Quantity += quantity;
                        }
                        else
                        {
                            // 如果沒有，就新增一筆新的 PlayerItem 紀錄
                            var newItem = new PlayerItem { PlayerId = _currentPlayerId, ItemId = itemId, Quantity = quantity };
                            context.PlayerItems.Add(newItem);
                        }
                        context.SaveChanges(); // 儲存變更到資料庫
                    }
                    // 重新整理主畫面的資料
                    LoadAllData();
                    MessageBox.Show("道具已成功給予！");
                }
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            // 檢查是否有選中背包中的道具
            if (dgvInventory.CurrentRow == null)
            {
                MessageBox.Show("請先從背包列表中選擇要移除的道具。");
                return;
            }

            // 彈出確認對話框，防止誤刪
            if (MessageBox.Show("您確定要從背包移除此道具嗎？", "確認移除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // 從選中列取得要刪除的 PlayerItemID (這就是我們之前查詢時把ID也選出來的原因)
                int playerItemId = (int)dgvInventory.CurrentRow.Cells["PlayerItemId"].Value;

                using (var context = new GameDbContext())
                {
                    // 使用 Find 方法根據主鍵快速找到要刪除的紀錄
                    var itemToRemove = context.PlayerItems.Find(playerItemId);
                    if (itemToRemove != null)
                    {
                        // 告訴 EF Core 要移除這筆紀錄
                        context.PlayerItems.Remove(itemToRemove);
                        // 執行刪除
                        context.SaveChanges();
                    }
                }
                // 重新整理畫面
                LoadAllData();
                MessageBox.Show("道具已從背包移除。");
            }
        }
    }
}
