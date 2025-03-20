using System;
using System.Collections.Generic;
using System.Linq;

namespace BakingApp
{
    internal class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<string> Steps { get; set; } = new List<string>();

        public int TotalCalories => Ingredients.Sum(i => i.Calories);
    }

    internal class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }
    }

    internal class Program
    {
        static List<Recipe> recipes = new List<Recipe>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n1. Add Recipe\n2. View Recipes\n3. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddRecipe();
                        break;
                    case "2":
                        ViewRecipes();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddRecipe()
        {
            Recipe recipe = new Recipe();
            Console.Write("Enter recipe name: ");
            recipe.Name = Console.ReadLine();

            Console.Write("Enter number of ingredients: ");
            int ingredientCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < ingredientCount; i++)
            {
                Ingredient ingredient = new Ingredient();
                Console.WriteLine($"\nIngredient {i + 1}:");
                Console.Write("Name: ");
                ingredient.Name = Console.ReadLine();
                Console.Write("Quantity: ");
                ingredient.Quantity = double.Parse(Console.ReadLine());
                Console.Write("Unit of measurement: ");
                ingredient.Unit = Console.ReadLine();
                Console.Write("Calories: ");
                ingredient.Calories = int.Parse(Console.ReadLine());
                Console.Write("Food group: ");
                ingredient.FoodGroup = Console.ReadLine();

                recipe.Ingredients.Add(ingredient);
            }

            Console.Write("Enter number of steps: ");
            int stepCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < stepCount; i++)
            {
                Console.Write($"Step {i + 1}: ");
                recipe.Steps.Add(Console.ReadLine());
            }

            recipes.Add(recipe);
            Console.WriteLine("Recipe added successfully!");
        }

        static void ViewRecipes()
        {
            if (!recipes.Any())
            {
                Console.WriteLine("No recipes available.");
                return;
            }

            var sortedRecipes = recipes.OrderBy(r => r.Name).ToList();
            Console.WriteLine("\nRecipes:");
            for (int i = 0; i < sortedRecipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {sortedRecipes[i].Name}");
            }

            Console.Write("Choose a recipe number to view details: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= sortedRecipes.Count)
            {
                DisplayRecipe(sortedRecipes[choice - 1]);
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        static void DisplayRecipe(Recipe recipe)
        {
            Console.WriteLine($"\nRecipe: {recipe.Name}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"- {ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}, {ingredient.Calories} cal, {ingredient.FoodGroup}");
            }
            Console.WriteLine("Steps:");
            for (int i = 0; i < recipe.Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipe.Steps[i]}");
            }
            Console.WriteLine($"Total Calories: {recipe.TotalCalories}");
            if (recipe.TotalCalories > 300)
            {
                Console.WriteLine("Warning: This recipe exceeds 300 calories!");
            }
        }
    }
}
