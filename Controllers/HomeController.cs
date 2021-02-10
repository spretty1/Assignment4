using Assignment4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<string> RestaurantList;
            RestaurantList = new List<string>();
            //loops through the method to add the appropriate string to the list
            foreach (Restaurant r in Restaurant.GetPlaces())
            {
                //sets the null value of the favorite dish
                string? favDish = r.FavoriteDish ?? "It's all tasty!";
                //adds to the list
                RestaurantList.Add($"#{r.Rank}: {r.RestaurantName}, ({favDish}), Address: {r.Address} Phone: {r.Phone}, {r.WebsiteLink}");
            }
            //pass the list to the view as it calls it
            return View(RestaurantList);
        }

        //set the action to access the suggest form view when the user is requesting it
        [HttpGet]
        public IActionResult SuggestForm()
        {
            return View();
        }

        //set the action to access the suggestion form view for posting information, sends user to confirmation page 
        [HttpPost]
        public IActionResult SuggestForm(SuggestionCollection appResponse)
        {   //checks to see if all the required fields are filled
            if (ModelState.IsValid)
            {   //adds to the temporary storage
                TempStorage.AddSuggestion(appResponse);
                //returns the confirmation view 
                return View("Confirmation", appResponse);
            }
            else
            {   //the user stays on the suggestion form and is told what fields are not acceptable
                return View("SuggestForm");
            }
        }

        //shows the user the suggestion 
        public IActionResult SuggestionList()
        { //returns the view while passing it all the current inputted suggestions
            return View(TempStorage.Suggestions);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
