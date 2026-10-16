using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class AddClothingForm : Form
    {
        public AddClothingForm()
        {
            InitializeComponent();
            bAdd.Click += Add_Click;
            bCancel.Click += BCancel_Click;

            tID.ReadOnly = true;
            label2.Text = MainForm._balance.ToString();
        }
        /// <summary>
        /// Закрывает форму
        /// </summary>
        /// <param name="sender">Объект-отправитель события</param>
        /// <param name="e">Аргумент данных события</param>
        private void BCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Наполняет данными списки из перечислений ClothingCategory и ClothingSize
        /// </summary>
        /// <param name="sender">Объект-отправитель события</param>
        /// <param name="e">Аргумент данных события</param>
        private void AddClothingForm_Load(object sender, EventArgs e)
        {
            cCategory.DataSource = Enum.GetValues(typeof(ClothingCategory));
            cSize.DataSource = Enum.GetValues(typeof(ClothingSize));

            cCategory.DropDownStyle = ComboBoxStyle.DropDownList; // только выбор из списка
            cSize.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        /// <summary>
        /// Проверяет, верно ли введены данные для добавления одежды, и добавляет новый экземпляр класса Clothing в список магазина
        /// </summary>
        /// <param name="sender">Объект-отправитель события</param>
        /// <param name="e">Аргумент данных события</param>
        private void Add_Click(object? sender, EventArgs e)
        {
            tName.BackColor = Color.White;
            tPrice.BackColor = Color.White;
            cCategory.BackColor = Color.White;
            cSize.BackColor = Color.White;

            var errors = new List<string>();

            string name = tName.Text.Trim();
            if (name.Length == 0)
            {
                tName.BackColor = Color.LightCoral;
                errors.Add("- Название вещи");
            }

            int price = 0;
            string priceText = tPrice.Text.Trim();
            if (priceText.Length == 0)
            {
                tPrice.BackColor = Color.LightCoral;
                errors.Add("- Цена товара (поле не может быть пустым)");
            }
            else if (!int.TryParse(priceText, out price) || price <= 0)
            {
                tPrice.BackColor = Color.LightCoral;
                errors.Add("- Цена товара (должна быть только положительным числом)");
            }

            if (cCategory.SelectedItem == null)
            {
                cCategory.BackColor = Color.LightCoral;
                errors.Add("- Категория товара");
            }

            if (cSize.SelectedItem == null)
            {
                cSize.BackColor = Color.LightCoral;
                errors.Add("- Размер товара");
            }

            if (errors.Count > 0)
            {
                MessageBox.Show("Пожалуйста, заполните обязательные поля:\n" + string.Join("\n", errors),
                    "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var category = (ClothingCategory)cCategory.SelectedItem!;
            var size = (ClothingSize)cSize.SelectedItem!;

            try
            {
                MainForm._logic.AddClothing(name, category, size, price);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось добавить товар:\n" + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Товар успешно добавлен в ассортимент магазина!",
                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
