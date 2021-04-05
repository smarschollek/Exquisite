using System.Collections.Generic;
using Exquisite.BusinessLogic.Entities;

namespace Exquisite.BusinessLogic.RecipeManagement.Models
{
    public class AllRecipesResponse
    {
        public ICollection<Recipe> Recipes { get; set; }
    }
}