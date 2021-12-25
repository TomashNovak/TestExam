using ExamCSharpTask.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ExamCSharpTask.Pages
{
    public partial class CategoriesPage : Page
    {
        public CategoriesPage()
        {
            InitializeComponent();
            UpdateCategoriesList();
        }

        private void UpdateCategoriesList()
        {
            Category.ReadCategories();
            Categories_ListBox.ItemsSource = Category.categories;
            Categories_ListBox.Items.Refresh();
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            if (Categories_ListBox.SelectedIndex >= 0)
            {
                Categories_ListBox.SelectedIndex = -1;
                Categories_GroupBox.Header = "Добавление";
                Name_textBox.Clear();
                return;
            }
            string name = Name_textBox.Text;
            if (String.IsNullOrEmpty(name))
            {
                MessageBox.Show("Заполните имя категории");
                return;
            }
            Category category = new Category(name);
            Category.WriteCategory(category);
            MessageBox.Show("Вы успешно добавили категорию");
            Name_textBox.Clear();
            UpdateCategoriesList();
        }

        private void RemoveCategory_Click(object sender, RoutedEventArgs e)
        {
            if (Categories_ListBox.SelectedIndex >= 0)
            {
                Category category = (Category)Categories_ListBox.SelectedItem;
                if (category != null)
                {
                    Category.RemoveCategory(category);
                    MessageBox.Show("Вы успешно удалили данные о категории");
                    UpdateCategoriesList();
                }
            }
            else
            {
                MessageBox.Show("Для начала выберите категорию из списка");
            }
        }

        private void UpdateCategory_Click(object sender, RoutedEventArgs e)
        {
            if (Categories_ListBox.SelectedIndex >= 0)
            {
                Category category = (Category)Categories_ListBox.SelectedItem;
                if (category != null)
                {
                    category.Name = Name_textBox.Text;
                    Category.UpdateCategory();
                    MessageBox.Show("Вы успешно изменили данные о категории");
                    UpdateCategoriesList();
                }
            }
            else
            {
                MessageBox.Show("Для начала выберите авторы из списка");
            }
        }

		private void Categories_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
            if (Categories_ListBox.SelectedIndex < 0)
            {
                Categories_GroupBox.Header = "Добавление";
                Name_textBox.Clear();
                return;
            }
            Category category = (Category)Categories_ListBox.SelectedItem;
            if (category != null)
            {
                Categories_GroupBox.Header = "Просмотр и редактирование";
                Name_textBox.Text = category.Name;
            }
        }

		private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
            UpdateCategoriesList();

        }
    }
}
