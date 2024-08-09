using CampaignMediaPlanning.Utils;

namespace CampaignMediaPlanning.Tests
{

    public class CampaignTests
    {
        // Test Case 1: Normal Operation - Campaign calculates the total budget correctly
        [Fact]
        public void ConstructorValidInputsShouldInitializeCorrectly()
        {
            // Arrange
            double[] adBudgets = [1000, 2000, 3000, 4000];
            double agencyFeePercentage = 0.1;
            double thirdPartyToolFeesPercentage = 0.2;
            double fixedAgencyCosts = 500;

            // Act
            Campaign campaign = new(adBudgets, agencyFeePercentage, thirdPartyToolFeesPercentage, fixedAgencyCosts);

            // Assert
            Assert.NotNull(campaign);
        }

        // Test Case 2: Invalid Inputs - Campaign throws an exception when initialized with invalid inputs
        [Theory]
        [InlineData(null, 0.1, 0.2, 500)] // Null adBudgets
        [InlineData(new double[] { }, 0.1, 0.2, 500)] // Empty adBudgets
        [InlineData(new double[] { 1000, 2000, 300 }, -0.1, 0.2, 500)] // Invalid agencyFeePercentage
        [InlineData(new double[] { 1000 }, 0.1, -0.2, 500)] // Invalid thirdPartyToolFeesPercentage
        [InlineData(new double[] { 1000 }, 0.1, 0.2, -500)] // Invalid fixedAgencyCosts
        [InlineData(new double[] { -1000 }, 0.1, 0.2, 500)] // Negative adBudget
        public void ConstructorInvalidInputsShouldThrowArgumentException(double[] adBudgets, double agencyFeePercentage, double thirdPartyToolFeesPercentage, double fixedAgencyCosts)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Campaign(adBudgets, agencyFeePercentage, thirdPartyToolFeesPercentage, fixedAgencyCosts));
        }

        // Test Case 3: Normal Operation - CalculateTotalBudget should return the correct sum
        [Fact]
        public void CalculateTotalAdBudgetShouldReturnCorrectSum()
        {
            // Arrange
            double[] adBudgets = [100, 200, 300, 400];
            double expectedTotal = 2135;
            Campaign campaign = new(adBudgets, 0.1, 0.05, 1000);

            // Act
            double totalAdBudget = campaign.CalculateTotalBudget();

            // Assert
            Assert.Equal(expectedTotal, totalAdBudget);
        }

        // Test Case 4: Invalid Inputs - Campaign throws an exception when CalculateTotalBudget is called with invalid inputs (Empty adBudget)
        [Fact]
        public void ThrowErrorWhenEmptyAdBudgets()
        {
            // Arrange
            double[] adBudgets = [];

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Campaign(adBudgets, 0.1, 0.05, 1000));
        }

        // Test Case 5: Invalid Inputs - Campaign throws an exception when CalculateTotalBudget is called with invalid inputs (Null adBudget)
        [Fact]
        public void ThrowErrorWhenNullAdBudgets()
        {
            // Arrange
            double[]? adBudgets = null;

            // Act & Assert
            _ = Assert.Throws<ArgumentException>(() => new Campaign(adBudgets, 0.1, 0.05, 1000));
        }

        // Test Case 6: Invalid Inputs - Campaign throws an exception when CalculateTotalBudget is called with invalid inputs (Negative adBudget)
        [Fact]
        public void ThrowErrorWhenNegativeBudget()
        {
            // Arrange
            double[] adBudgets = [-100, 200, 300, 400];

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Campaign(adBudgets, 0.1, 0.05, 1000));
        }

        // Test Case 7: Invalid Inputs - Campaign throws an exception when CalculateTotalBudget is called with invalid inputs (Negative agencyFeePercentage)
        [Fact]
        public void ThrowErrorWhenAgencyFeePercentageIsNegative()
        {
            // Arrange
            double[] adBudgets = [100, 200, 300, 400];

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Campaign(adBudgets, -0.1, 0.05, 1000));
        }

        // Test Case 8: Invalid Inputs - Campaign throws an exception when CalculateTotalBudget is called with invalid inputs (Negative thirdPartyToolFeesPercentage)
        [Fact]
        public void ThrowErrorWhenThreePartyToolFeesPercentageIsNegative()
        {
            // Arrange
            double[] adBudgets = [100, 200, 300, 400];

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Campaign(adBudgets, 0.1, -0.05, 1000));
        }

        // Test Case 9: Invalid Inputs - Campaign throws an exception when CalculateTotalBudget is called with invalid inputs (Negative fixedAgencyCosts)
        [Fact]
        public void ThrowErrorWhenFixedAgencyCostsIsNegative()
        {
            // Arrange
            double[] adBudgets = [100, 200, 300, 400];

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Campaign(adBudgets, 0.1, 0.05, -1000));
        }

        // Test Case 10: Normal Operation - CalculateTotalBudget should return the correct sum with zero agency percentage
        [Fact]
        public void CalculateTotalAdBudgetShouldReturnCorrectSumWithZeroAgencyPercentage()
        {
            // Arrange
            double[] adBudgets = [100, 200, 300, 400];
            double expectedTotal = 2035;
            Campaign campaign = new(adBudgets, 0, 0.05, 1000);

            // Act
            double totalAdBudget = campaign.CalculateTotalBudget();

            // Assert
            Assert.Equal(expectedTotal, totalAdBudget);
        }

        // Test Case 11: Normal Operation - CalculateTotalBudget should return the correct sum with zero third party tool fees percentage
        [Fact]
        public void CalculateTotalAdBudgetShouldReturnCorrectSumWithZeroThirdPartyToolFeesPercentage()
        {
            // Arrange
            double[] adBudgets = [100, 200, 300, 400];
            double expectedTotal = 2100;
            Campaign campaign = new(adBudgets, 0.1, 0, 1000);

            // Act
            double totalAdBudget = campaign.CalculateTotalBudget();

            // Assert
            Assert.Equal(expectedTotal, totalAdBudget);
        }
    }
}