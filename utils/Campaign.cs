namespace CampaignMediaPlanning.Utils
{
    /// <summary>
    /// The Campaign class encapsulates the financial aspects of an ad campaign, 
    /// including ad budgets, agency fees, third-party tool fees, and fixed agency costs.
    /// It provides methods to calculate the total ad spend and the overall campaign budget.
    /// </summary>
    public class Campaign
    {
        /// <summary>
        /// An array containing the budget for each ad in the campaign.
        /// </summary>
        private double[] adBudgets;

        /// <summary>
        /// The total ad spend for the campaign, calculated as the sum of all ad budgets.
        /// </summary>
        private double totalAdSpend;

        /// <summary>
        /// The percentage of the total ad spend that goes to the agency as a fee, represented as a decimal (e.g., 0.1 for 10%).
        /// </summary>
        private double agencyFeePercentage;

        /// <summary>
        /// The percentage of the total relevant ad spend (from specific ads) that goes to third-party tools as a fee, represented as a decimal.
        /// </summary>
        private double thirdPartyToolFeesPercentage;

        /// <summary>
        /// The fixed costs associated with the agency hours required for the campaign.
        /// </summary>
        private double fixedAgencyCosts;

        /// <summary>
        /// Initializes a new instance of the Campaign class with the provided ad budgets, 
        /// agency fee percentage, third-party tool fees percentage, and fixed agency costs.
        /// </summary>
        /// <param name="adBudgets">An array of budgets for each ad in the campaign.</param>
        /// <param name="agencyFeePercentage">The agency fee percentage as a decimal.</param>
        /// <param name="thirdPartyToolFeesPercentage">The third-party tool fee percentage as a decimal.</param>
        /// <param name="fixedAgencyCosts">The fixed costs for agency hours.</param>
        public Campaign(double[] adBudgets, double agencyFeePercentage, double thirdPartyToolFeesPercentage, double fixedAgencyCosts)
        {
            if (adBudgets == null || adBudgets.Length == 0 || adBudgets.Any(budget => budget < 0))
            {
                throw new ArgumentException("Ad budgets must be provided.");
            }

            if (agencyFeePercentage < 0 || agencyFeePercentage > 1)
            {
                throw new ArgumentException("Agency fee percentage must be between 0 and 1.");
            }

            if (thirdPartyToolFeesPercentage < 0 || thirdPartyToolFeesPercentage > 1)
            {
                throw new ArgumentException("Third-party tool fee percentage must be between 0 and 1.");
            }

            if (fixedAgencyCosts < 0)
            {
                throw new ArgumentException("Fixed agency costs must be a non-negative number.");
            }

            this.adBudgets = adBudgets;
            this.agencyFeePercentage = agencyFeePercentage;
            this.thirdPartyToolFeesPercentage = thirdPartyToolFeesPercentage;
            this.fixedAgencyCosts = fixedAgencyCosts;
            this.totalAdSpend = CalculateTotalAdBudget();
        }

        /// <summary>
        /// Calculates the total ad budget (X) by summing the budgets of all individual ads.
        /// </summary>
        /// <returns>The total ad budget, representing the total ad spend (X) for the campaign.</returns>
        private double CalculateTotalAdBudget()
        {
            double totalAdBudget = 0;

            // Sum up the budgets for all ads in the campaign
            foreach (double adBudget in adBudgets)
            {
                totalAdBudget += adBudget;
            }

            // Store the result as the total ad spend (X)
            totalAdSpend = totalAdBudget;

            Console.WriteLine("Total Ad Spend (X): " + totalAdSpend);
            return totalAdBudget;
        }

        /// <summary>
        /// Calculates the agency fee, which is a percentage of the total ad spend.
        /// </summary>
        /// <returns>The agency fee, calculated as totalAdSpend * agencyFeePercentage (X * Y1).</returns>
        private double CalculateAgencyFee()
        {
            double agencyFee = totalAdSpend * agencyFeePercentage;
            Console.WriteLine("Agency Fee (X * Y1): " + agencyFee);
            return agencyFee;
        }

        /// <summary>
        /// Calculates the fees associated with third-party tools, based on the budgets of specific ads.
        /// </summary>
        /// <param name="x1">The budget for the first ad (X1).</param>
        /// <param name="x2">The budget for the second ad (X2).</param>
        /// <param name="x4">The budget for the fourth ad (X4).</param>
        /// <returns>The third-party tool fees, calculated as (X1 + X2 + X4) * thirdPartyToolFeesPercentage.</returns>
        private double CalculateThirdPartyToolFees(double x1, double x2, double x4)
        {
            double thirdPartyToolFees = (x1 + x2 + x4) * thirdPartyToolFeesPercentage;
            Console.WriteLine("Third Party Tool Fees ((X1 + X2 + X4) * Y2): " + thirdPartyToolFees);
            return thirdPartyToolFees;
        }

        /// <summary>
        /// Calculates the total campaign budget (Z), which includes the total ad spend, 
        /// agency fees, third-party tool fees, and fixed agency costs.
        /// </summary>
        /// <returns>The total campaign budget (Z).</returns>
        public double CalculateTotalBudget()
        {
            double agencyFee = CalculateAgencyFee(); // Calculate agency fee
            double thirdPartyToolFees = CalculateThirdPartyToolFees(adBudgets[0], adBudgets[1], adBudgets[3]); // Calculate third-party tool fees

            // Sum the total ad spend, agency fee, third-party tool fees, and fixed agency costs to get the total budget (Z)
            double totalBudget = totalAdSpend + agencyFee + thirdPartyToolFees + fixedAgencyCosts;

            Console.WriteLine("Total Budget (Z): " + totalBudget + "\r\n");
            return totalBudget;
        }
    }
}
