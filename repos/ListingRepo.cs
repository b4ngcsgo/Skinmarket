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
    public class ListingRepo
    {
        private static readonly string _connString = "Data Source=localhost;Initial Catalog=SkinMarket;Integrated Security=true";
        public static void SearchAndGetListings(string searchString)
        {
            string sql = $"select * from Listings" +
                $" where Title like '%{searchString}%'";

            using (var conn = new SqlConnection(_connString))
            {
                var ListingResults = conn.Query<Listing>(sql);

                var ListOfListingResults = ListingResults.ToList();
                foreach (var Listing in ListOfListingResults)
                {
                    int ListingID = GetListingIDByTitle(Listing.Title);
                    Console.WriteLine($"ID: {ListingID} {Listing.Title}");
                    Console.WriteLine(" ");
                    //Console.WriteLine(Listing.Description);
                    //Console.WriteLine(Listing.Price.ToString());
                    //int ListingID = GetListingIDByTitle(Listing.Title);
                    //Console.WriteLine(ListingID);
                }
            }
        }
        public static void RemoveListing(int ListingID)
        {
            string sql = $"DELETE FROM Listings Where ListingID = {ListingID}";
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                conn.Execute(sql);
            }
        }
        public static int GetListingIDByTitle(string Title)
        {
            string sql = $"SELECT ListingID FROM Listings WHERE Title = '{Title}'";
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                var ListingID = conn.QuerySingle<int>(sql);
                return ListingID;
            }
        }

        public static void GetListByCategoryID(int CategoryID)
        {
            string sql = $"SELECT * FROM Listings WHERE CategoryID = {CategoryID}";
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                var ListingResults = conn.Query<Listing>(sql);
                var ListOfListingResults = ListingResults.ToList();
                int counter = 0;
                foreach (var Listing in ListOfListingResults)
                {
                    counter++;
                    int ListingID = GetListingIDByTitle(Listing.Title);
                    Console.WriteLine($"ID: {ListingID} {Listing.Title}");
                }
            }
        }

        public static void GetListingByID(int inputListingID)
        {
            string sql = $"select * from Listings" +
                $" where ListingID = {inputListingID}";

            using (var conn = new SqlConnection(_connString))
            {
                var ListingResults = conn.Query<Listing>(sql);

                var ListOfListingResults = ListingResults.ToList();
                int counter = 0;
                foreach (var Listing in ListOfListingResults)
                {
                    counter++;
                    if (counter % 4 == 0)
                    {
                        Console.WriteLine(" ");
                    }
                    Console.WriteLine(Listing.Title);
                    Console.WriteLine(Listing.Description);
                    Console.WriteLine(Listing.Price.ToString());
                    int ListingID = GetListingIDByTitle(Listing.Title);
                    Console.WriteLine(ListingID);
                }
            }
        }
    }
}
