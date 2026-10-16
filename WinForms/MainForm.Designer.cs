namespace WinForms
{
    partial class MainForm
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
            label1 = new Label();
            bCatalog = new Button();
            bAssemble = new Button();
            bHistory = new Button();
            bBack = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(114, 118);
            label1.Name = "label1";
            label1.Size = new Size(554, 38);
            label1.TabIndex = 0;
            label1.Text = "Добро пожаловать в магазин одежды!";
            // 
            // bCatalog
            // 
            bCatalog.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bCatalog.Location = new Point(50, 179);
            bCatalog.Margin = new Padding(3, 10, 3, 10);
            bCatalog.Name = "bCatalog";
            bCatalog.Size = new Size(343, 48);
            bCatalog.TabIndex = 1;
            bCatalog.Text = "Каталог";
            bCatalog.UseVisualStyleBackColor = true;
            // 
            // bAssemble
            // 
            bAssemble.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bAssemble.Location = new Point(399, 179);
            bAssemble.Name = "bAssemble";
            bAssemble.Size = new Size(343, 48);
            bAssemble.TabIndex = 2;
            bAssemble.Text = "Собрать корзину";
            bAssemble.UseVisualStyleBackColor = true;
            // 
            // bHistory
            // 
            bHistory.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bHistory.Location = new Point(50, 247);
            bHistory.Margin = new Padding(3, 10, 3, 10);
            bHistory.Name = "bHistory";
            bHistory.Size = new Size(343, 48);
            bHistory.TabIndex = 3;
            bHistory.Text = "История покупок";
            bHistory.UseVisualStyleBackColor = true;
            // 
            // bBack
            // 
            bBack.BackColor = Color.FromArgb(255, 128, 128);
            bBack.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bBack.ForeColor = SystemColors.ControlLightLight;
            bBack.Location = new Point(399, 247);
            bBack.Margin = new Padding(3, 10, 3, 10);
            bBack.Name = "bBack";
            bBack.Size = new Size(343, 48);
            bBack.TabIndex = 4;
            bBack.Text = "Завершить покупки";
            bBack.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(bBack);
            Controls.Add(bHistory);
            Controls.Add(bAssemble);
            Controls.Add(bCatalog);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MaximumSize = new Size(818, 497);
            MinimumSize = new Size(818, 497);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Магазин одежды";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button bCatalog;
        private Button bAssemble;
        private Button bHistory;
        private Button bBack;
    }
}
