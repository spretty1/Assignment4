using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assignment4.Models
{
    public class Restaurant
    {
        public Restaurant(int ranking)
        {
            Rank = ranking;
        }
        //Makes rank a read only 
        [Required]
        public int Rank { get; }
        //makes the restaurant name required
        [Required]
        public string RestaurantName { get; set; }
        //makes the favorite dish optional
        public string? FavoriteDish { get; set; } 
        //makes the address required
        [Required]
        public string Address { get; set; }
        //sets and ensures the phone format
        [Phone, RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
            ErrorMessage = "Entered phone format is not valid.")]
        public string? Phone {get; set;}
        //makes website optional and gives it a default value
        public string? WebsiteLink { get; set; } = "Coming soon.";

        public static Restaurant[] GetPlaces()
        {   //creates the restaurant objects
            Restaurant r1 = new Restaurant(1)
            {
                RestaurantName = "Five Sushi Brothers",
                FavoriteDish = "Lil Bro",
                Address = "445 N Freedom Blvd, Provo, 84601",
                Phone = "(385) 549-4495",
                WebsiteLink = "https://fivesushibrothers.com/",
            };
            Restaurant r2 = new Restaurant(2)
            {
                RestaurantName = "Cafe Rio",
                FavoriteDish = "Pork Salad",
                Address = "2244 N University Pkwy, Provo, UT 84604",
                Phone = "(801) 375-5133",
                WebsiteLink = "https://www.caferio.com/",
            };
            Restaurant r3 = new Restaurant(3)
            {
                RestaurantName = "Cafe Zupas",
                FavoriteDish = "Try Two Combo",
                Address = "408 W 2230 N, Provo, UT 84604",
                Phone = "(801) 377-7687",
                WebsiteLink = "https://cafezupas.com/index.html",
            };
            Restaurant r4 = new Restaurant(4)
            {
                RestaurantName = "Chubby's Cafe",
                FavoriteDish = "Jalapeno Ranch Deluxe",
                Address = "576 N Mill Rd",
                Phone = "(801) 922-5254",
                WebsiteLink = "https://www.chubbyscafeut.com/",
            };
            Restaurant r5 = new Restaurant(5)
            {
                RestaurantName = "Cupbop",
                FavoriteDish = "Tok Bop",
                Address = "700 E # 815, Provo, UT 84606",
                Phone = "(801) 607-5200",
                WebsiteLink = "https://cupbop.com/",
            };
            //returns the array with the passed objects
            return new Restaurant[] { r1, r2, r3, r4, r5 };
        }
    }
}
