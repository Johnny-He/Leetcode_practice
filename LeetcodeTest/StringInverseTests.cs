using System.Linq;
namespace LeetCodeTest

{
    public static class StringHelper
    {
        public static string Inverse2(string input)
        {
            var output = string.Empty;
            for (var i = input.Length -1; i >= 0; i--)
            {
                output += input[i];
            }
            return output;
        }

        public static string Inverse3(string input)
        {
            if (input.Length < 2)
            {
                return input;
            }
            var temp = SwapFirstAndLast2(input);
            return temp.First() + Inverse(input.Substring(1, input.Length - 2)) + temp.Last();
        }
        
        public static string Inverse(string input)
        {
            if (input.Length < 2)
            {
                return input;
            }
            
            var stringInverseDto = new StringInverseDto(input);
            SwapFirstAndLast(stringInverseDto);
            return stringInverseDto.FirstChar + Inverse(stringInverseDto.RemainString) + stringInverseDto.LastChar;
        }

        private static StringInverseDto SwapFirstAndLast(StringInverseDto input)
        {
            (input.FirstChar, input.LastChar) = (input.LastChar, input.FirstChar);
            return input;
        }
        
        private static string SwapFirstAndLast2(string input)
        {
            return input.Last() + input.Remove(input.Length-1).Remove(0,1) + input.First();
        }
    }

    public class StringInverseDto
    {
        public char FirstChar { get; set; }
        public char LastChar { get; set; }
        public string RemainString { get; set; }

        public StringInverseDto(string input)
        {
            FirstChar = input.First();
            LastChar = input.Last();
            RemainString = input.Remove(input.Length-1).Remove(0,1);
        }
    }
}