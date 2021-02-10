using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment4.Models
{
    public class TempStorage
    {   //creates and holds the suggestions
        private static List<SuggestionCollection> suggestions = new List<SuggestionCollection>();
        public static IEnumerable<SuggestionCollection> Suggestions => suggestions;
        public static void AddSuggestion(SuggestionCollection application)
        {
            suggestions.Add(application);
        }
    }
}
