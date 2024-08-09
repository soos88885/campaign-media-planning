using System;

namespace CampaignMediaPlanning.Utils
{
    /// <summary>
    /// The UserInput class handles the input of various parameters required for the campaign and goal seek process from the console.
    /// It includes error handling to ensure valid inputs are provided by the user.
    /// </summary>
    public class UserInput
    {
        /// <summary>
        /// Prompts the user to enter the total campaign budget.
        /// </summary>
        /// <returns>A double representing the total campaign budget.</returns>
        /// <exception cref="FormatException">Thrown when the input is not a valid number.</exception>
        /// <exception cref="OverflowException">Thrown when the input number is too large.</exception>
        /// <remarks>
        /// The method will keep prompting the user until a positive number is entered.
        /// </remarks>
        public static double InputTotalCampaignBudget()
        {
            while (true)
            {
                Console.WriteLine("Enter the total campaign budget (positive number):");
                try
                {
                    double budget = Convert.ToDouble(Console.ReadLine());
                    if (budget <= 0)
                    {
                        Console.WriteLine("Error: Total campaign budget must be a positive number.");
                        continue;
                    }
                    return budget;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Invalid input. Please enter a valid number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Error: The number is too large. Please enter a smaller number.");
                }
            }
        }

        /// <summary>
        /// Prompts the user to enter the agency fee percentage.
        /// </summary>
        /// <returns>A double representing the agency fee percentage as a decimal.</returns>
        /// <exception cref="FormatException">Thrown when the input is not a valid decimal number.</exception>
        /// <exception cref="OverflowException">Thrown when the input number is too large.</exception>
        /// <remarks>
        /// The method will keep prompting the user until a number between 0 and 1 is entered.
        /// </remarks>
        public static double InputAgencyFeePercentage()
        {
            while (true)
            {
                Console.WriteLine("Enter the agency fee percentage (as a decimal between 0 and 1):");
                try
                {
                    double fee = Convert.ToDouble(Console.ReadLine());
                    if (fee < 0 || fee > 1)
                    {
                        Console.WriteLine("Error: Agency fee percentage must be between 0 and 1.");
                        continue;
                    }
                    return fee;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Invalid input. Please enter a valid decimal number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Error: The number is too large. Please enter a smaller number.");
                }
            }
        }

        /// <summary>
        /// Prompts the user to enter the third-party tool fee percentage.
        /// </summary>
        /// <returns>A double representing the third-party tool fee percentage as a decimal.</returns>
        /// <exception cref="FormatException">Thrown when the input is not a valid decimal number.</exception>
        /// <exception cref="OverflowException">Thrown when the input number is too large.</exception>
        /// <remarks>
        /// The method will keep prompting the user until a number between 0 and 1 is entered.
        /// </remarks>
        public static double InputThirdPartyToolFeePercentage()
        {
            while (true)
            {
                Console.WriteLine("Enter the third-party tool fee percentage (as a decimal between 0 and 1):");
                try
                {
                    double fee = Convert.ToDouble(Console.ReadLine());
                    if (fee < 0 || fee > 1)
                    {
                        Console.WriteLine("Error: Third-party tool fee percentage must be between 0 and 1.");
                        continue;
                    }
                    return fee;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Invalid input. Please enter a valid decimal number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Error: The number is too large. Please enter a smaller number.");
                }
            }
        }

        /// <summary>
        /// Prompts the user to enter the fixed cost for agency hours.
        /// </summary>
        /// <returns>A double representing the fixed cost for agency hours.</returns>
        /// <exception cref="FormatException">Thrown when the input is not a valid number.</exception>
        /// <exception cref="OverflowException">Thrown when the input number is too large.</exception>
        /// <remarks>
        /// The method will keep prompting the user until a non-negative number is entered.
        /// </remarks>
        public static double InputFixedAgencyHoursCost()
        {
            while (true)
            {
                Console.WriteLine("Enter the fixed cost for agency hours (positive number):");
                try
                {
                    double cost = Convert.ToDouble(Console.ReadLine());
                    if (cost < 0)
                    {
                        Console.WriteLine("Error: Fixed agency hours cost must be a non-negative number.");
                        continue;
                    }
                    return cost;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Invalid input. Please enter a valid number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Error: The number is too large. Please enter a smaller number.");
                }
            }
        }

        /// <summary>
        /// Prompts the user to enter the budgets for the ads.
        /// </summary>
        /// <param name="numberOfAds">The number of ads in the campaign.</param>
        /// <returns>An array of doubles representing the budgets for each ad.</returns>
        /// <exception cref="FormatException">Thrown when the input is not a valid number.</exception>
        /// <exception cref="OverflowException">Thrown when the input number is too large.</exception>
        /// <remarks>
        /// The method will keep prompting the user until a positive number is entered for each ad budget.
        /// The budget for the third ad will be calculated by the GoalSeek process, so no input is required.
        /// </remarks>
        public static double[] InputAdBudgets(int numberOfAds)
        {
            double[] adBudgets = new double[numberOfAds];
            for (int i = 0; i < adBudgets.Length; i++)
            {
                while (true)
                {
                    if (i == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Note: Ad3 budget will be calculated by GoalSeek.");
                        Console.ResetColor();
                    }

                    Console.WriteLine($"Enter the budget for ad {i + 1} (positive number):");
                    try
                    {
                        double budget = Convert.ToDouble(Console.ReadLine());
                        if (budget < 0)
                        {
                            Console.WriteLine("Error: Ad budget must be a non-negative number.");
                            continue;
                        }
                        adBudgets[i] = budget;
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error: Invalid input. Please enter a valid number.");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Error: The number is too large. Please enter a smaller number.");
                    }
                }
            }
            return adBudgets;
        }

        /// <summary>
        /// Prompts the user to enter the tolerance for the GoalSeek algorithm.
        /// </summary>
        /// <returns>A double representing the tolerance for the GoalSeek algorithm.</returns>
        /// <exception cref="FormatException">Thrown when the input is not a valid number.</exception>
        /// <exception cref="OverflowException">Thrown when the input number is too large.</exception>
        /// <remarks>
        /// The method will keep prompting the user until a positive number is entered.
        /// </remarks>
        public static double InputTolerance()
        {
            while (true)
            {
                Console.WriteLine("Enter the tolerance for GoalSeek (small positive number, e.g., 0.01):");
                try
                {
                    double tolerance = Convert.ToDouble(Console.ReadLine());
                    if (tolerance <= 0)
                    {
                        Console.WriteLine("Error: Tolerance must be a positive number.");
                        continue;
                    }
                    return tolerance;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Invalid input. Please enter a valid number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Error: The number is too large. Please enter a smaller number.");
                }
            }
        }

        /// <summary>
        /// Prompts the user to enter the initial step for the GoalSeek algorithm.
        /// </summary>
        /// <returns>A double representing the initial step for the GoalSeek algorithm.</returns>
        /// <exception cref="FormatException">Thrown when the input is not a valid number.</exception>
        /// <exception cref="OverflowException">Thrown when the input number is too large.</exception>
        /// <remarks>
        /// The method will keep prompting the user until a positive number is entered.
        /// </remarks>
        public static double InputInitialStep()
        {
            while (true)
            {
                Console.WriteLine("Enter the initial step for GoalSeek (positive number, e.g., 10):");
                try
                {
                    double step = Convert.ToDouble(Console.ReadLine());
                    if (step <= 0)
                    {
                        Console.WriteLine("Error: Initial step must be a positive number.");
                        continue;
                    }
                    return step;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Invalid input. Please enter a valid number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Error: The number is too large. Please enter a smaller number.");
                }
            }
        }

        /// <summary>
        /// Prompts the user to enter the maximum number of iterations for the GoalSeek algorithm.
        /// </summary>
        /// <returns>An integer representing the maximum number of iterations for the GoalSeek algorithm.</returns>
        /// <exception cref="FormatException">Thrown when the input is not a valid integer.</exception>
        /// <exception cref="OverflowException">Thrown when the input number is too large.</exception>
        /// <remarks>
        /// The method will keep prompting the user until a positive integer is entered.
        /// </remarks>
        public static int InputMaxIterations()
        {
            while (true)
            {
                Console.WriteLine("Enter the maximum iterations for GoalSeek (positive integer):");
                try
                {
                    int iterations = Convert.ToInt32(Console.ReadLine());
                    if (iterations <= 0)
                    {
                        Console.WriteLine("Error: Maximum iterations must be a positive integer.");
                        continue;
                    }
                    return iterations;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Invalid input. Please enter a valid integer.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Error: The number is too large. Please enter a smaller number.");
                }
            }
        }
    }
}
