using ExamCSharpTask.Classes;
using ExamCSharpTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExamCSharpTask.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChooserPage.xaml
    /// </summary>
    public partial class ChooserPage : Page
    {
        public ChooserPage()
        {
            InitializeComponent();
        }

        private void Categories_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CategoriesPage());
        }

        private void Goods_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new GoodsPage());
        }

        private void GoodsCategories_Click(object sender, RoutedEventArgs e)
        {
            Category.ReadCategories();
            Goods.ReadGoods();
            GoodsCategory.ParseToJson(Goods.GoodsList, Category.categories);
            MessageBox.Show("Вы успешно сформировали json файл");

        }


    }
}
