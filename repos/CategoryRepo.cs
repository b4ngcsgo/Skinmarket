using Dapper;
using Skinmarket.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinmarket.repos
{
    public class CategoryRepo
    
    {
        private static readonly string _connString = "Data Source=localhost;Initial Catalog=SkinMarket;Integrated Security=true";
        public static List<Category> GetCategories()
        {
            string sql = "select * from categories";

            using (var conn = new SqlConnection(_connString))
            {
                var ListOfCategories = conn.Query<Category>(sql);

                return ListOfCategories.ToList();
            }
        }
        public static void ShowCategorys()
        {
            var categories = GetCategories();
            int counter = 0;
            foreach (var category in categories)
            {
                Console.WriteLine(category.CategoryName);
            }
            Console.WriteLine(" ");
        }
        public static int SearchCategorys(string categoryChoice)
        {
            string sql = "SELECT CategoryID FROM Categories WHERE CategoryName = @categoryChoice";
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@categoryChoice", categoryChoice);
                    int categoryID = (int)cmd.ExecuteScalar();
                    return categoryID;
                }
            }
        }
        public static int GetListingIDByTitle(string Title)
        {
            string sql = $"SELECT ListingID FROM Listings WHERE Title = '{Title}'";
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                var ID = conn.QuerySingle<int>(sql);
                return ID;
            }
        }

    }
}
