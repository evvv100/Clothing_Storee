namespace WinForms
{
    partial class HistoryForm
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
            bReturn = new Button();
            label3 = new Label();
            label2 = new Label();
            dCatalog = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dCatalog).BeginInit();
            SuspendLayout();
            // 
            // bCancel
            // 
            bCancel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bCancel.Location = new Point(317, 396);
            bCancel.Name = "bCancel";
            bCancel.Size = new Size(165, 42);
            bCancel.TabIndex = 15;
            bCancel.Text = "Назад";
            bCancel.UseVisualStyleBackColor = true;
            // 
            // bReturn
            // 
            bReturn.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bReturn.Location = new Point(601, 16);
            bReturn.Name = "bReturn";
            bReturn.Size = new Size(165, 42);
            bReturn.TabIndex = 13;
            bReturn.Text = "Вернуть";
            bReturn.UseVisualStyleBackColor = true;
            //bReturn.Click += bReturn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(159, -2);
            label3.Name = "label3";
            label3.Size = new Size(72, 28);
            label3.TabIndex = 11;
            label3.Text = "10000";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, -2);
            label2.Name = "label2";
            label2.Size = new Size(138, 28);
            label2.TabIndex = 10;
            label2.Text = "Ваш баланс: ";
            // 
            // dCatalog
            // 
            dCatalog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dCatalog.Location = new Point(47, 64);
            dCatalog.Name = "dCatalog";
            dCatalog.RowHeadersWidth = 51;
            dCatalog.Size = new Size(719, 326);
            dCatalog.TabIndex = 8;
            dCatalog.CellContentClick += dCatalog_CellContentClick;
            // 
            // HistoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(bCancel);
            Controls.Add(bReturn);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dCatalog);
            Name = "HistoryForm";
            Text = "HistoryForm";
            ((System.ComponentModel.ISupportInitialize)dCatalog).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button bCancel;
        private Button bReturn;
        private Label label3;
        private Label label2;
        private DataGridView dCatalog;
    }
}