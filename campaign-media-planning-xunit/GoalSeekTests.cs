using CampaignMediaPlanning.Utils;

namespace CampaignMediaPlanning.Tests
{
    public class GoalSeekTests
    {
        // Test Case 1: Normal Operation - GoalSeek finds the budget for Ad 3 within the tolerance
        [Fact]
        public void FindBudgetForAd3NormalCaseShouldReturnCorrectBudget()
        {
            // Arrange
            double tolerance = 0.01;
            double initialStep = 10;
            int maxIterations = 100;
            double campaignTotalBudget = 2135;
            double[] adBudgets = [100, 200, 400]; // X1, X2, X4 (Ad 3 budget is what we want to find)
            double agencyFeePercentage = 0.1;
            double thirdPartyToolFeesPercentage = 0.05;
            double fixedAgencyCosts = 1000;

            // Create a GoalSeek object and a Campaign object
            GoalSeek goalSeek = new(tolerance, initialStep, maxIterations, campaignTotalBudget, adBudgets, agencyFeePercentage, thirdPartyToolFeesPercentage, fixedAgencyCosts);
            Campaign campaign = new(new double[] { 100, 200, 300, 400 }, agencyFeePercentage, thirdPartyToolFeesPercentage, fixedAgencyCosts);

            // Act
            double result = goalSeek.FindBudgetForAd3();
            double calculatedBudget = campaign.CalculateTotalBudget();

            // Assert
            Assert.Equal(300, result); // The budget for Ad 3 should be 300
            Assert.Equal(campaignTotalBudget, calculatedBudget); // The total campaign budget should match the target budget
        }

        // Test Case 2: Convergence Test - GoalSeek should throw an exception if it doesn't converge becase of a small number of iterations
        [Fact]
        public void FindBudgetForAd3NonConvergingShouldThrowException()
        {
            // Arrange
            double tolerance = 0.01;
            double initialStep = 1000;
            int maxIterations = 10; // Small number of iterations to force non-convergence
            double campaignTotalBudget = 10000;
            double[] adBudgets = [300, 200, 400]; // X1, X2, X4
            double agencyFeePercentage = 0.1;
            double thirdPartyToolFeesPercentage = 0.05;
            double fixedAgencyCosts = 100;

            // Create a GoalSeek object
            GoalSeek goalSeek = new(tolerance, initialStep, maxIterations, campaignTotalBudget, adBudgets, agencyFeePercentage, thirdPartyToolFeesPercentage, fixedAgencyCosts);

            // Act & Assert
            Assert.Throws<Exception>(() => goalSeek.FindBudgetForAd3()); // Should throw an exception due to non-convergence
        }

        // Test Case 3: Edge Case - Zero tolerance
        [Fact]
        public void FindBudgetForAd3ZeroToleranceShouldThrowException()
        {
            // Arrange
            double tolerance = 0; // Zero tolerance means exact match required
            double initialStep = 10;
            int maxIterations = 100;
            double campaignTotalBudget = 1500;
            double[] adBudgets = [300, 200, 400]; // X1, X2, X4
            double agencyFeePercentage = 0.1;
            double thirdPartyToolFeesPercentage = 0.05;
            double fixedAgencyCosts = 100;

            // Create a GoalSeek object
            GoalSeek goalSeek = new(tolerance, initialStep, maxIterations, campaignTotalBudget, adBudgets, agencyFeePercentage, thirdPartyToolFeesPercentage, fixedAgencyCosts);

            // Act & Assert
            Assert.Throws<Exception>(() => goalSeek.FindBudgetForAd3()); // Should throw an exception due to zero tolerance
        }

        // Test Case 4: Small Initial Step - Should converge but take more iterations
        [Fact]
        public void FindBudgetForAd3SmallInitialStepShouldConvergeButSlower()
        {
            // Arrange
            double tolerance = 0.01;
            double initialStep = 1; // Very small step size
            int maxIterations = 1000; // Allow more iterations to accommodate the small step
            double campaignTotalBudget = 2135;
            double[] adBudgets = [100, 200, 400]; // X1, X2, X4
            double agencyFeePercentage = 0.1;
            double thirdPartyToolFeesPercentage = 0.05;
            double fixedAgencyCosts = 1000;

            // Create a GoalSeek object and a Campaign object
            GoalSeek goalSeek = new (tolerance, initialStep, maxIterations, campaignTotalBudget, adBudgets, agencyFeePercentage, thirdPartyToolFeesPercentage, fixedAgencyCosts);
            Campaign campaign = new(new double[] { 100, 200, 300, 400 }, agencyFeePercentage, thirdPartyToolFeesPercentage, fixedAgencyCosts);
            
            // Act
            double result = goalSeek.FindBudgetForAd3(); // Find the budget for Ad 3
            double calculatedBudget = campaign.CalculateTotalBudget(); // Calculate the total campaign budget

            // Assert
            Assert.Equal(300, result); // The budget for Ad 3 should be 300
            Assert.Equal(campaignTotalBudget, calculatedBudget); // The total campaign budget should match the target budget
        }

        // Test Case 5: Large Initial Step - Should converge faster or overshoot
        [Fact]
        public void FindBudgetForAd3LargeInitialStepShouldConvergeButFaster()
        {
            // Arrange
            double tolerance = 0.01;
            double initialStep = 1000; // Large step size
            int maxIterations = 100;
            double campaignTotalBudget = 2135;
            double[] adBudgets = [100, 200, 400]; // X1, X2, X4
            double agencyFeePercentage = 0.1;
            double thirdPartyToolFeesPercentage = 0.05;
            double fixedAgencyCosts = 1000;

            // Create a GoalSeek object and a Campaign object
            GoalSeek goalSeek = new (tolerance, initialStep, maxIterations, campaignTotalBudget, adBudgets, agencyFeePercentage, thirdPartyToolFeesPercentage, fixedAgencyCosts);
            Campaign campaign = new(new double[] { 100, 200, 300, 400 }, agencyFeePercentage, thirdPartyToolFeesPercentage, fixedAgencyCosts);
            
            // Act
            double result = goalSeek.FindBudgetForAd3(); // Find the budget for Ad 3
            double calculatedBudget = campaign.CalculateTotalBudget(); // Calculate the total campaign budget
            
            // Assert
            Assert.Equal(300, result); // The budget for Ad 3 should be 300
            Assert.Equal(campaignTotalBudget, calculatedBudget); // The total campaign budget should match the target budget
        }

        // Test Case 6: Invalid Inputs - Negative tolerance should throw an ArgumentException
        [Theory]
        [InlineData(-0.01, 10, 100, 1500)]
        [InlineData(0.01, -10, 100, 1500)]
        [InlineData(0.01, 10, -100, 1500)]
        public void ConstructorInvalidInputsShouldThrowArgumentException(double tolerance, double initialStep, int maxIterations, double campaignTotalBudget)
        {
            // Arrange
            double[] adBudgets = [300, 200, 400];
            double agencyFeePercentage = 0.1;
            double thirdPartyToolFeesPercentage = 0.05;
            double fixedAgencyCosts = 100;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new GoalSeek(tolerance, initialStep, maxIterations, campaignTotalBudget, adBudgets, agencyFeePercentage, thirdPartyToolFeesPercentage, fixedAgencyCosts)); // Should throw an ArgumentException due to invalid input
        }
    }
}