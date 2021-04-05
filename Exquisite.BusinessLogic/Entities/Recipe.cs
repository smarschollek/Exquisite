using System;
using System.Collections.Generic;

namespace Exquisite.BusinessLogic.Entities
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public ICollection<string> Labels { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public string Instructions { get; set; }
    }
}