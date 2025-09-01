namespace GameDB
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvPlayers = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtPlayerID = new TextBox();
            txtUsername = new TextBox();
            txtNickname = new TextBox();
            txtLevel = new TextBox();
            txtJoinDate = new TextBox();
            btnSave = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            btnManageItems = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPlayers).BeginInit();
            SuspendLayout();
            // 
            // dgvPlayers
            // 
            dgvPlayers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPlayers.Location = new Point(12, 107);
            dgvPlayers.Name = "dgvPlayers";
            dgvPlayers.Size = new Size(544, 331);
            dgvPlayers.TabIndex = 0;
            dgvPlayers.CellDoubleClick += dgvPlayers_CellDoubleClick;
            dgvPlayers.SelectionChanged += dgvPlayers_SelectionChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(589, 52);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 1;
            label1.Text = "玩家ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(589, 83);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 2;
            label2.Text = "玩家帳號:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(589, 116);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 3;
            label3.Text = "玩家暱稱:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(589, 145);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 4;
            label4.Text = "等級:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(589, 176);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 5;
            label5.Text = "加入日期:";
            // 
            // txtPlayerID
            // 
            txtPlayerID.Location = new Point(672, 52);
            txtPlayerID.Name = "txtPlayerID";
            txtPlayerID.ReadOnly = true;
            txtPlayerID.Size = new Size(129, 23);
            txtPlayerID.TabIndex = 6;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(672, 80);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(129, 23);
            txtUsername.TabIndex = 7;
            // 
            // txtNickname
            // 
            txtNickname.Location = new Point(672, 113);
            txtNickname.Name = "txtNickname";
            txtNickname.Size = new Size(129, 23);
            txtNickname.TabIndex = 8;
            // 
            // txtLevel
            // 
            txtLevel.Location = new Point(672, 142);
            txtLevel.Name = "txtLevel";
            txtLevel.Size = new Size(129, 23);
            txtLevel.TabIndex = 9;
            // 
            // txtJoinDate
            // 
            txtJoinDate.Location = new Point(672, 171);
            txtJoinDate.Name = "txtJoinDate";
            txtJoinDate.Size = new Size(129, 23);
            txtJoinDate.TabIndex = 10;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(755, 263);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 11;
            btnSave.Text = "儲存變更";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(589, 263);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 12;
            btnClear.Text = "清除/新增";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(672, 263);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "刪除玩家";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnManageItems
            // 
            btnManageItems.Location = new Point(12, 12);
            btnManageItems.Name = "btnManageItems";
            btnManageItems.Size = new Size(101, 37);
            btnManageItems.TabIndex = 14;
            btnManageItems.Text = "管理道具";
            btnManageItems.UseVisualStyleBackColor = true;
            btnManageItems.Click += btnManageItems_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(842, 484);
            Controls.Add(btnManageItems);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Controls.Add(btnSave);
            Controls.Add(txtJoinDate);
            Controls.Add(txtLevel);
            Controls.Add(txtNickname);
            Controls.Add(txtUsername);
            Controls.Add(txtPlayerID);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvPlayers);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPlayers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPlayers;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtPlayerID;
        private TextBox txtUsername;
        private TextBox txtNickname;
        private TextBox txtLevel;
        private TextBox txtJoinDate;
        private Button btnSave;
        private Button btnClear;
        private Button btnDelete;
        private Button btnManageItems;
    }
}
