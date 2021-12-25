using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
//using System.Text.Json;
//using System.Text.Encodings.Web;
using System.IO;

namespace ExamCSharpTask.Models
{
    class GoodsCategory
    {
        private const string GOODS_CATEGORIES_PATH = "goods_category.json";
        public int IdGoods { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }

        public static List<GoodsCategory> goodsCategories = new List<GoodsCategory>();

		public GoodsCategory(int idGoods, string name, int price, string category)
		{
			IdGoods = idGoods;
			Name = name;
			Price = price;
			Category = category;
		}

        public static void ParseToGoodsCategory(List<Goods> goods, List<Category> categories)
		{
            goodsCategories.Clear();
            foreach (Goods goodsTmp in goods)
            {
                GoodsCategory goodsCategory = new GoodsCategory(goodsTmp.IdGoods, goodsTmp.Name, goodsTmp.Price, categories.Find(c => c.IdCategory == goodsTmp.IdCategory)?.Name);
                if (goodsCategory != null)
                {
                    goodsCategories.Add(goodsCategory);
                }
            }
        }

		public static void ParseToJson(List<Goods> goods, List<Category> categories)
        {
            ParseToGoodsCategory(goods, categories);

            string json = JsonConvert.SerializeObject(goodsCategories); // newtonsoft

            //var options = new JsonSerializerOptions
            //{
            //    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            //    WriteIndented = true
            //};
            //string json = JsonSerializer.Serialize(goodsCategories, options);

            File.WriteAllText(GOODS_CATEGORIES_PATH, json,Encoding.Default);
        }

    }


}
