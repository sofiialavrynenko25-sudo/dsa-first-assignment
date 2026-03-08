using System.Globalization;
using DSA_assignment1;

Console.WriteLine("Enter your example: ");
var input = Console.ReadLine();
var c = new ShuntingYardAlgorithm(input);
var postfix = c.RunAndPrintPostfix();
Console.WriteLine("");
c.CalculatePostfix(postfix);
