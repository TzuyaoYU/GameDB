namespace GameDB
{
    partial class PlayerDetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblPlayerInfo = new Label();
            groupBox1 = new GroupBox();
            dgvInventory = new DataGridView();
            groupBox2 = new GroupBox();
            dgvEquipment = new DataGridView();
            btnEquip = new Button();
            btnUnequip = new Button();
            btnAddItem = new Button();
            btnRemoveItem = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEquipment).BeginInit();
            SuspendLayout();
            // 
            // lblPlayerInfo
            // 
            lblPlayerInfo.AutoSize = true;
            lblPlayerInfo.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPlayerInfo.Location = new Point(34, 19);
            lblPlayerInfo.Name = "lblPlayerInfo";
            lblPlayerInfo.Size = new Size(81, 30);
            lblPlayerInfo.TabIndex = 0;
            lblPlayerInfo.Text = "label1";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvInventory);
            groupBox1.Location = new Point(34, 78);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(310, 241);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "玩家背包";
            // 
            // dgvInventory
            // 
            dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventory.Dock = DockStyle.Fill;
            dgvInventory.Location = new Point(3, 19);
            dgvInventory.Name = "dgvInventory";
            dgvInventory.Size = new Size(304, 219);
            dgvInventory.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvEquipment);
            groupBox2.Location = new Point(453, 78);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(310, 241);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "目前裝備";
            // 
            // dgvEquipment
            // 
            dgvEquipment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquipment.Dock = DockStyle.Fill;
            dgvEquipment.Location = new Point(3, 19);
            dgvEquipment.Name = "dgvEquipment";
            dgvEquipment.Size = new Size(304, 219);
            dgvEquipment.TabIndex = 0;
            // 
            // btnEquip
            // 
            btnEquip.Location = new Point(356, 123);
            btnEquip.Name = "btnEquip";
            btnEquip.Size = new Size(75, 23);
            btnEquip.TabIndex = 3;
            btnEquip.Text = "裝備 →";
            btnEquip.UseVisualStyleBackColor = true;
            btnEquip.Click += btnEquip_Click;
            // 
            // btnUnequip
            // 
            btnUnequip.Location = new Point(356, 200);
            btnUnequip.Name = "btnUnequip";
            btnUnequip.Size = new Size(75, 23);
            btnUnequip.TabIndex = 4;
            btnUnequip.Text = "← 卸下";
            btnUnequip.UseVisualStyleBackColor = true;
            btnUnequip.Click += btnUnequip_Click;
            // 
            // btnAddItem
            // 
            btnAddItem.Location = new Point(78, 357);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(75, 23);
            btnAddItem.TabIndex = 5;
            btnAddItem.Text = "給予道具";
            btnAddItem.UseVisualStyleBackColor = true;
            btnAddItem.Click += btnAddItem_Click;
            // 
            // btnRemoveItem
            // 
            btnRemoveItem.Location = new Point(202, 357);
            btnRemoveItem.Name = "btnRemoveItem";
            btnRemoveItem.Size = new Size(75, 23);
            btnRemoveItem.TabIndex = 6;
            btnRemoveItem.Text = "移除道具";
            btnRemoveItem.UseVisualStyleBackColor = true;
            btnRemoveItem.Click += btnRemoveItem_Click;
            // 
            // PlayerDetailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRemoveItem);
            Controls.Add(btnAddItem);
            Controls.Add(btnUnequip);
            Controls.Add(btnEquip);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(lblPlayerInfo);
            Name = "PlayerDetailForm";
            Text = "PlayerDetailForm";
            Load += PlayerDetailForm_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEquipment).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPlayerInfo;
        private GroupBox groupBox1;
        private DataGridView dgvInventory;
        private GroupBox groupBox2;
        private DataGridView dgvEquipment;
        private Button btnEquip;
        private Button btnUnequip;
        private Button btnAddItem;
        private Button btnRemoveItem;
    }
}