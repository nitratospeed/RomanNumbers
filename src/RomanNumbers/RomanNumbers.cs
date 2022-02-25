using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleUI
{
    public class RomanNumbers
    {
        private static void Main()
        {
            var romanNumbers = new RomanNumbers();

            Console.WriteLine("type a roman number...");

            string romanNumber = Console.ReadLine();

            var integerNumber = romanNumbers.ConvertRomanToInteger(romanNumber);

            if (integerNumber == 0)
            {
                Console.WriteLine($"{romanNumber} is a invalid roman number.");
            }
            else
            {
                Console.WriteLine("the integer number is...");
                Console.WriteLine(integerNumber);
            }
        }

        public int ConvertRomanToInteger(string romanNumber)
        {
            int integerNumber = 0;

            var romanNumbers = romanNumber.ToCharArray().Reverse().ToArray();

            if (IsValid(romanNumbers))
            {
                for (int i = 0; i < romanNumbers.Length; i++)
                {
                    if (i > 0)
                    {
                        if (GetDigit(romanNumbers[i - 1]) < GetDigit(romanNumbers[i]) 
                            || GetDigit(romanNumbers[i - 1]) == GetDigit(romanNumbers[i]))
                        {
                            integerNumber += GetDigit(romanNumbers[i]);
                        }
                        if (GetDigit(romanNumbers[i - 1]) > GetDigit(romanNumbers[i]))
                        {
                            integerNumber -= GetDigit(romanNumbers[i]);
                        }
                    }
                    else
                    {
                        integerNumber += GetDigit(romanNumbers[i]);
                    }
                }
            }

            return integerNumber;
        }

        private bool IsValid(char[] romanNumbers)
        {
            bool valid = true;

            var pattern = @"([I.V.X.L.C.D.M])\1{3,}";

            string rnString = new string(romanNumbers);

            Match m = Regex.Match(rnString, pattern, RegexOptions.IgnoreCase);

            if (m.Success)
            {
                valid = false;
            }

            if (romanNumbers.Count(x => x == 'V') > 1 
                || romanNumbers.Count(x => x == 'L') > 1 
                || romanNumbers.Count(x => x == 'D') > 1)
            {
                valid = false;
            }

            for (int i = 0; i < romanNumbers.Length; i++)
            {
                if (i > 0)
                {
                    if ((romanNumbers[i - 1] == 'L' || romanNumbers[i - 1] == 'C' || romanNumbers[i - 1] == 'D' || romanNumbers[i - 1] == 'M') && romanNumbers[i] == 'I')
                    {
                        valid = false;
                    }
                    if ((romanNumbers[i - 1] == 'X' || romanNumbers[i - 1] == 'L' || romanNumbers[i - 1] == 'D') && romanNumbers[i] == 'V')
                    {
                        valid = false;
                    }
                    if ((romanNumbers[i - 1] == 'D' || romanNumbers[i - 1] == 'M') && romanNumbers[i] == 'X')
                    {
                        valid = false;
                    }
                    if (romanNumbers[i - 1] == 'D' && romanNumbers[i] == 'L')
                    {
                        valid = false;
                    }
                    if (romanNumbers[i - 1] == 'M' && romanNumbers[i] == 'D')
                    {
                        valid = false;
                    }
                }
                if (GetDigit(romanNumbers[i]) == 0)
                {
                    valid = false;
                }
            }

            return valid;
        }

        private int GetDigit(char romanNumber)
        {
            const int I = 1;
            const int V = 5;
            const int X = 10;
            const int L = 50;
            const int C = 100;
            const int D = 500;
            const int M = 1000;

            if (romanNumber == 'I')
            {
                return I;
            }

            else if (romanNumber == 'X')
            {
                return X;
            }

            else if (romanNumber == 'C')
            {
                return C;
            }

            else if (romanNumber == 'M')
            {
                return M;
            }

            else if (romanNumber == 'V')
            {
                return V;
            }

            else if (romanNumber == 'L')
            {
                return L;
            }

            else if (romanNumber == 'D')
            {
                return D;
            }

            else
            {
                return 0;
            }
        }
    }
}
