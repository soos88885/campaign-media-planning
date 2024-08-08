namespace CampaignMediaPlanning.Utils
{
    /// <summary>
    /// The GoalSeek class is used to determine the optimal budget for a specific ad (ad 3)
    /// in a campaign to match a target total campaign budget (Z).
    /// </summary>
    public class GoalSeek
    {
        /// <summary>
        /// The tolerance within which the calculated budget must fall to be considered a match.
        /// </summary>
        private double tolerance;

        /// <summary>
        /// The initial step size used to adjust the budget for ad 3 during the search process.
        /// </summary>
        private double initialStep;

        /// <summary>
        /// The maximum number of iterations allowed for the goal-seeking algorithm to find a solution.
        /// </summary>
        private int maxIterations;

        /// <summary>
        /// The target total campaign budget (Z) that the goal-seeking algorithm attempts to achieve.
        /// </summary>
        private double campaignTotalBudget;

        /// <summary>
        /// An array of ad budgets for the campaign. Ad 3 is not included, therefore, the third element represents the budget for ad 4 as the assignment looks for the ad 3 value.
        /// </summary>
        private double[] adBudgets;

        /// <summary>
        /// The percentage of the total ad spend that goes to the agency as a fee, represented as a decimal (Y1).
        /// </summary>
        private double agencyFeePercentage;

        /// <summary>
        /// The percentage of the total relevant ad spend (from specific ads) that goes to third-party tools as a fee, represented as a decimal (Y2).
        /// </summary>
        private double thirdPartyToolFeesPercentage;

        /// <summary>
        /// The fixed costs associated with the agency hours required for the campaign.
        /// </summary>
        private double fixedAgencyCosts;

        /// <summary>
        /// Initializes a new instance of the GoalSeek class with the specified parameters.
        /// </summary>
        /// <param name="tolerance">The tolerance within which the calculated budget must fall to be considered a match.</param>
        /// <param name="initialStep">The initial step size used to adjust the budget for ad 3.</param>
        /// <param name="maxIterations">The maximum number of iterations allowed for the goal-seeking algorithm.</param>
        /// <param name="campaignTotalBudget">The target total campaign budget (Z).</param>
        /// <param name="adBudgets">An array of ad budgets for the campaign. Ad 3 is not included, therefore, the third element represents the budget for ad 4.</param>
        /// <param name="agencyFeePercentage">The percentage of the total ad spend that goes to the agency as a fee (Y1).</param>
        /// <param name="thirdPartyToolFeesPercentage">The percentage of the total relevant ad spend that goes to third-party tools as a fee (Y2).</param>
        /// <param name="fixedAgencyCosts">The fixed costs associated with the agency hours required for the campaign.</param>
        public GoalSeek(double tolerance, double initialStep, int maxIterations, double campaignTotalBudget, double[] adBudgets, double agencyFeePercentage, double thirdPartyToolFeesPercentage, double fixedAgencyCosts)
        {
            this.tolerance = tolerance;
            this.initialStep = initialStep;
            this.maxIterations = maxIterations;
            this.campaignTotalBudget = campaignTotalBudget;
            this.adBudgets = adBudgets;
            this.agencyFeePercentage = agencyFeePercentage;
            this.thirdPartyToolFeesPercentage = thirdPartyToolFeesPercentage;
            this.fixedAgencyCosts = fixedAgencyCosts;
        }

        /// <summary>
        /// Attempts to find the optimal budget for ad 3 that matches the target total campaign budget (Z) using the goal-seeking algorithm.
        /// </summary>
        /// <returns>The calculated budget for ad 3 that brings the total campaign budget close to the target budget.</returns>
        /// <exception cref="Exception">Thrown if the goal-seeking algorithm does not converge within the maximum number of iterations.</exception>
        public double FindBudgetForAd3()
        {
            double step = initialStep; // Initialize step size for adjustments
            double budgetAd3 = 0; // Initialize budget for ad 3
            int iterations = 0; // Initialize iteration counter

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Goal Seek started...");
            Console.ResetColor();

            while (iterations < maxIterations)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Iteration: " + iterations);
                Console.ResetColor();

                // Create a new Campaign object with the current budgetAd3 value
                Campaign campaign = new Campaign(new double[] { adBudgets[0], adBudgets[1], budgetAd3, adBudgets[2] }, agencyFeePercentage, thirdPartyToolFeesPercentage, fixedAgencyCosts);
                double calculatedBudget = campaign.CalculateTotalBudget(); // Calculate the total campaign budget

                // Check if the calculated budget is within the tolerance of the target budget
                if (Math.Abs(calculatedBudget - campaignTotalBudget) <= tolerance)
                {
                    Console.WriteLine("Calculated budget for 3rd ad: " + budgetAd3);
                    return budgetAd3;
                }

                // Adjust the budget for ad 3 based on whether the calculated budget is below or above the target budget
                if (calculatedBudget < campaignTotalBudget)
                {
                    budgetAd3 += step; // Increase the budget for ad 3
                }
                else
                {
                    budgetAd3 -= step; // Decrease the budget for ad 3
                    step /= 10; // Reduce the step size for finer adjustments
                }

                iterations++;
            }

            // Throw an exception if the algorithm does not converge within the maximum number of iterations
            throw new Exception("Goal Seek did not converge.");
        }
    }
}
