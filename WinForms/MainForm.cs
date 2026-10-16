using DataAccessLayer;
using Logic;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinForms
{
    public partial class MainForm : Form
    {
        private static Random rnd = new Random();
        public static Logic.Logic _logic = new Logic.Logic(new EntityRepository<Clothing>());
        public static int _balance = rnd.Next(10000, 20001);
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

        private void BBack_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BHistory_Click(object? sender, EventArgs e)
        {
            HistoryForm historyForm = new HistoryForm();
            Hide();
            historyForm.ShowDialog();
            Show();
        }

        private void BCatalog_Click(object? sender, EventArgs e)
        {
            SearchByIDForm searchByIDForm = new SearchByIDForm();
            Hide();
            searchByIDForm.ShowDialog();
            Show();
        }

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
