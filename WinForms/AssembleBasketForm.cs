using System;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinForms
{
    public partial class AssembleBasketForm : Form
    {
        // Корзина хранится только в памяти формы. В БД товары не трогаются до оплаты.
        private readonly List<Clothing> _basket = new List<Clothing>();

        public AssembleBasketForm()
        {
            InitializeComponent();

            ControlBox = false;
            UpdateBasket();
            UpdateCatalog();
            bAdd.Click += BAdd_Click;
            bRemove.Click += BRemove_Click;
            bOk.Click += BOk_Click;
            bCancel.Click += BCancel_Click;
            label3.Text = MainForm._balance.ToString();
            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
            cSize.DataSource = Enum.GetValues(typeof(ClothingSize));
            cSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cSize.SelectedIndexChanged += CSize_SelectedIndexChanged;
        }

        /// <summary>
        /// При изменении выбранного размера обновляет таблицу каталог
        /// </summary>
        /// <param name="sender">Объект-отправитель события</param>
        /// <param name="e">Аргумент данных события</param>
        private void CSize_SelectedIndexChanged(object? sender, EventArgs e)
        {
            UpdateCatalog();
        }

        /// <summary>
        /// Показывает/скрывает список размеров и обновляет таблицу каталог
        /// </summary>
        /// <param name="sender">Объект-отправитель события</param>
        /// <param name="e">Аргумент данных события</param>
        private void CheckBox1_CheckedChanged(object? sender, EventArgs e)
        {
            cSize.Visible = checkBox1.Checked;
            UpdateCatalog();
        }

        /// <summary>
        /// Закрывает форму без покупки. Корзина просто сбрасывается, в БД ничего не менялось
        /// </summary>
        /// <param name="sender">Объект-отправитель события</param>
        /// <param name="e">Аргумент данных события</param>
        private void BCancel_Click(object? sender, EventArgs e)
        {
            _basket.Clear();
            Close();
        }

        /// <summary>
        /// Проверяет корзину и баланс, оформляет покупку (товары помечаются купленными в БД), закрывает форму
        /// </summary>
        /// <param name="sender">Объект-отправитель события</param>
        /// <param name="e">Аргумент данных события</param>
        private void BOk_Click(object? sender, EventArgs e)
        {
            if (_basket.Count == 0)
            {
                MessageBox.Show("Добавьте товары в корзину!", "Корзина пуста", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int total = CalculateTheTotal();
            if (MainForm._balance < total)
            {
                MessageBox.Show("Недостаточно средств!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult res = MessageBox.Show($"Сумма покупки составляет: {total}\nОплатить?",
                "Завершение покупки", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res != DialogResult.Yes)
            {
                return;
            }

            try
            {
                MainForm._logic.Buy(_basket);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось оформить покупку:\n" + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateCatalog();   // каталог мог измениться - показываем актуальный
                return;
            }

            MainForm._balance -= total;
            _basket.Clear();
            Close();
        }

        /// <summary>
        /// Убирает из корзины последний добавленный товар (он снова появляется в каталоге)
        /// </summary>
        /// <param name="sender">Объект-отправитель события</param>
        /// <param name="e">Аргумент данных события</param>
        private void BRemove_Click(object? sender, EventArgs e)
        {
            if (_basket.Count == 0)
            {
                MessageBox.Show("В корзине ничего нет!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _basket.RemoveAt(_basket.Count - 1);

            UpdateBasket();
            UpdateCatalog();
            lTotal.Text = CalculateTheTotal().ToString();
        }

        /// <summary>
        /// Добавляет выбранный в каталоге товар в корзину, обновляет итоговую сумму
        /// </summary>
        /// <param name="sender">Объект-отправитель события</param>
        /// <param name="e">Аргумент данных события</param>
        private void BAdd_Click(object? sender, EventArgs e)
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
                if (item == null || item.IsSold)
                {
                    MessageBox.Show("Такого товара не существует!", "Неизвестный товар", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (_basket.Any(b => b.Id == item.Id))
                {
                    MessageBox.Show("Этот товар уже в корзине.", "Товар в корзине", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _basket.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось добавить товар:\n" + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateBasket();
            UpdateCatalog();
            lTotal.Text = CalculateTheTotal().ToString();
        }

        /// <summary>
        /// Считает сумму покупки
        /// </summary>
        /// <returns>Возвращает сумму покупки</returns>
        private int CalculateTheTotal()
        {
            return _basket.Sum(c => c.Price);
        }

        /// <summary>
        /// Обновляет данные в dataGridView dBasket
        /// </summary>
        private void UpdateBasket()
        {
            dBasket.DataSource = null;
            dBasket.DataSource = _basket;
            SetHeaders(dBasket);
        }

        /// <summary>
        /// Обновляет данные в dataGridView dCatalog: товары магазина, которых еще нет в корзине
        /// (с фильтром по размеру, если он включен)
        /// </summary>
        private void UpdateCatalog()
        {
            List<Clothing> clothing;
            try
            {
                clothing = MainForm._logic.GetCatalog()
                    .Where(c => !_basket.Any(b => b.Id == c.Id))
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить каталог:\n" + ex.Message,
                    "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clothing = new List<Clothing>();
            }

            if (checkBox1.Checked && cSize.SelectedItem is ClothingSize size)
            {
                clothing = clothing.Where(c => c.Size == size).ToList();
            }

            dCatalog.DataSource = null;
            dCatalog.DataSource = clothing;
            SetHeaders(dCatalog);
        }

        /// <summary>
        /// Подписывает столбцы таблицы по-русски и скрывает служебный столбец IsSold
        /// </summary>
        /// <param name="grid">Таблица, у которой нужно задать заголовки</param>
        private static void SetHeaders(DataGridView grid)
        {
            if (grid.Columns["Id"] != null)
                grid.Columns["Id"].HeaderText = "Артикул";
            if (grid.Columns["Name"] != null)
                grid.Columns["Name"].HeaderText = "Название";
            if (grid.Columns["Category"] != null)
                grid.Columns["Category"].HeaderText = "Категория";
            if (grid.Columns["Size"] != null)
                grid.Columns["Size"].HeaderText = "Размер";
            if (grid.Columns["Price"] != null)
                grid.Columns["Price"].HeaderText = "Цена (руб.)";
            if (grid.Columns["IsSold"] != null)
                grid.Columns["IsSold"].Visible = false;
        }

        // Пустые обработчики ниже можно удалить, если они не привязаны в AssembleBasketForm.Designer.cs
        private void label1_Click(object? sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
        }

        private void AssembleBasketForm_Load(object? sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}