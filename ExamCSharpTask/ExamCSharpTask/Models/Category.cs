using System;
using System.Collections.Generic;
using System.IO;

namespace ExamCSharpTask.Models
{
    class Category
    {
        public const string CATEGORIES_PATH = "categories.txt";
        private static int maxId = 0;
        public int IdCategory { get; set; }
        public string Name { get; set; }

        public static List<Category> categories = new List<Category>();

        public Category(string name)
        {
            maxId++;
            IdCategory = maxId;
            Name = name;
        }

        public Category(int id,string name)
        {
            IdCategory = id;
            Name = name;
        }

        public static void ReadCategories()
        {
            if (!File.Exists(CATEGORIES_PATH))
			{
                return;
			}

            categories.Clear();       
            using (StreamReader reader = new StreamReader(CATEGORIES_PATH))
            {
                string row;
                int max = 0;
                while ((row = reader.ReadLine()) != null){
                    string[] data = row.Split(';');
                    int id = Convert.ToInt32(data[0]);
                    categories.Add(new Category(id, data[1]));
                    if(max < id)
                    {
                        max = id;
                    }
                }
                maxId = max;
            }
        }

        public static void WriteCategory(Category category)
        {
            categories.Add(category);
            using (StreamWriter writer = new StreamWriter(CATEGORIES_PATH,true))
            {
                writer.WriteLine($"{category.IdCategory};{category.Name}");
            }
        }

        public static void RemoveCategory(Category category)
        {
            categories.Remove(category);
            OverwriteCategories();
        }

        public static void UpdateCategory()
		{
            OverwriteCategories();
        }

        private static void OverwriteCategories()
		{
            using (StreamWriter writer = new StreamWriter(CATEGORIES_PATH,false))
            {
                foreach(Category category in categories)
                    writer.WriteLine($"{category.IdCategory};{category.Name}");
            }
        }
    }
}
