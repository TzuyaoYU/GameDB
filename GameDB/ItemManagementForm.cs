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

namespace GameDB
{
    public partial class ItemManagementForm : Form
    {
        public ItemManagementForm()
        {
            InitializeComponent();
        }
        private void ItemManagementForm_Load(object sender, EventArgs e)
        {
            // 視窗載入時，執行這兩項初始化任務
            PopulateComboBoxes();
            LoadItems();
        }

        private void PopulateComboBoxes()
        {
            // 填充道具類型選項
            cboItemType.Items.AddRange(new object[] { "武器", "防具", "消耗品", "材料" });
            cboItemType.DropDownStyle = ComboBoxStyle.DropDownList; // 設為只能選不能打字
            cboItemType.SelectedIndex = 0; // 預設選中第一項

            // 填充稀有度選項
            cboRarity.Items.AddRange(new object[] { "普通", "稀有", "史詩", "傳說" });
            cboRarity.DropDownStyle = ComboBoxStyle.DropDownList; // 設為只能選不能打字
            cboRarity.SelectedIndex = 0; // 預設選中第一項
        }
        private void LoadItems()
        {
            using (var context = new GameDbContext())
            {
                // 將查詢結果繫結到 DataSource
                // 為了避免循環參考導致的問題，我們使用 .Select 建立一個新的匿名物件來顯示
                var items = context.Items.Select(i => new
                {
                    i.ItemId,
                    i.ItemName,
                    i.ItemType,
                    i.Rarity
                }).ToList();
                dgvItems.DataSource = items;
            }
        }
        private void dgvItems_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvItems.CurrentRow != null)
            {
                // 這次我們不能直接轉換 DataBoundItem，因為我們繫結的是匿名型別
                // 我們需要透過欄位名稱來取得值
                var selectedRow = dgvItems.CurrentRow;
                txtItemID.Text = selectedRow.Cells["ItemId"].Value.ToString();
                txtItemName.Text = selectedRow.Cells["ItemName"].Value.ToString();
                cboItemType.SelectedItem = selectedRow.Cells["ItemType"].Value.ToString();
                cboRarity.SelectedItem = selectedRow.Cells["Rarity"].Value.ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtItemID.Text = string.Empty;
            txtItemName.Text = string.Empty;
            cboItemType.SelectedIndex = 0;
            cboRarity.SelectedIndex = 0;
            txtItemName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new GameDbContext())
                {
                    if (string.IsNullOrEmpty(txtItemID.Text)) // ID是空的，代表是新增
                    {
                        var newItem = new Item
                        {
                            ItemName = txtItemName.Text,
                            ItemType = cboItemType.SelectedItem.ToString(),
                            Rarity = cboRarity.SelectedItem.ToString()
                        };
                        context.Items.Add(newItem);
                    }
                    else // ID有值，代表是更新
                    {
                        int itemID = int.Parse(txtItemID.Text);
                        Item itemToUpdate = context.Items.Find(itemID);
                        if (itemToUpdate != null)
                        {
                            itemToUpdate.ItemName = txtItemName.Text;
                            itemToUpdate.ItemType = cboItemType.SelectedItem.ToString();
                            itemToUpdate.Rarity = cboRarity.SelectedItem.ToString();
                        }
                    }
                    context.SaveChanges();
                }
                MessageBox.Show("操作成功！");
                LoadItems(); // 重新載入列表
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失敗，錯誤訊息：" + ex.Message);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtItemID.Text))
            {
                MessageBox.Show("請先從列表中選擇要刪除的道具。");
                return;
            }

            if (MessageBox.Show("您確定要刪除這個道具嗎？", "確認刪除", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int itemID = int.Parse(txtItemID.Text);
                using (var context = new GameDbContext())
                {
                    Item itemToDelete = context.Items.Find(itemID);
                    if (itemToDelete != null)
                    {
                        context.Items.Remove(itemToDelete);
                        context.SaveChanges();
                        LoadItems();
                        btnClear.PerformClick();
                    }
                }
            }
        }
    }
}
