using System;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace Test1
{
    class Program
    {
        public static void Main(string[] _Inputs)
        {
            string line = Console.ReadLine();
            int value;
            if (int.TryParse(line, out value))
            {
                int input = value;
                int RevInput = ReverseNum(input);
                if (input != 0)
                {
                    Random _randomNumber = new Random(56748);


                    int rest = input - (_randomNumber.Next() % RevInput);
                }
            }
            else
            {
                Console.WriteLine("Input is not valid. Integer Numbers only allowed.");
            }

        }

        public static int ReverseNum(int input)
        {
            int _return = 0;
            String s = input.ToString();

            int DecimalPlacer = 1;

            for(int i = 0; i < s.Length; i++)
            {
                char digit = s.ElementAt(i);
                _return += Int32.Parse(digit.ToString()) * DecimalPlacer;

                DecimalPlacer = DecimalPlacer * 10;
            }
            


            Console.WriteLine(_return);
            return _return;
        }

    }
}
