using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public static class LinqToSQL
    {
        public static void ShowSample()
        {
            // The DataContext
            DataContext db = new DataContext(@"Data Source=PC-IRWIN\SQLIRWIN;Initial Catalog=Northwind;User ID=sa;Password=Subifor2012");
            var categories =
                from category in db.GetTable<Category>()
                where category.Name.StartsWith("Co")
                select category;

            foreach(var category in categories)
                Console.WriteLine("\"{0}\" : \"{1}\"", category.Name, category.Description);
        }
    }
    [Table(Name = "Categories")]
    class Category
    {
        [Column(IsPrimaryKey = true)]
        public int CategoryID { get; set; }
        [Column(Name = "CategoryName")]
        public string Name { get; set; }
        [Column]
        public string Description { get; set; }
    }
}
