using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinForms
{
    /// <summary>
    /// Форма каталога: просмотр, добавление, изменение и удаление товаров
    /// </summary>
    public partial class SearchByIDForm : Form
    {
        /// <summary>
        /// Инициализирует новый экземпляр формы SearchByIDForm и подписывается на события кнопок.
        /// </summary>
        public SearchByIDForm()
        {
            InitializeComponent();

            bChange.Click += BChange_Click;
            bCancel.Click += BCancel_Click;
            bRemove.Click += BRemove_Click;
            bAdd.Click += BAdd_Click;

            UpdateTableData();
        }

        /// <summary>
        /// Открывает форму добавления товара и обновляет таблицу
        /// </summary>
        /// <param name="sender">Объект-отправитель события</param>
        /// <param name="e">Аргумент данных события</param>
        private void BAdd_Click(object? sender, EventArgs e)
        {
            AddClothingForm addClothingForm = new AddClothingForm();
            addClothingForm.ShowDialog();
            UpdateTableData();
        }

        /// <summary>
        /// Удаляет выбранный товар
        /// </summary>
        /// <param name="sender">Объект-отправитель события</param>
        /// <param name="e">Аргумент данных события</param>
        private void BRemove_Click(object? sender, EventArgs e)
        {
            if (!TryGetSelectedId(out int id))
            {
                return;
            }

            try
            {
                MainForm._logic.RemoveClothing(id);
                MessageBox.Show("Товар удален!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Невозможно найти товар", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось удалить товар:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateTableData();
        }

        /// <summary>
        /// Обновляет данные в dataGridView dCatalog (показываются только товары, которые есть в магазине)
        /// </summary>
        public void UpdateTableData()
        {
            List<Clothing> clothesList;
            try
            {
                clothesList = MainForm._logic.GetCatalog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить каталог:\n" + ex.Message,
                    "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clothesList = new List<Clothing>();
            }

            dCatalog.DataSource = null;
            dCatalog.DataSource = clothesList;

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
                dCatalog.Columns["IsSold"].Visible = false;   // в каталоге всегда false, показывать нечего
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

        /// <summary>
        /// Открывает форму изменения для выбранного в таблице товара
        /// </summary>
        /// <param name="sender">Объект-отправитель события</param>
        /// <param name="e">Аргумент данных события</param>
        private void BChange_Click(object? sender, EventArgs e)
        {
            if (!TryGetSelectedId(out int selectedId))
            {
                return;
            }

            ChangeClothingForm changeClothingForm = new ChangeClothingForm(selectedId);
            changeClothingForm.ShowDialog();
            UpdateTableData();
        }

        /// <summary>
        /// Возвращает Id выбранной строки таблицы. Если строка не выбрана (например, каталог пуст), показывает сообщение
        /// </summary>
        /// <param name="id">Id выбранного товара</param>
        /// <returns>true, если товар выбран</returns>
        private bool TryGetSelectedId(out int id)
        {
            id = 0;
            object? cellValue = dCatalog.CurrentRow?.Cells["Id"].Value;
            if (cellValue == null)
            {
                MessageBox.Show("Выберите товар!", "Товар не выбран", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            id = Convert.ToInt32(cellValue);
            return true;
        }

        private void SearchByIDForm_Load(object sender, EventArgs e)
        {

        }
    }
}