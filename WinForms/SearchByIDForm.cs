using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinForms
{
    /// <summary>
    /// Главная форма склада: таблица товаров, фильтры по размеру и категории,
    /// добавление, изменение и удаление товаров
    /// </summary>
    public partial class SearchByIDForm : Form
    {
        public static Logic.Logic _logic = new Logic.Logic(new EntityRepository<Clothing>());
        /// <summary>
        /// Инициализирует новый экземпляр формы SearchByIDForm, настраивает таблицу и фильтры, подписывается на события.
        /// </summary>
        public SearchByIDForm()
        {
            InitializeComponent();

            bChange.Click += BChange_Click;
            bCancel.Click += BCancel_Click;
            bRemove.Click += BRemove_Click;
            bAdd.Click += BAdd_Click;
            bCancel.Text = "Выход";
            SetupGrid();

            cSize.DataSource = Enum.GetValues(typeof(ClothingSize));
            cSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cCategory.DataSource = Enum.GetValues(typeof(ClothingCategory));
            cCategory.DropDownStyle = ComboBoxStyle.DropDownList;

            checkBox1.CheckedChanged += FilterChanged;
            checkBox2.CheckedChanged += FilterChanged;
            cSize.SelectedIndexChanged += FilterChanged;
            cCategory.SelectedIndexChanged += FilterChanged;

            UpdateTableData();
        }
        /// <summary>
        /// Настраивает таблицу: только просмотр, выбор одной строки целиком
        /// </summary>
        private void SetupGrid()
        {
            dCatalog.ReadOnly = true;
            dCatalog.AllowUserToAddRows = false;
            dCatalog.AllowUserToDeleteRows = false;
            dCatalog.MultiSelect = false;
            dCatalog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dCatalog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dCatalog.RowHeadersVisible = false;
        }
        /// <summary>
        /// Включает или выключает выпадающие списки в зависимости от чекбоксов и обновляет таблицу
        /// </summary>
        /// <param name="sender">Объект-отправитель события</param>
        /// <param name="e">Аргумент данных события</param>
        private void FilterChanged(object? sender, EventArgs e)
        {
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
            if (!TryGetSelected(out Clothing? item))
            {
                return;
            }
            DialogResult answer = MessageBox.Show(
                "Удалить товар «" + item!.Name + "» (ID " + item.Id + ")?",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer != DialogResult.Yes)
            {
                return;
            }
            try
            {
                _logic.RemoveClothing(item.Id);
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
        /// Возвращает товары склада с учетом включенных фильтров.
        /// Фильтрация выполняется в бизнес-логике, оба фильтра применяются одновременно.
        /// </summary>
        /// <returns>Список товаров для отображения в таблице</returns>
        private List<Clothing> GetFilteredList()
        {
            List<Clothing> list = _logic.GetAll();
            if (checkBox1.Checked && cSize.SelectedItem is ClothingSize size)
            {
                list = _logic.FilterBySize(list, size);
            }
            if (checkBox2.Checked && cCategory.SelectedItem is ClothingCategory category)
            {
                list = _logic.FilterByCategory(list, category);
            }
            return list;
        }
        /// <summary>
        /// Обновляет данные в таблице dCatalog (товары склада с учетом фильтров), сохраняя выбранную строку.
        /// </summary>
        public void UpdateTableData()
        {
            int? selectedId = null;
            if (dCatalog.CurrentRow?.DataBoundItem is Clothing current)
            {
                selectedId = current.Id;
            }

            List<Clothing> clothesList;
            try
            {
                clothesList = GetFilteredList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить товары на складе:\n" + ex.Message,
                    "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clothesList = new List<Clothing>();
            }

            dCatalog.DataSource = null;
            dCatalog.DataSource = clothesList;
            SetHeader("Id", "ID");
            SetHeader("Name", "Название");
            SetHeader("Category", "Категория");
            SetHeader("Size", "Размер");
            SetHeader("Price", "Цена (руб.)");

            if (selectedId.HasValue)
            {
                foreach (DataGridViewRow row in dCatalog.Rows)
                {
                    if (row.DataBoundItem is Clothing c && c.Id == selectedId.Value)
                    {
                        dCatalog.CurrentCell = row.Cells[0];
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// Задает заголовок колонки таблицы, если такая колонка есть
        /// </summary>
        /// <param name="columnName">Имя колонки (имя свойства товара)</param>
        /// <param name="header">Текст заголовка</param>
        private void SetHeader(string columnName, string header)
        {
            if (dCatalog.Columns[columnName] != null)
            {
                dCatalog.Columns[columnName]!.HeaderText = header;
            }
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
            if (!TryGetSelected(out Clothing? item))
            {
                return;
            }
            ChangeClothingForm changeClothingForm = new ChangeClothingForm(item!.Id);
            changeClothingForm.ShowDialog();
            UpdateTableData();
        }

        /// <summary>
        /// Возвращает выбранный в таблице товар. Если строка не выбрана (например, таблица пуста), показывает сообщение
        /// </summary>
        /// <param name="item">Выбранный товар</param>
        /// <returns>true, если товар выбран</returns>
        private bool TryGetSelected(out Clothing? item)
        {
            item = dCatalog.CurrentRow?.DataBoundItem as Clothing;
            if (item == null)
            {
                MessageBox.Show("Выберите товар!", "Товар не выбран", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void SearchByIDForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}