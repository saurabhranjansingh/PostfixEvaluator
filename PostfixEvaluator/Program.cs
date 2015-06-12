using System;
using System.Collections.Generic;
using System.Linq;
using PostfixEvaluator.Operations;

namespace PostfixEvaluator
{
    class Program
    {
        static Dictionary<string, int> Operators = new Dictionary<string, int>();
        static void Main(string[] args)
        {
            String PostfixString = "5 1 2 + 4 * + 3 -";
            
            Console.WriteLine("Input Expression: {0}", PostfixString);
            try
            {
                InitializeOperators();
                decimal output = Evaluate(PostfixString);
                Console.WriteLine("Result : {0}", output);
                Console.WriteLine("Finished.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occured : {0}", e.Message);
            }
            Console.ReadKey();
        }

        private static void InitializeOperators()
        {
            //Operators.Add(<Operator>, <Number of Arguments which the operator takes>);
            Operators.Add("^", 2);
            Operators.Add("/", 2);
            Operators.Add("*", 2);
            Operators.Add("-", 2);
            Operators.Add("+", 2);
        }

        private static bool isOperator(String token)
        {
            return Operators.ContainsKey(token);
        }

        private static decimal Evaluate(string PostfixString)
        {
            try
            {
                char[] separator = { ' ' };
                string[] tokensArray = PostfixString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                Stack<decimal> argumentsStack = new Stack<decimal>();
                decimal number;                
                string token;

                //Read the tokens one by one
                for (int i = 0; i < tokensArray.Length; i++)
                {
                    token = tokensArray[i];
                    number = decimal.Zero;                    

                    //If the token is a value - Push it onto the stack.
                    if (decimal.TryParse(token, out number))
                    {
                        argumentsStack.Push(number);
                    }
                    //if the token is an operator
                    else if (isOperator(token))
                    {
                        int ArgumentsRequired = Operators[token];

                        //If there are fewer values on the stack than the number of arguments(n) required by the operator
                        if (argumentsStack.Count < ArgumentsRequired)
                        {
                            throw new Exception("The user has not provided sufficient values in the expression.");
                        }
                        else
                        {
                            //Pop the top n values from the stack.
                            List<decimal> argsList = new List<decimal>();
                            for (int k = 0; k < ArgumentsRequired; k++)
                            {
                                argsList.Add(argumentsStack.Pop());
                            }

                            //We need to reverse the order of the elements in the list to resemble the order of stack.
                            argsList.Reverse();

                            //Evaluate the operator, with the values as arguments.
                            IOperation IObj = ObjectFactory(token);
                            decimal val = IObj.CalculateResultOfOperation(argsList);

                            //Push the returned results, if any, back onto the stack.
                            argumentsStack.Push(val);
                        }
                    }
                    else
                    {
                        throw new Exception("Unknown operator found in the input: " + token);
                    }
                }

                //If there is only one value in the stack
                if(argumentsStack.Count == 1)
                {
                    //That value is the result of the calculation.
                    return argumentsStack.Pop();
                }
                else
                {
                    throw new Exception("The user has provided too many values.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Factory design pattern
        static public IOperation ObjectFactory(string choice)
        {
            IOperation objOperator = null;

            switch (choice)
            {
                case "+":
                    objOperator = new Addition();
                    break;
                case "-":
                    objOperator = new Subtraction();
                    break;
                case "*":
                    objOperator = new Multiplication();
                    break;
                case "/":
                    objOperator = new Division();
                    break;
                case "^":
                    objOperator = new Exponent();
                    break; 
            }
            return objOperator;

        }
    }
}
