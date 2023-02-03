using Skinmarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Skinmarket.repos;

namespace Skinmarket.View
{
    public class UI
    {
        public static int ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Meny");
            Console.WriteLine($" 1. Skapa en ny annons \n 2. Uppdatera annons \n 3. Ta bort annons \n 4. Sök på en annons med ungefärlig titel \n 5. Sök på en annons med AnnonsID");
            return int.Parse(Console.ReadLine());
        }

        public static Listing SkapaAnnonsValues()
        {
            Listing listing = new Listing();
            Console.WriteLine("Skriv Titel: ");
            listing.Title = Console.ReadLine();
            Console.WriteLine("Skriv din beskrivning på varan: ");
            listing.Description = Console.ReadLine();
            Console.WriteLine("Skriv ditt pris: ");
            listing.Price = Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("Här har du dom olika kategorierna: ");
            CategoryRepo.ShowCategorys();
            Console.WriteLine("Skriv in din kategori: ");
            string categoryChoice = Console.ReadLine();
            listing.CategoryID = CategoryRepo.SearchCategorys(categoryChoice);
            return listing;
        }
        public static Listing UppdateraAnnonsValues()
        {
            Listing listing = new Listing();
            Console.WriteLine("Skriv ny Titel: ");
            listing.Title = Console.ReadLine();
            Console.WriteLine("Skriv ny beskrivning: ");
            listing.Description = Console.ReadLine();
            Console.WriteLine("Skriv nytt pris: ");
            listing.Price = Convert.ToInt32(Console.ReadLine());
            return listing;
        }

        public static void RemoveListing()
        {
            Console.WriteLine("Skriv in ListingID på annonsen du vill ta bort: ");
            int ListingID = Convert.ToInt32(Console.ReadLine());
            ListingRepo.RemoveListing(ListingID);
            Console.WriteLine("Skriv bokstaven a för att gå ur.");
            while (true)
            {
                string exitCall = Console.ReadLine();
                if (exitCall == "a")
                {
                    break;
                }
            }
        }


        public static void SearchListingsWithTitle()
        {
            Console.WriteLine("Sök på en annons med ungefärlig titel: ");
            string SearchString = Console.ReadLine();
            Console.WriteLine();
            ListingRepo.SearchAndGetListings(SearchString);
            Console.WriteLine("Skriv bokstaven a för att gå ur");
            Console.WriteLine("Eller skriv ID för att se annonsen");
            Console.WriteLine("");
            while (true)
            {
                Console.WriteLine("");
                string exitCall = Console.ReadLine();
                if (exitCall == "a")
                {
                    break;
                }
                else if (int.TryParse(exitCall, out _))
                {
                    Console.WriteLine("");
                    int searchListingID = Convert.ToInt32(exitCall);
                    ListingRepo.GetListingByID(searchListingID);
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Du måste skriva en ListingID eller a för att exita");
                }

            }
        }
        public static void SearchListingsWithCategoryName()
        {
            CategoryRepo.ShowCategorys();
            Console.WriteLine("Skriv in kategori på annonsen / listingen du vill söka: ");
            string SearchString = Console.ReadLine();
            Console.Clear();
            int CategoryID = CategoryRepo.SearchCategorys(SearchString);
            ListingRepo.GetListByCategoryID(CategoryID);
            Console.WriteLine("Skriv bokstaven a för att gå ur");
            Console.WriteLine("Skriv ID för att se annonsen");
            Console.WriteLine("");
            while (true)
            {
                string exitCall = Console.ReadLine();
                Console.WriteLine("");
                if (exitCall == "a")
                {
                    break;
                }
                else if (int.TryParse(exitCall, out _))
                {
                    Console.WriteLine("");
                    int searchListingID = Convert.ToInt32(exitCall);
                    ListingRepo.GetListingByID(searchListingID);
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Du måste skriva en ListingID eller a för att exita");
                }
            }
        }
    }
}
