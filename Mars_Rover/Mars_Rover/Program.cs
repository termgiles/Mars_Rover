using System.Text.RegularExpressions;

namespace Mars_Rover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string input = "5: - 6";
            char[] separatorChars = new char[] { ',', '-', ':', ';' };
            string cleanedInputOne = input.Replace(',', ' ').Replace(':', ' ').Replace(';', ' ').Replace('-', ' ');
            string cleanedInputTwo = Regex.Replace(cleanedInputOne, "[ ]+", " ");
            string[] coordinates = cleanedInputTwo.Split(' ');
            Console.WriteLine(cleanedInputOne);
            Console.WriteLine(cleanedInputTwo);
            Console.WriteLine(coordinates[0]);
            Console.WriteLine(coordinates[1]);


        }
    }
}
