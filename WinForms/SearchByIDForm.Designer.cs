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
            bChange = new Button();
            bAdd = new Button();
            bRemove = new Button();
            bCancel = new Button();
            cSize = new ComboBox();
            checkBox1 = new CheckBox();
            label5 = new Label();
            cCategory = new ComboBox();
            checkBox2 = new CheckBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dCatalog).BeginInit();
            SuspendLayout();
            // 
            // dCatalog
            // 
            dCatalog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dCatalog.Location = new Point(43, 72);
            dCatalog.MultiSelect = false;
            dCatalog.Name = "dCatalog";
            dCatalog.RowHeadersWidth = 51;
            dCatalog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dCatalog.Size = new Size(719, 289);
            dCatalog.TabIndex = 0;
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
            // cSize
            // 
            cSize.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cSize.FormattingEnabled = true;
            cSize.Location = new Point(275, 13);
            cSize.Name = "cSize";
            cSize.Size = new Size(69, 39);
            cSize.TabIndex = 22;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(240, 24);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(18, 17);
            checkBox1.TabIndex = 20;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(43, 19);
            label5.Name = "label5";
            label5.Size = new Size(174, 23);
            label5.TabIndex = 21;
            label5.Text = "Фильтровать размер";
            // 
            // cCategory
            // 
            cCategory.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cCategory.FormattingEnabled = true;
            cCategory.Location = new Point(634, 13);
            cCategory.Name = "cCategory";
            cCategory.Size = new Size(128, 39);
            cCategory.TabIndex = 25;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(599, 24);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(18, 17);
            checkBox2.TabIndex = 23;
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(373, 19);
            label1.Name = "label1";
            label1.Size = new Size(200, 23);
            label1.TabIndex = 24;
            label1.Text = "Фильтровать категорию";
            label1.Click += label1_Click;
            // 
            // SearchByIDForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cCategory);
            Controls.Add(checkBox2);
            Controls.Add(label1);
            Controls.Add(cSize);
            Controls.Add(checkBox1);
            Controls.Add(label5);
            Controls.Add(bCancel);
            Controls.Add(bRemove);
            Controls.Add(bAdd);
            Controls.Add(bChange);
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
        private Button bChange;
        private Button bAdd;
        private Button bRemove;
        private Button bCancel;
        private ComboBox cSize;
        private CheckBox checkBox1;
        private Label label5;
        private ComboBox cCategory;
        private CheckBox checkBox2;
        private Label label1;
    }
}