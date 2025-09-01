namespace GameDB
{
    partial class ItemManagementForm
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
            dgvItems = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtItemID = new TextBox();
            txtItemName = new TextBox();
            cboItemType = new ComboBox();
            cboRarity = new ComboBox();
            btnClear = new Button();
            btnSave = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            SuspendLayout();
            // 
            // dgvItems
            // 
            dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItems.Dock = DockStyle.Left;
            dgvItems.Location = new Point(0, 0);
            dgvItems.Name = "dgvItems";
            dgvItems.Size = new Size(552, 469);
            dgvItems.TabIndex = 0;
            dgvItems.SelectionChanged += dgvItems_SelectionChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(621, 47);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 1;
            label1.Text = "道具ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(621, 74);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 2;
            label2.Text = "道具名稱:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(621, 101);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 3;
            label3.Text = "道具類型:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(621, 127);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 4;
            label4.Text = "稀有度:";
            // 
            // txtItemID
            // 
            txtItemID.Location = new Point(688, 44);
            txtItemID.Name = "txtItemID";
            txtItemID.ReadOnly = true;
            txtItemID.Size = new Size(100, 23);
            txtItemID.TabIndex = 5;
            // 
            // txtItemName
            // 
            txtItemName.Location = new Point(688, 71);
            txtItemName.Name = "txtItemName";
            txtItemName.Size = new Size(100, 23);
            txtItemName.TabIndex = 6;
            // 
            // cboItemType
            // 
            cboItemType.FormattingEnabled = true;
            cboItemType.Location = new Point(688, 98);
            cboItemType.Name = "cboItemType";
            cboItemType.Size = new Size(100, 23);
            cboItemType.TabIndex = 7;
            // 
            // cboRarity
            // 
            cboRarity.FormattingEnabled = true;
            cboRarity.Location = new Point(688, 124);
            cboRarity.Name = "cboRarity";
            cboRarity.Size = new Size(100, 23);
            cboRarity.TabIndex = 8;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(558, 205);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 9;
            btnClear.Text = "清除/新增";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(743, 205);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 10;
            btnSave.Text = "儲存變更";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(650, 205);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "刪除道具";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // ItemManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(830, 469);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(btnClear);
            Controls.Add(cboRarity);
            Controls.Add(cboItemType);
            Controls.Add(txtItemName);
            Controls.Add(txtItemID);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvItems);
            Name = "ItemManagementForm";
            Text = "Form2";
            Load += ItemManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvItems;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtItemID;
        private TextBox txtItemName;
        private ComboBox cboItemType;
        private ComboBox cboRarity;
        private Button btnClear;
        private Button btnSave;
        private Button btnDelete;
    }
}