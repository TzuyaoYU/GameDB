

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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            LoadPlayers();
        }


        private void LoadPlayers()
        {

            using (var context = new GameDbContext())
            {

                var players = context.Players.ToList();


                dgvPlayers.DataSource = players;
            }
        }

        private void dgvPlayers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPlayers.CurrentRow != null)
            {

                Player selectedPlayer = (Player)dgvPlayers.CurrentRow.DataBoundItem;


                txtPlayerID.Text = selectedPlayer.PlayerId.ToString();
                txtUsername.Text = selectedPlayer.Username;
                txtNickname.Text = selectedPlayer.Nickname;
                txtLevel.Text = selectedPlayer.Level.ToString();
                txtJoinDate.Text = selectedPlayer.JoinDate.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new GameDbContext())
                {
                    // 判斷是新增還是更新
                    if (string.IsNullOrEmpty(txtPlayerID.Text))
                    {
                        // ========== 執行新增 (INSERT) ==========
                        var newPlayer = new Player
                        {
                            // 從 TextBox 讀取資料來建立新玩家物件
                            Username = txtUsername.Text,
                            Nickname = txtNickname.Text,
                            Level = int.Parse(txtLevel.Text),
                            JoinDate = DateTime.Now // 新增的玩家，加入日期設為當下
                        };

                        // 告訴 EF Core：我要新增這個物件
                        context.Players.Add(newPlayer);
                    }
                    else
                    {
                        // ========== 執行更新 (UPDATE) ==========
                        int playerID = int.Parse(txtPlayerID.Text);
                        Player playerToUpdate = context.Players.Find(playerID);
                        if (playerToUpdate != null)
                        {
                            playerToUpdate.Username = txtUsername.Text;
                            playerToUpdate.Nickname = txtNickname.Text;
                            playerToUpdate.Level = int.Parse(txtLevel.Text);
                        }
                    }

                    // 不論是新增還是更新，最後都要呼叫 SaveChanges() 將變動寫入資料庫
                    context.SaveChanges();
                }

                MessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPlayers(); // 重新載入列表以顯示最新資料
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失敗，發生錯誤：\n" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // 清空所有 TextBox 的內容
            txtPlayerID.Text = string.Empty; // PlayerID 清空是關鍵，用來判斷是新增還是更新
            txtUsername.Text = string.Empty;
            txtNickname.Text = string.Empty;
            txtLevel.Text = string.Empty;
            txtJoinDate.Text = string.Empty;

            // 讓使用者可以直接開始輸入帳號
            txtUsername.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 檢查是否有選中要刪除的玩家
            if (string.IsNullOrEmpty(txtPlayerID.Text))
            {
                MessageBox.Show("請先從左側列表中選擇一位要刪除的玩家。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 彈出確認對話框，防止誤刪
            var confirmResult = MessageBox.Show("您確定要刪除這位玩家嗎？\n此操作無法復原！", "確認刪除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                // 使用者確認刪除
                try
                {
                    int playerID = int.Parse(txtPlayerID.Text);
                    using (var context = new GameDbContext())
                    {
                        Player playerToDelete = context.Players.Find(playerID);
                        if (playerToDelete != null)
                        {
                            // 告訴 EF Core：我要刪除這個物件
                            context.Players.Remove(playerToDelete);
                            // 執行刪除
                            context.SaveChanges();

                            MessageBox.Show("玩家已刪除。");
                            LoadPlayers(); // 重新載入列表
                            btnClear.PerformClick(); // 模擬點擊清除按鈕，清空右側欄位
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("刪除失敗，發生錯誤：\n" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnManageItems_Click(object sender, EventArgs e)
        {
            // 建立 ItemManagementForm 的實體
            ItemManagementForm itemForm = new ItemManagementForm();
            // 顯示視窗
            itemForm.Show();
        }

        private void dgvPlayers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 確保使用者點擊的是一個有效的資料列
            if (e.RowIndex >= 0)
            {
                // 取得選中列的 Player ID
                var selectedRow = dgvPlayers.Rows[e.RowIndex];
                int selectedPlayerId = (int)selectedRow.Cells["PlayerId"].Value;

                // 建立詳情視窗的實體，並將 ID 傳遞進去
                PlayerDetailForm detailForm = new PlayerDetailForm(selectedPlayerId);

                // 顯示視窗
                detailForm.ShowDialog();
            }
        }
    }
}