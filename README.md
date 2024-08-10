## Requirements

To get started with the project, make sure you have the following requirements installed:

- The latest stable version of .NET framework (.NET 8.0 at the time of the writing)
- Visual Studio Code
- C# development kit extension in VS Code

## NOTE
The assignment can be found [here](https://gist.githubusercontent.com/stasyess/3993a26c58b26ed36300ca4ed359eb06/raw/a991d119136b1e1893ea0f6a48afdeb42fd2dcd4/Assignment.txt).
The assignment suggested to use the following formula to calculate the total budget:

```
Z = X + Z * X + Y1 * X + Y2 * (X1 + X2 + X4) + HOURS
```

However, the suggested formula uses circular dependency for the variable Z which is the total budget.
This means that Z is defined in terms of itself, which makes it impossible to solve directly without rearranging the formula. This circular reference makes it unclear how to actually compute Z. There is no clear path to calculating Z without already knowing Z, which is not possible. Therefore, an optimized formula is implemented which is more likely to be the actual formula:

```
Z = X + Y1 * X + Y2 * (X1 + X2 + X4) + HOURS
```

Using the modified formula, it is possible to calculate the total campaign budget.

## Installation

To install the project, follow these steps in the Visual Studio Code terminal:

1. Clone the repository to your local machine:

   ```
   git clone https://github.com/soos88885/campaign-media-planning.git
   ```

2. After the repository is cloned, navigate to VS Code and open the project's folder (campaign-media-planning). This is an important step to properly setup the project!

3. When the project is successfully opened in VS Code, use the editor's inbuilt terminal and run the project with the following command (make sure that the terminal is navigated to the project's folder):

   ```
   dotnet run
   ```
4. In the terminal the application starts asking the user to provide the necessary input values for the Goal Seek functionality.

## Use of the application
To interact with the program, the user will be prompted with a series of questions through the VS Code terminal. Here are the questions the application is going to ask and how the user should react:

   1. Enter the total campaign budget (positive number):

      - The user should enter a positive number representing the total campaign budget.

   2. Enter the agency fee percentage (as a decimal between 0 and 1):

      - The user should enter a decimal number between 0 and 1 representing the agency fee percentage.

   3. Enter the third-party tool fee percentage (as a decimal between 0 and 1):

      - The user should enter a decimal number between 0 and 1 representing the third-party tool fee percentage.

   4. Enter the fixed cost for agency hours (positive number):

      - The user should enter a positive number representing the fixed cost for agency hours.

   5. Enter the budget for ad 1 (positive number):

      - The user should enter a positive number representing the budget for the first ad.

   6. Enter the budget for ad 2 (positive number):

      - The user should enter a positive number representing the budget for the second ad.

   7. A note appears saying "Note: Ad3 budget will be calculated by GoalSeek."

   8. Enter the budget for ad 4 (positive number):

      - The user should enter a positive number representing the budget for the second ad.

   9. Enter the tolerance for GoalSeek (small positive number, e.g., 0.01):

      - The user should enter a small positive number representing the tolerance for the GoalSeek algorithm.

   10. Enter the initial step for GoalSeek (positive number, e.g., 10):

      - The user should enter a positive number representing the initial step for the GoalSeek algorithm.

   11. Enter the maximum iterations for GoalSeek (positive integer):

       - The user should enter a positive integer representing the maximum number of iterations for the GoalSeek algorithm.

   The user should provide valid inputs for each question to ensure the program runs correctly. Invalid input's result in throwing errors that are handled with different error handling methods taking into account the type of the errors and when did they occured.

   To abort the process press CTRL + C.

## Test cases
Test cases can be found by opening the 'Testing' button on the VS Code Sidebar. To run a test case or group of tests, click on the corresponding run icon next to the test name.