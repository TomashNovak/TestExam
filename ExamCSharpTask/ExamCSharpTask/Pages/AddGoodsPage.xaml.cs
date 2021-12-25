using ExamCSharpTask.Classes;
using ExamCSharpTask.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ExamCSharpTask.Pages
{
    public partial class AddGoodsPage : Page
    {
        private Goods _selectedGoods = new Goods();

        public AddGoodsPage()
        {
            InitializeComponent();
            Category.ReadCategories();
            List<Category> categories = Category.categories;
            Categories_comboBox.ItemsSource = categories;
            DataContext = _selectedGoods;
        }

        public AddGoodsPage(int idGoods)
        {
            InitializeComponent();

            Category.ReadCategories();
            List<Category> categories = Category.categories;

            Categories_comboBox.ItemsSource = categories;

            _selectedGoods = Goods.GoodsList.Find(g => g.IdGoods == idGoods);
            DataContext = _selectedGoods;

            Category category = Category.categories.Find(g => g.IdCategory == _selectedGoods.IdCategory);
            Categories_comboBox.SelectedItem = category;

            Title_Label.Content = "Редактирование";
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Name_textBox.Text) || string.IsNullOrEmpty(Price_textBox.Text) || Categories_comboBox.SelectedItem == null)
            {
                MessageBox.Show("Заполните поля");
                return;
            }

            if (_selectedGoods.IdGoods == 0)
            {
                _selectedGoods = new Goods(_selectedGoods.Name, _selectedGoods.Price, _selectedGoods.IdCategory);
                DataContext = _selectedGoods;
                _selectedGoods.IdCategory = ((Category)Categories_comboBox.SelectedItem).IdCategory;
                Goods.WriteGoods(_selectedGoods);
                MessageBox.Show("Вы успешно добавили товар");

            }

            else
            {
                _selectedGoods.IdCategory = ((Category)Categories_comboBox.SelectedItem).IdCategory;
                Goods.UpdateGoods();
                MessageBox.Show("Вы успешно обновили данные о товаре");
            }

            Manager.MainFrame.GoBack();
        }
    }
}
