using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCSharpTask.Models
{
    class Goods
    {
        public const string GOODS_PATH = "goods.txt";
        private static int maxId = 0;
        public int IdGoods { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int IdCategory { get; set; }
        public static List<Goods> GoodsList = new List<Goods>();

        public Goods(string name, int price, int idCategory)
		{
            maxId++;
            IdGoods = maxId;
            Name = name;
			Price = price;
			IdCategory = idCategory;
		}

        public Goods(int idGoods,string name, int price, int idCategory)
        {
            IdGoods = idGoods;
            Name = name;
            Price = price;
            IdCategory = idCategory;
        }

        public Goods()
        {
            IdGoods = 0;
        }

        public static void WriteGoods(Goods goods)
        {
            using (StreamWriter writer = new StreamWriter(GOODS_PATH, true))
            {
                writer.WriteLine($"{goods.IdGoods};{goods.Name};{goods.Price};{goods.IdCategory}");
            }
        }

        public static void ReadGoods()
        {
            if (!File.Exists(GOODS_PATH))
            {
                return;
            }

            GoodsList.Clear();
            using (StreamReader reader = new StreamReader(GOODS_PATH))
            {
                string row;
                int max = 0;
                while ((row = reader.ReadLine()) != null)
                {
                    string[] data = row.Split(';');
                    int id = Convert.ToInt32(data[0]);
                    GoodsList.Add(new Goods(id, data[1], Convert.ToInt32(data[2]), Convert.ToInt32(data[3])));
                    if (id > max)
                    {
                        max = id;
                    }
                }
                maxId = max;
            }
        }

        public static void RemoveGoods(Goods goods)
        {
            GoodsList.Remove(goods);
            OverwriteGoods();
        }


        public static void RemoveGoods(string name)
        {
            Goods removedGoods = GoodsList.Find(g => g.Name == name);
            GoodsList.Remove(removedGoods);
            OverwriteGoods();
        }

        public static void UpdateGoods()
        {
            OverwriteGoods();
        }

        private static void OverwriteGoods()
        {
            using (StreamWriter writer = new StreamWriter(GOODS_PATH, false))
            {
                foreach (Goods goodsTmp in GoodsList)
                    writer.WriteLine($"{goodsTmp.IdGoods};{goodsTmp.Name};{goodsTmp.Price};{goodsTmp.IdCategory}");
            }
        }
    }
}
