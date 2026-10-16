using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinForms
{
    public partial class HistoryForm : Form
    {
        public HistoryForm()
        {
            InitializeComponent();
            bCancel.Click += BCancel_Click;
            bReturn.Click += BReturn_Click;
            ControlBox = false;
            label2.Text = MainForm._balance.ToString();
            UpdateData();
        }

        /// <summary>
        /// Возвращает купленный товар в магазин и деньги на счет
        /// </summary>
        /// <param name="sender">Объект-отправитель события</param>
        /// <param name="e">Аргумент данных события</param>
        private void BReturn_Click(object? sender, EventArgs e)
        {
            if (dCatalog.CurrentRow?.Cells["Id"].Value == null)
            {
                MessageBox.Show("Выберите товар!", "Товар не выбран", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int selectedId = Convert.ToInt32(dCatalog.CurrentRow.Cells["Id"].Value);

            try
            {
                Clothing? item = MainForm._logic.GetClothingById(selectedId);
                if (item == null || !item.IsSold)
                {
                    MessageBox.Show("Такого товара не существует!", "Неизвестный товар", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MainForm._logic.ReturnToStore(selectedId);
                    MainForm._balance += item.Price;
                    label2.Text = MainForm._balance.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось вернуть товар:\n" + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateData();
        }

        /// <summary>
        /// Обновляет данные в dataGridView dCatalog
        /// </summary>
        private void UpdateData()
        {
            List<Clothing> purchased;
            try
            {
                purchased = MainForm._logic.GetPurchased();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить историю покупок:\n" + ex.Message,
                    "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                purchased = new List<Clothing>();
            }

            dCatalog.DataSource = null;
            dCatalog.DataSource = purchased;

            if (dCatalog.Columns["Id"] != null)
                dCatalog.Columns["Id"].HeaderText = "Артикул";
            if (dCatalog.Columns["Name"] != null)
                dCatalog.Columns["Name"].HeaderText = "Название";
            if (dCatalog.Columns["Category"] != null)
                dCatalog.Columns["Category"].HeaderText = "Категория";
            if (dCatalog.Columns["Size"] != null)
                dCatalog.Columns["Size"].HeaderText = "Размер";
            if (dCatalog.Columns["Price"] != null)
                dCatalog.Columns["Price"].HeaderText = "Цена (руб.)";
            if (dCatalog.Columns["IsSold"] != null)
                dCatalog.Columns["IsSold"].Visible = false;   
        }

        /// <summary>
        /// Закрывает форму
        /// </summary>
        /// <param name="sender">Объект-отправитель события</param>
        /// <param name="e">Аргумент данных события</param>
        private void BCancel_Click(object? sender, EventArgs e)
        {
            Close();
        }
        private void HistoryForm_Load(object? sender, EventArgs e)
        {
        }

        private void label1_Click(object? sender, EventArgs e)
        {
        }

        private void label2_Click(object? sender, EventArgs e)
        {
        }

        private void dCatalog_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
        }
    }
}