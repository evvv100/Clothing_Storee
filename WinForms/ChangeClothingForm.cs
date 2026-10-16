using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class ChangeClothingForm : Form
    {
        public int Id { get; set; }

        public ChangeClothingForm(int id)
        {
            InitializeComponent();

            Load += ChangeClothingForm_Load;   
            bChange.Click += BChange_Click;
            bCancel.Click += BCancel_Click;
            ControlBox = false;
            label2.Text = MainForm._balance.ToString();
            Id = id;
            lID.Text = Id.ToString();
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
        /// Проверяет, правильно ли заполнены поля, меняет данные о товаре, закрывает форму
        /// </summary>
        /// <param name="sender">Объект-отправитель события</param>
        /// <param name="e">Аргумент данных события</param>
        private void BChange_Click(object? sender, EventArgs e)
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
                Clothing newClothing = new Clothing(Id, name, category, size, price);
                MainForm._logic.ChangeClothing(newClothing);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось изменить товар:\n" + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Товар успешно изменен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        /// <summary>
        /// Заполняет выпадающие списки из перечислений ClothingCategory и ClothingSize
        /// и подставляет в поля текущие данные товара
        /// </summary>
        /// <param name="sender">Объект-отправитель события</param>
        /// <param name="e">Аргумент данных события</param>
        private void ChangeClothingForm_Load(object? sender, EventArgs e)
        {
            cCategory.DataSource = Enum.GetValues(typeof(ClothingCategory));
            cSize.DataSource = Enum.GetValues(typeof(ClothingSize));

            cCategory.DropDownStyle = ComboBoxStyle.DropDownList; // только выбор из списка
            cSize.DropDownStyle = ComboBoxStyle.DropDownList;

            Clothing? current;
            try
            {
                current = MainForm._logic.GetClothingById(Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить товар:\n" + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            if (current == null || current.IsSold)
            {
                MessageBox.Show("Товар не найден в каталоге.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            tName.Text = current.Name;
            tPrice.Text = current.Price.ToString();
            cCategory.SelectedItem = current.Category;
            cSize.SelectedItem = current.Size;
        }

        private void label2_Click(object? sender, EventArgs e)
        {
        }

        private void bChange_Click_1(object sender, EventArgs e)
        {

        }
    }
}
