using DataAccessLayer;
using Logic;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinForms
{
    /// <summary>
    /// Главная форма приложения, предоставляющая доступ к каталогу, корзине и истории продаж.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Генератор случайных чисел для инициализации баланса.
        /// </summary>
        private static Random rnd = new Random();

        /// <summary>
        /// Объект бизнес-логики для управления данными о товарах.
        /// </summary>
        public static Logic.Logic _logic = new Logic.Logic(new EntityRepository<Clothing>());

        /// <summary>
        /// Текущий финансовый баланс пользователя.
        /// </summary>
        public static int _balance = rnd.Next(10000, 20001);

        /// <summary>
        /// Инициализирует новый экземпляр главной формы, заполняет базу тестовыми данными при необходимости и подписывается на события кнопок.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            if (_logic.GetCatalog().Count == 0)
            {
                _logic.FilledTable();
            }
            bCatalog.Click += BCatalog_Click;
            bAssemble.Click += BAssemble_Click;
            bHistory.Click += BHistory_Click;
            bBack.Click += BBack_Click;
        }

        /// <summary>
        /// Завершает работу приложения при нажатии на кнопку выхода.
        /// </summary>
        /// <param name="sender">Объект-отправитель события</param>
        /// <param name="e">Аргумент данных события</param>
        private void BBack_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Открывает форму истории продаж, временно скрывая главную форму.
        /// </summary>
        /// <param name="sender">Объект-отправитель события</param>
        /// <param name="e">Аргумент данных события</param>
        private void BHistory_Click(object? sender, EventArgs e)
        {
            HistoryForm historyForm = new HistoryForm();
            Hide();
            historyForm.ShowDialog();
            Show();
        }
        /// <summary>
        /// Открывает форму каталога товаров, временно скрывая главную форму.
        /// </summary>
        /// <param name="sender">Объект-отправитель события</param>
        /// <param name="e">Аргумент данных события</param>
        private void BCatalog_Click(object? sender, EventArgs e)
        {
            SearchByIDForm searchByIDForm = new SearchByIDForm();
            Hide();
            searchByIDForm.ShowDialog();
            Show();
        }
        /// <summary>
        /// Открывает форму сборки корзины/покупки, временно скрывая главную форму.
        /// </summary>
        /// <param name="sender">Объект-отправитель события</param>
        /// <param name="e">Аргумент данных события</param>
        private void BAssemble_Click(object? sender, EventArgs e)
        {
            AssembleBasketForm assembleBasketForm = new AssembleBasketForm();
            Hide();
            assembleBasketForm.ShowDialog();
            Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
