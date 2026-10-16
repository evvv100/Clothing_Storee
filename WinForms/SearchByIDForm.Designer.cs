namespace WinForms
{
    partial class SearchByIDForm
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
            dCatalog = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            bChange = new Button();
            bAdd = new Button();
            bRemove = new Button();
            bCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dCatalog).BeginInit();
            SuspendLayout();
            // 
            // dCatalog
            // 
            dCatalog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dCatalog.Location = new Point(43, 72);
            dCatalog.Name = "dCatalog";
            dCatalog.RowHeadersWidth = 51;
            dCatalog.Size = new Size(719, 289);
            dCatalog.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(349, 40);
            label1.Name = "label1";
            label1.Size = new Size(100, 31);
            label1.TabIndex = 1;
            label1.Text = "Каталог";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(8, 6);
            label2.Name = "label2";
            label2.Size = new Size(138, 28);
            label2.TabIndex = 2;
            label2.Text = "Ваш баланс: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(155, 6);
            label3.Name = "label3";
            label3.Size = new Size(72, 28);
            label3.TabIndex = 3;
            label3.Text = "10000";
            // 
            // bChange
            // 
            bChange.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bChange.Location = new Point(13, 396);
            bChange.Name = "bChange";
            bChange.Size = new Size(165, 42);
            bChange.TabIndex = 4;
            bChange.Text = "Изменить";
            bChange.UseVisualStyleBackColor = true;
            // 
            // bAdd
            // 
            bAdd.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bAdd.Location = new Point(215, 396);
            bAdd.Name = "bAdd";
            bAdd.Size = new Size(165, 42);
            bAdd.TabIndex = 5;
            bAdd.Text = "Добавить";
            bAdd.UseVisualStyleBackColor = true;
            // 
            // bRemove
            // 
            bRemove.BackColor = Color.IndianRed;
            bRemove.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bRemove.ForeColor = SystemColors.Control;
            bRemove.Location = new Point(417, 396);
            bRemove.Name = "bRemove";
            bRemove.Size = new Size(165, 42);
            bRemove.TabIndex = 6;
            bRemove.Text = "Удалить";
            bRemove.UseVisualStyleBackColor = false;
            // 
            // bCancel
            // 
            bCancel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bCancel.Location = new Point(623, 396);
            bCancel.Name = "bCancel";
            bCancel.Size = new Size(165, 42);
            bCancel.TabIndex = 7;
            bCancel.Text = "Назад";
            bCancel.UseVisualStyleBackColor = true;
            // 
            // SearchByIDForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(bCancel);
            Controls.Add(bRemove);
            Controls.Add(bAdd);
            Controls.Add(bChange);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dCatalog);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MaximumSize = new Size(818, 497);
            MinimumSize = new Size(818, 497);
            Name = "SearchByIDForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SearchByIDForm";
            Load += SearchByIDForm_Load;
            ((System.ComponentModel.ISupportInitialize)dCatalog).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dCatalog;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button bChange;
        private Button bAdd;
        private Button bRemove;
        private Button bCancel;
    }
}