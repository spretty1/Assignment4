using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assignment4.Models
{
    public class SuggestionCollection
    {
        //setting the different forms of data with some being required and the notes not being allowed to be longer than a certain length

        [Required(ErrorMessage = "Your name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Restaurant name is required.")]
        public string RestaurantName { get; set; }

        [Required(ErrorMessage = "Your favorite dish is required.")]
        public string FavDish { get; set; }

        //Makes sure the phone number is valid 
        [Required(ErrorMessage = "The restaurant phone number is required."), DataType(DataType.PhoneNumber), 
            RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
            ErrorMessage = "Entered phone format is not valid.")]
        public string RestaurantPhoneNum { get; set; }

    }
}
