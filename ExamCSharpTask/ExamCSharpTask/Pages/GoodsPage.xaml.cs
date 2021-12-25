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
    /// Логика взаимодействия для GoodsPage.xaml
    /// </summary>
    public partial class GoodsPage : Page
    {
        public GoodsPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateGoodsGrid();
        }

        private void UpdateGoodsGrid()
        {
            Goods_Grid.ItemsSource = null;
            Goods_Grid.Items.Clear();
            Goods.ReadGoods();
            Category.ReadCategories();
            GoodsCategory.ParseToGoodsCategory(Goods.GoodsList, Category.categories);
            Goods_Grid.ItemsSource = GoodsCategory.goodsCategories;
            Goods_Grid.Items.Refresh();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            GoodsCategory goodsCategory = (sender as Button).DataContext as GoodsCategory;
            Manager.MainFrame.Navigate(new AddGoodsPage(goodsCategory.IdGoods));
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddGoodsPage());
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var goodsCategory = Goods_Grid.SelectedItems.Cast<GoodsCategory>().ToList();
            if (MessageBox.Show("Вы точно хотите удалить ", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    foreach(GoodsCategory goodsCategoryTmp in goodsCategory)
					{
                        Goods.RemoveGoods(goodsCategoryTmp.Name);

                    }
                    MessageBox.Show("Данные удалены");
                    UpdateGoodsGrid();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }



	}
}
