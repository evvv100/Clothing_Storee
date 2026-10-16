namespace WinForms
{
    partial class AddClothingForm
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
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            tID = new TextBox();
            tName = new TextBox();
            tPrice = new TextBox();
            cCategory = new ComboBox();
            cSize = new ComboBox();
            bAdd = new Button();
            bCancel = new Button();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(155, 6);
            label3.Name = "label3";
            label3.Size = new Size(72, 28);
            label3.TabIndex = 5;
            label3.Text = "10000";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(8, 6);
            label2.Name = "label2";
            label2.Size = new Size(138, 28);
            label2.TabIndex = 4;
            label2.Text = "Ваш баланс: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(190, 39);
            label1.Name = "label1";
            label1.Size = new Size(416, 38);
            label1.TabIndex = 6;
            label1.Text = "Введите данные новой вещи";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(191, 107);
            label4.Name = "label4";
            label4.Size = new Size(41, 31);
            label4.TabIndex = 7;
            label4.Text = "Id:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(191, 157);
            label5.Name = "label5";
            label5.Size = new Size(126, 31);
            label5.TabIndex = 8;
            label5.Text = "Название:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(191, 206);
            label6.Name = "label6";
            label6.Size = new Size(133, 31);
            label6.TabIndex = 9;
            label6.Text = "Категория:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(191, 257);
            label7.Name = "label7";
            label7.Size = new Size(100, 31);
            label7.TabIndex = 10;
            label7.Text = "Размер:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(191, 307);
            label8.Name = "label8";
            label8.Size = new Size(77, 31);
            label8.TabIndex = 11;
            label8.Text = "Цена:";
            // 
            // tID
            // 
            tID.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tID.Location = new Point(419, 104);
            tID.Name = "tID";
            tID.ReadOnly = true;
            tID.Size = new Size(207, 38);
            tID.TabIndex = 12;
            // 
            // tName
            // 
            tName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tName.Location = new Point(348, 154);
            tName.Name = "tName";
            tName.Size = new Size(278, 38);
            tName.TabIndex = 13;
            // 
            // tPrice
            // 
            tPrice.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tPrice.Location = new Point(419, 304);
            tPrice.Name = "tPrice";
            tPrice.Size = new Size(207, 38);
            tPrice.TabIndex = 16;
            // 
            // cCategory
            // 
            cCategory.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cCategory.FormattingEnabled = true;
            cCategory.Location = new Point(419, 203);
            cCategory.Name = "cCategory";
            cCategory.Size = new Size(207, 39);
            cCategory.TabIndex = 17;
            // 
            // cSize
            // 
            cSize.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cSize.FormattingEnabled = true;
            cSize.Location = new Point(419, 254);
            cSize.Name = "cSize";
            cSize.Size = new Size(207, 39);
            cSize.TabIndex = 18;
            // 
            // bAdd
            // 
            bAdd.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bAdd.Location = new Point(194, 374);
            bAdd.Name = "bAdd";
            bAdd.Size = new Size(195, 46);
            bAdd.TabIndex = 19;
            bAdd.Text = "Добавить";
            bAdd.UseVisualStyleBackColor = true;
            // 
            // bCancel
            // 
            bCancel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bCancel.Location = new Point(431, 374);
            bCancel.Name = "bCancel";
            bCancel.Size = new Size(195, 46);
            bCancel.TabIndex = 20;
            bCancel.Text = "Назад";
            bCancel.UseVisualStyleBackColor = true;
            // 
            // AddClothingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(bCancel);
            Controls.Add(bAdd);
            Controls.Add(cSize);
            Controls.Add(cCategory);
            Controls.Add(tPrice);
            Controls.Add(tName);
            Controls.Add(tID);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AddClothingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddClothingForm";
            Load += AddClothingForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox tID;
        private TextBox tName;
        private TextBox tPrice;
        private ComboBox cCategory;
        private ComboBox cSize;
        private Button bAdd;
        private Button bCancel;
    }
}