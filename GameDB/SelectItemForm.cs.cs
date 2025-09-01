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
    public partial class SelectItemForm : Form
    {
        public int SelectedItemId { get; private set; }
        public int SelectedQuantity { get; private set; }
        public SelectItemForm()
        {
            InitializeComponent();
        }

        private void SelectItemForm_Load(object sender, EventArgs e)
        {
            // 視窗載入時，從資料庫讀取所有道具並顯示
            using (var context = new GameDbContext())
            {
                // 只選擇需要的欄位來顯示，讓列表更乾淨
                dgvAllItems.DataSource = context.Items.Select(i => new
                {
                    i.ItemId,
                    i.ItemName,
                    i.ItemType,
                    i.Rarity
                }).ToList();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (dgvAllItems.CurrentRow != null)
            {
                // 將使用者選擇的道具ID和數量，存到公開屬性中
                SelectedItemId = (int)dgvAllItems.CurrentRow.Cells["ItemId"].Value;
                SelectedQuantity = (int)nudQuantity.Value;

                // 設定 DialogResult 為 OK，這會讓 ShowDialog() 返回 OK 並自動關閉本視窗
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("請先選擇一個道具！");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // 設定 DialogResult 為 Cancel，關閉視窗
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
