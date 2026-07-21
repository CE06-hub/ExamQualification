namespace ExamQualificationApp
{
    /// <summary>
    /// Console application that determines whether a student qualifies
    /// to write the final exam, based on a weighted average of four
    /// assessment marks:
    ///
    ///     Test 1        - 30%
    ///     Test 2        - 50%
    ///     Assignment 1  - 10%
    ///     Project       - 10%
    ///
    /// A student qualifies if the weighted average is >= 50.
    /// </summary>
    class Program
    {
        // Assessment weights (must sum to 1.0 / 100%)
        private const double Test1Weight = 0.30;
        private const double Test2Weight = 0.50;
        private const double Assignment1Weight = 0.10;
        private const double ProjectWeight = 0.10;

        // Minimum weighted average required to qualify for the exam
        private const double QualifyingMark = 50.0;

        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("   Exam Qualification Calculator");
            Console.WriteLine("========================================");
            Console.WriteLine();
            Console.WriteLine("Enter marks out of 100 for each assessment.");
            Console.WriteLine();

            double test1 = GetMark("Test 1 (weight 30%)");
            double test2 = GetMark("Test 2 (weight 50%)");
            double assignment1 = GetMark("Assignment 1 (weight 10%)");
            double project = GetMark("Project (weight 10%)");

            double weightedAverage = CalculateWeightedAverage(test1, test2, assignment1, project);

            DisplayResult(test1, test2, assignment1, project, weightedAverage);
        }

        /// <summary>
        /// Repeatedly prompts the user until a valid mark (0-100) is entered.
        /// </summary>
        private static double GetMark(string label)
        {
            while (true)
            {
                Console.Write($"  {label}: ");
                string? input = Console.ReadLine();

                if (double.TryParse(input, out double mark) && mark >= 0 && mark <= 100)
                {
                    return mark;
                }

                Console.WriteLine("    Invalid input. Please enter a number between 0 and 100.");
            }
        }

        /// <summary>
        /// Calculates the weighted average from the four assessment marks.
        /// </summary>
        private static double CalculateWeightedAverage(double test1, double test2, double assignment1, double project)
        {
            return (test1 * Test1Weight)
                 + (test2 * Test2Weight)
                 + (assignment1 * Assignment1Weight)
                 + (project * ProjectWeight);
        }

        /// <summary>
        /// Prints a breakdown of the calculation and the final qualification decision.
        /// </summary>
        private static void DisplayResult(double test1, double test2, double assignment1, double project, double weightedAverage)
        {
            Console.WriteLine();
            Console.WriteLine("----------------- Breakdown -----------------");
            Console.WriteLine(FormatRow("Assessment", "Mark", "Weight", "Contribution"));
            Console.WriteLine(FormatRow("Test 1", test1.ToString("F2"), "30%", (test1 * Test1Weight).ToString("F2")));
            Console.WriteLine(FormatRow("Test 2", test2.ToString("F2"), "50%", (test2 * Test2Weight).ToString("F2")));
            Console.WriteLine(FormatRow("Assignment 1", assignment1.ToString("F2"), "10%", (assignment1 * Assignment1Weight).ToString("F2")));
            Console.WriteLine(FormatRow("Project", project.ToString("F2"), "10%", (project * ProjectWeight).ToString("F2")));
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine($"Weighted Average: {weightedAverage:F2}");
            Console.WriteLine();

            if (weightedAverage >= QualifyingMark)
            {
                Console.WriteLine($"Result: QUALIFIES to write the exam (weighted average >= {QualifyingMark:F0}).");
            }
            else
            {
                Console.WriteLine($"Result: DOES NOT QUALIFY to write the exam (weighted average < {QualifyingMark:F0}).");
            }
        }

        /// <summary>
        /// Formats one row of the breakdown table using fixed-width columns.
        /// </summary>
        private static string FormatRow(string name, string mark, string weight, string contribution)
        {
            return name.PadRight(14) + mark.PadLeft(8) + weight.PadLeft(8) + contribution.PadLeft(14);
        }
    }
}

