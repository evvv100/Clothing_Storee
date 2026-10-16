namespace WinForms
{
    partial class ChangeClothingForm
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
            bCancel = new Button();
            bChange = new Button();
            cSize = new ComboBox();
            cCategory = new ComboBox();
            tPrice = new TextBox();
            tName = new TextBox();
            lID = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // bCancel
            // 
            bCancel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bCancel.Location = new Point(428, 374);
            bCancel.Name = "bCancel";
            bCancel.Size = new Size(195, 46);
            bCancel.TabIndex = 35;
            bCancel.Text = "Назад";
            bCancel.UseVisualStyleBackColor = true;
            // 
            // bChange
            // 
            bChange.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bChange.Location = new Point(191, 374);
            bChange.Name = "bChange";
            bChange.Size = new Size(195, 46);
            bChange.TabIndex = 34;
            bChange.Text = "Изменить";
            bChange.UseVisualStyleBackColor = true;
            bChange.Click += bChange_Click_1;
            // 
            // cSize
            // 
            cSize.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cSize.FormattingEnabled = true;
            cSize.Location = new Point(416, 254);
            cSize.Name = "cSize";
            cSize.Size = new Size(207, 39);
            cSize.TabIndex = 33;
            // 
            // cCategory
            // 
            cCategory.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cCategory.FormattingEnabled = true;
            cCategory.Location = new Point(416, 203);
            cCategory.Name = "cCategory";
            cCategory.Size = new Size(207, 39);
            cCategory.TabIndex = 32;
            // 
            // tPrice
            // 
            tPrice.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tPrice.Location = new Point(416, 304);
            tPrice.Name = "tPrice";
            tPrice.Size = new Size(207, 38);
            tPrice.TabIndex = 31;
            // 
            // tName
            // 
            tName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tName.Location = new Point(345, 154);
            tName.Name = "tName";
            tName.Size = new Size(278, 38);
            tName.TabIndex = 30;
            // 
            // lID
            // 
            lID.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lID.Location = new Point(416, 104);
            lID.Name = "lID";
            lID.ReadOnly = true;
            lID.Size = new Size(207, 38);
            lID.TabIndex = 29;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(188, 307);
            label8.Name = "label8";
            label8.Size = new Size(77, 31);
            label8.TabIndex = 28;
            label8.Text = "Цена:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(188, 257);
            label7.Name = "label7";
            label7.Size = new Size(100, 31);
            label7.TabIndex = 27;
            label7.Text = "Размер:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(188, 206);
            label6.Name = "label6";
            label6.Size = new Size(133, 31);
            label6.TabIndex = 26;
            label6.Text = "Категория:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(188, 157);
            label5.Name = "label5";
            label5.Size = new Size(126, 31);
            label5.TabIndex = 25;
            label5.Text = "Название:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(188, 107);
            label4.Name = "label4";
            label4.Size = new Size(41, 31);
            label4.TabIndex = 24;
            label4.Text = "Id:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(187, 39);
            label1.Name = "label1";
            label1.Size = new Size(416, 38);
            label1.TabIndex = 23;
            label1.Text = "Введите данные новой вещи";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(152, 6);
            label3.Name = "label3";
            label3.Size = new Size(72, 28);
            label3.TabIndex = 22;
            label3.Text = "10000";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(5, 6);
            label2.Name = "label2";
            label2.Size = new Size(138, 28);
            label2.TabIndex = 21;
            label2.Text = "Ваш баланс: ";
            // 
            // ChangeClothingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(bCancel);
            Controls.Add(bChange);
            Controls.Add(cSize);
            Controls.Add(cCategory);
            Controls.Add(tPrice);
            Controls.Add(tName);
            Controls.Add(lID);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "ChangeClothingForm";
            Text = "ChangeClothingForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button bCancel;
        private Button bChange;
        private ComboBox cSize;
        private ComboBox cCategory;
        private TextBox tPrice;
        private TextBox tName;
        private TextBox lID;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label1;
        private Label label3;
        private Label label2;
    }
}