using Dapper;
using Skinmarket.Models;
using Skinmarket.repos;
using Skinmarket.View;
using System.Data;
using System.Data.SqlClient;

namespace Skinmarket
{
    public class Program

    {
        private static readonly string _connString = "Data Source=localhost;Initial Catalog=SkinMarket;Integrated Security=true";
        static void Main(string[] args)
        {
            while (true)
            {
                int choice = UI.ShowMenu();
                if(choice == 1) {
                    Console.Clear();
                    var listing = UI.SkapaAnnonsValues();
                    InsertListing(listing);
                }
                if(choice == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Skriv in annonstitel för att kunna uppdatera din annons: ");
                    int ListingID = CategoryRepo.GetListingIDByTitle(Console.ReadLine());
                    var listing = UI.UppdateraAnnonsValues();
                    UpdateListing(listing, ListingID);

                }
                if(choice == 3)
                {
                    Console.Clear();
                    UI.RemoveListing();
                }
                if(choice == 4)
                {
                    Console.Clear();
                    UI.SearchListingsWithTitle();
                }
                if(choice == 5)
                {
                    Console.Clear();
                    UI.SearchListingsWithCategoryName();
                }
            }
        }
        public static void InsertListing(Listing listing)
        {
            using (IDbConnection conn = new SqlConnection(_connString))
            {
                string sql = $"insert into Listings(Title,Description,Price,CategoryID)" +
                    $" values ('{listing.Title}','{listing.Description}',{listing.Price},{listing.CategoryID})";
                conn.Execute(sql);
            }
        }
        public static void UpdateListing(Listing listing, int listingID)
        {
            using (IDbConnection conn = new SqlConnection(_connString))
            {
                string sql = $"update Listings" +
                    $" set Title = '{listing.Title}', Description = '{listing.Description}', Price = {listing.Price}" +
                    $" where ListingID = {listingID}";
                conn.Execute(sql);
            }
            // mute inc
        }
    }
}