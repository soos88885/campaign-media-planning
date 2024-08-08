namespace CampaignMediaPlanning.Utils
{
    /// <summary>
    /// The CampaignManager class is responsible for managing the user interaction, 
    /// gathering input for the campaign, running the GoalSeek algorithm, and outputting the results.
    /// </summary>
    public class CampaignManager
    {
        /// <summary>
        /// The Run method orchestrates the entire process:
        /// It prompts the user for all necessary input data, runs the GoalSeek algorithm, 
        /// and then displays the result.
        /// </summary>
        public static void Run()
        {


            // Get Campaign inputs from user
            double totalCampaignBudget = UserInput.InputTotalCampaignBudget(); // Prompt the user to enter the total campaign budget (Z)
            double agencyFeePercentage = UserInput.InputAgencyFeePercentage(); // Prompt the user to enter the agency fee percentage as a decimal (Y1)
            double thirdPartyToolFeePercentage = UserInput.InputThirdPartyToolFeePercentage(); // Prompt the user to enter the third-party tool fee percentage as a decimal (Y2)
            double fixedAgencyHoursCost = UserInput.InputFixedAgencyHoursCost(); // Prompt the user to enter the fixed cost for agency hours
            double[] adBudgets = UserInput.InputAdBudgets(3); // Prompt the user to enter the budgets for the ads (X1, X2, X4)

            // Display the entered data for verification
            Console.WriteLine("Entered data: " + totalCampaignBudget + " " + agencyFeePercentage + " " + thirdPartyToolFeePercentage + " " + fixedAgencyHoursCost + " " + adBudgets[0] + " " + adBudgets[1] + " " + adBudgets[2] + "\r\n");

            // Get GoalSeek inputs from user
            double tolerance = UserInput.InputTolerance(); // Prompt the user to enter the tolerance for the goal seek (typically 0.01)
            double initialStep = UserInput.InputInitialStep(); // Prompt the user to enter the initial step size for the goal seek
            int maxIterations = UserInput.InputMaxIterations(); // Prompt the user to enter the maximum number of iterations for the goal seek
            try
            {
                // Use GoalSeek to find the budget for ad 3
                GoalSeek goalSeek = new(tolerance, initialStep, maxIterations, totalCampaignBudget, adBudgets, agencyFeePercentage, thirdPartyToolFeePercentage, fixedAgencyHoursCost); // Create a new GoalSeek object
                double budgetAd3 = goalSeek.FindBudgetForAd3(); // Find the budget for the 3rd ad

                // Output the result
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"The maximum budget for the specific ad (X3) is: {budgetAd3:F2} euros");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                // Catch all exceptions and display an error message
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.ResetColor();
            }
        }
    }
}
