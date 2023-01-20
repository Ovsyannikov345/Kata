using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2kyu_Parsing_and_evaluation_of_mathematical_expressions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Evaluation.Evaluate evaluate = new Evaluation.Evaluate();

            Console.WriteLine(evaluate.eval("--- 5* 2"));
            Console.WriteLine(evaluate.eval("2 * 3 + 2 & 2 * 4"));
            Console.WriteLine(evaluate.eval("5 -- 6"));
            Console.WriteLine(evaluate.eval("((2 + 3) * (1 + 2)) * 4 & 2"));
            Console.WriteLine(evaluate.eval("sqrt (sin(2 + 3)*cos (1+2)) * 4 & 2"));
            Console.WriteLine(evaluate.eval("sqrt (-2)"));
            Console.WriteLine(evaluate.eval("1/0"));
            Console.WriteLine(evaluate.eval("abs(-2 * 1e-3)"));
            Console.WriteLine(evaluate.eval("4 & 3 & 2"));
            Console.WriteLine(evaluate.eval("((2 + 3) * (1 + 2)) * 4 & -2"));
        }
    }
}

namespace Evaluation
{
    public class Evaluate
    {
        public static string ErrorMessage { get; } = "ERROR";

        public string eval(string expression)
        {
            // Removing double minuses and whitespaces.
            expression = expression.Replace("--", "").Replace(" ", "");

            if (!IsBracesValid(expression) || !IsOperatorsValid(expression))
            {
                return ErrorMessage;
            }

            expression = ReplaceExpNumbers(expression);

            if (expression.Contains('('))
            {
                expression = ProcessActionsInBraces(expression);
            }

            expression = ProcessMultipleActions(expression);

            return expression;
        }

        private static bool IsBracesValid(string expression)
        {
            int counter = 0;

            foreach (var symbol in expression)
            {
                if (symbol == '(')
                {
                    counter++;
                }
                else if (symbol == ')')
                {
                    counter--;

                    if (counter < 0)
                    {
                        return false;
                    }
                }
            }

            return counter == 0;
        }

        private static bool IsOperatorsValid(string expression)
        {
            string operatorErrorPattern = @"[^)^\d^e][+]|[^)^\d][*/&]";

            return Regex.Match(expression, operatorErrorPattern).Length == 0;
        }

        private static string ReplaceExpNumbers(string expression)
        {
            string expPattern = @"\de[+-]\d|\de\d";

            MatchCollection matches = Regex.Matches(expression, expPattern);

            foreach (Match match in matches)
            {
                expression = expression.Replace(match.Value, double.Parse(match.Value).ToString());
            }

            return expression;
        }

        private static string ProcessActionsInBraces(string expression)
        {
            string singleOperationPattern = @"(log|ln|exp|sqrt|abs|atan|acos|asin|sinh|cosh|tanh|tan|sin|cos|)[(]{1}[^(^)]*[)]{1}";

            Match operation = Regex.Match(expression, singleOperationPattern);

            while (operation.Success)
            {
                // operation
                string result = operation.Value[0] == '(' ? ProcessMultipleActions(operation.Value[1..^1]) : ProcessMultipleActions(operation.Value);

                // replacing
                expression = expression.Replace(operation.Value, result);

                // new operation
                operation = Regex.Match(expression, singleOperationPattern);
            }

            return expression;
        }

        private static string ProcessMultipleActions(string expression)
        {
            int braceIndex = expression.IndexOf('(');

            string function = braceIndex == -1 ? "" : expression.Substring(0, braceIndex);

            expression = braceIndex == -1 ? expression : expression.Substring(braceIndex + 1, expression.Length - braceIndex - 2);

            string powerPattern = @"\d+&\d+";

            Match operation = Regex.Match(expression, powerPattern, RegexOptions.RightToLeft);

            while (operation.Success)
            {
                string result = ProcessOperator(operation.Value);

                expression = expression.Replace(operation.Value, result);
                operation = Regex.Match(expression, powerPattern, RegexOptions.RightToLeft);
            }

            string multOrDivPattern = @"([-]|)\d+[*/]([-]|)\d+";

            operation = Regex.Match(expression, multOrDivPattern);

            while (operation.Success)
            {
                string result = ProcessOperator(operation.Value);

                expression = expression.Replace(operation.Value, result);
                operation = Regex.Match(expression, multOrDivPattern);
            }

            string sumOrSubtractPattern = @"([-]|)\d+[+-]([-]|)\d+";

            operation = Regex.Match(expression, sumOrSubtractPattern);

            while (operation.Success)
            {
                string result = ProcessOperator(operation.Value);

                expression = expression.Replace(operation.Value, result);
                operation = Regex.Match(expression, sumOrSubtractPattern);
            }

            if (function != "")
            {
                expression = ProcessFuction(function, expression);
            }

            return expression;
        }

        private static string ProcessOperator(string expression)
        {
            char[] operators = { '&', '*', '/', '+', '-' };

            int operatorIndex = 0;

            foreach (char op in operators)
            {
                if (expression.Contains(op))
                {
                    operatorIndex = expression.LastIndexOf(op);
                    break;
                }
            }

            double x = double.Parse(expression[..operatorIndex]);

            double y = double.Parse(expression[(operatorIndex + 1)..]);

            double result = 0;

            switch (expression[operatorIndex])
            {
                case '+':
                    result = x + y;
                    break;
                case '-':
                    result = x - y;
                    break;
                case '*':
                    result = x * y;
                    break;
                case '/':
                    if (y == 0)
                    {
                        throw new DivideByZeroException();
                    }

                    result = x / y;
                    break;
                case '&':
                    result = Math.Pow(x, y);
                    break;
            }

            return result.ToString();
        }

        private static string ProcessFuction(string function, string expression)
        {
            double x = double.Parse(expression);
            
            double result = 0;

            switch (function)
            {
                case "log":
                    result = Math.Log10(x);
                    break;
                case "ln":
                    result = Math.Log(x);
                    break;
                case "exp":
                    result = Math.Exp(x);
                    break;
                case "sqrt":
                    result = Math.Sqrt(x);
                    break;
                case "abs":
                    result = Math.Abs(x);
                    break;
                case "atan":
                    result = Math.Atan(x);
                    break;
                case "acos":
                    result = Math.Acos(x);
                    break;
                case "asin":
                    result = Math.Asin(x);
                    break;
                case "sinh":
                    result = Math.Sinh(x);
                    break;
                case "cosh":
                    result = Math.Cosh(x);
                    break;
                case "tanh":
                    result = Math.Tanh(x);
                    break;
                case "tan":
                    result = Math.Tan(x);
                    break;
                case "sin":
                    result = Math.Sin(x);
                    break;
                case "cos":
                    result = Math.Cos(x);
                    break;
            }

            return result.ToString();
        }
    }
}