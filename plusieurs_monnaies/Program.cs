using System;
using System.Globalization;
using System.Text.RegularExpressions;

class Program
{
    public static void Main(string[] args)
    {
        ShowMoney showm = AddDollars;
        Console.WriteLine(showm("€ 12.50", "€ 13.16"));
        showm = AddEuros;
        Console.WriteLine(showm("$ 2.50", "$ 13.16"));

    }

    public delegate string ShowMoney(string x, string y);

    public static string AddDollars(string x, string y)
    {

        double suma = ExtractDoubleFromString(x) + ExtractDoubleFromString(y);
        string answer = "$ " + suma.ToString();
        return answer;// add dollar sign à la fin
    }

    public static string AddEuros(string x, string y)
    {
        double suma = ExtractDoubleFromString(x) + ExtractDoubleFromString(y);
        string answer = "€ " + suma.ToString();
        return suma.ToString();// ad euro sign à la fin 
    }
    static double ExtractDoubleFromString(string input)
    {
        // Use Regex to extract the numeric part
        string pattern = @"[-+]?\d*\.?\d+";
        Match match = Regex.Match(input, pattern);

        if (match.Success)
        {
            // Convert the extracted string to double
            double value;
            if (double.TryParse(match.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out value))
            {
                return value;
            }
        }

        // Return 0 if the conversion fails
        return 0;
    }
}