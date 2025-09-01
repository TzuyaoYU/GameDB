namespace GameDB
{
    partial class SelectItemForm
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
            dgvAllItems = new DataGridView();
            label1 = new Label();
            nudQuantity = new NumericUpDown();
            btnOk = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAllItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            SuspendLayout();
            // 
            // dgvAllItems
            // 
            dgvAllItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAllItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAllItems.Dock = DockStyle.Left;
            dgvAllItems.Location = new Point(0, 0);
            dgvAllItems.MultiSelect = false;
            dgvAllItems.Name = "dgvAllItems";
            dgvAllItems.ReadOnly = true;
            dgvAllItems.Size = new Size(347, 450);
            dgvAllItems.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(454, 65);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 1;
            label1.Text = "數量:";
            // 
            // nudQuantity
            // 
            nudQuantity.Location = new Point(494, 63);
            nudQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new Size(120, 23);
            nudQuantity.TabIndex = 2;
            nudQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnOk
            // 
            btnOk.Location = new Point(454, 135);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 3;
            btnOk.Text = "確定";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(557, 135);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // SelectItemForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(nudQuantity);
            Controls.Add(label1);
            Controls.Add(dgvAllItems);
            Name = "SelectItemForm";
            Text = "SelectItemForm";
            Load += SelectItemForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAllItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvAllItems;
        private Label label1;
        private NumericUpDown nudQuantity;
        private Button btnOk;
        private Button btnCancel;
    }
}