namespace WinForms
{
    partial class AssembleBasketForm
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
            bRemove = new Button();
            bAdd = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dCatalog = new DataGridView();
            label4 = new Label();
            dBasket = new DataGridView();
            label5 = new Label();
            checkBox1 = new CheckBox();
            cSize = new ComboBox();
            bOk = new Button();
            label6 = new Label();
            lTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)dCatalog).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dBasket).BeginInit();
            SuspendLayout();
            // 
            // bCancel
            // 
            bCancel.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bCancel.Location = new Point(691, 12);
            bCancel.Name = "bCancel";
            bCancel.Size = new Size(97, 31);
            bCancel.TabIndex = 15;
            bCancel.Text = "Назад";
            bCancel.UseVisualStyleBackColor = true;
            // 
            // bRemove
            // 
            bRemove.BackColor = Color.IndianRed;
            bRemove.Font = new Font("Segoe UI", 7.8F);
            bRemove.ForeColor = SystemColors.Control;
            bRemove.Location = new Point(475, 406);
            bRemove.Name = "bRemove";
            bRemove.Size = new Size(97, 31);
            bRemove.TabIndex = 14;
            bRemove.Text = "Удалить";
            bRemove.UseVisualStyleBackColor = false;
            // 
            // bAdd
            // 
            bAdd.Font = new Font("Segoe UI", 7.8F);
            bAdd.Location = new Point(354, 406);
            bAdd.Name = "bAdd";
            bAdd.Size = new Size(97, 31);
            bAdd.TabIndex = 13;
            bAdd.Text = "Добавить";
            bAdd.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(156, 9);
            label3.Name = "label3";
            label3.Size = new Size(72, 28);
            label3.TabIndex = 11;
            label3.Text = "10000";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(138, 28);
            label2.TabIndex = 10;
            label2.Text = "Ваш баланс: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(344, 34);
            label1.Name = "label1";
            label1.Size = new Size(100, 31);
            label1.TabIndex = 9;
            label1.Text = "Каталог";
            // 
            // dCatalog
            // 
            dCatalog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dCatalog.Location = new Point(12, 66);
            dCatalog.Name = "dCatalog";
            dCatalog.RowHeadersWidth = 51;
            dCatalog.Size = new Size(776, 128);
            dCatalog.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(344, 197);
            label4.Name = "label4";
            label4.Size = new Size(108, 31);
            label4.TabIndex = 17;
            label4.Text = "Корзина";
            // 
            // dBasket
            // 
            dBasket.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dBasket.Location = new Point(12, 241);
            dBasket.Name = "dBasket";
            dBasket.RowHeadersWidth = 51;
            dBasket.Size = new Size(776, 128);
            dBasket.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(13, 410);
            label5.Name = "label5";
            label5.Size = new Size(174, 23);
            label5.TabIndex = 18;
            label5.Text = "Фильтровать размер";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(210, 415);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(18, 17);
            checkBox1.TabIndex = 0;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // cSize
            // 
            cSize.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cSize.FormattingEnabled = true;
            cSize.Location = new Point(245, 404);
            cSize.Name = "cSize";
            cSize.Size = new Size(69, 39);
            cSize.TabIndex = 19;
            // 
            // bOk
            // 
            bOk.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bOk.Location = new Point(557, 12);
            bOk.Name = "bOk";
            bOk.Size = new Size(97, 31);
            bOk.TabIndex = 20;
            bOk.Text = "Ок";
            bOk.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(590, 406);
            label6.Name = "label6";
            label6.Size = new Size(85, 31);
            label6.TabIndex = 21;
            label6.Text = "Итого:";
            // 
            // lTotal
            // 
            lTotal.AutoSize = true;
            lTotal.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lTotal.Location = new Point(691, 406);
            lTotal.Name = "lTotal";
            lTotal.Size = new Size(27, 31);
            lTotal.TabIndex = 22;
            lTotal.Text = "0";
            // 
            // AssembleBasketForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lTotal);
            Controls.Add(label6);
            Controls.Add(bOk);
            Controls.Add(cSize);
            Controls.Add(checkBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dBasket);
            Controls.Add(bCancel);
            Controls.Add(bRemove);
            Controls.Add(bAdd);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dCatalog);
            Name = "AssembleBasketForm";
            Text = "AssembleBasketForm";
            Load += AssembleBasketForm_Load;
            ((System.ComponentModel.ISupportInitialize)dCatalog).EndInit();
            ((System.ComponentModel.ISupportInitialize)dBasket).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button bCancel;
        private Button bRemove;
        private Button bAdd;
        private Button bChange;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView dCatalog;
        private Label label4;
        private DataGridView dBasket;
        private Label label5;
        private CheckBox checkBox1;
        private ComboBox cSize;
        private Button bOk;
        private Label label6;
        private Label lTotal;
    }
}