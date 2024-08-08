namespace CampaignMediaPlanning.Utils
{
    /// <summary>
    /// The UserInput class handles the input of various parameters required for the campaign and goal seek process from the console.
    /// </summary>
    public class UserInput
    {
        /// <summary>
        /// Prompts the user to enter the total campaign budget.
        /// </summary>
        /// <returns>A double representing the total campaign budget.</returns>
        public static double InputTotalCampaignBudget()
        {
            Console.WriteLine("Enter the total campaign budget:");
            return Convert.ToDouble(Console.ReadLine());
        }

        /// <summary>
        /// Prompts the user to enter the agency fee percentage.
        /// </summary>
        /// <returns>A double representing the agency fee percentage as a decimal.</returns>
        public static double InputAgencyFeePercentage()
        {
            Console.WriteLine("Enter the agency fee percentage (as a decimal):");
            return Convert.ToDouble(Console.ReadLine());
        }

        /// <summary>
        /// Prompts the user to enter the third-party tool fee percentage.
        /// </summary>
        /// <returns>A double representing the third-party tool fee percentage as a decimal.</returns>
        public static double InputThirdPartyToolFeePercentage()
        {
            Console.WriteLine("Enter the third-party tool fee percentage (as a decimal):");
            return Convert.ToDouble(Console.ReadLine());
        }

        /// <summary>
        /// Prompts the user to enter the fixed cost for agency hours.
        /// </summary>
        /// <returns>A double representing the fixed cost for agency hours.</returns>
        public static double InputFixedAgencyHoursCost()
        {
            Console.WriteLine("Enter the fixed cost for agency hours:");
            return Convert.ToDouble(Console.ReadLine());
        }

        /// <summary>
        /// Prompts the user to enter the budgets for the ads.
        /// </summary>
        /// <param name="numberOfAds">The number of ads in the campaign.</param>
        /// <returns>An array of doubles representing the budgets for each ad.</returns>
        public static double[] InputAdBudgets(int numberOfAds)
        {
            double[] adBudgets = new double[numberOfAds];
            for (int i = 0; i < adBudgets.Length; i++)
            {
                if (i == 2)
                {
                    Console.WriteLine("Ad3 budget will be calculated by GoalSeek.");
                    Console.WriteLine($"Enter the budget for ad {i + 2}:");
                }
                else
                {
                    Console.WriteLine($"Enter the budget for ad {i + 1}:");
                }

                adBudgets[i] = Convert.ToDouble(Console.ReadLine());
            }
            return adBudgets;
        }

        /// <summary>
        /// Prompts the user to enter the tolerance for the GoalSeek algorithm.
        /// </summary>
        /// <returns>A double representing the tolerance for the GoalSeek algorithm.</returns>
        public static double InputTolerance()
        {
            Console.WriteLine("Enter the tolerance for GoalSeek:");
            return Convert.ToDouble(Console.ReadLine());
        }

        /// <summary>
        /// Prompts the user to enter the initial step for the GoalSeek algorithm.
        /// </summary>
        /// <returns>A double representing the initial step for the GoalSeek algorithm.</returns>
        public static double InputInitialStep()
        {
            Console.WriteLine("Enter the initial step for GoalSeek:");
            return Convert.ToDouble(Console.ReadLine());
        }

        /// <summary>
        /// Prompts the user to enter the maximum number of iterations for the GoalSeek algorithm.
        /// </summary>
        /// <returns>An integer representing the maximum number of iterations for the GoalSeek algorithm.</returns>
        public static int InputMaxIterations()
        {
            Console.WriteLine("Enter the maximum iterations for GoalSeek:");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}