using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakingApp
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of ingredients: ");
            int ingredientCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine($"\nIngredient {i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Quantity: ");
                double Quantity;
                while (!double.TryParse(Console.ReadLine(), out Quantity))
                {
                    Console.Write("Invalid input. Please enter a valid number for quantity: ");
                }
                Console.Write("Unit of measurement: ");
                string unit = Console.ReadLine();
            }

            Console.Write("\nEnter the number of steps: ");
            int stepCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < stepCount; i++)
            {
                Console.Write($"Step {i + 1}: ");
                string step = Console.ReadLine();
            }
        }
    }

}
 