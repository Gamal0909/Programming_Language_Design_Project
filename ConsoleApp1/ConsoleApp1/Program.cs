using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public static string ArrayChallenge(int num)
        {
            string numStr = num.ToString();
            StringBuilder result = new StringBuilder();
            int count = 1;
            for (int i = 0; i < numStr.Length; i++)
            {
                if (i + 1 < numStr.Length && numStr[i] == numStr[i + 1])
                {
                    count++;
                }
                else
                {
                    result.Append(count).Append(numStr[i]);
                    count = 1;
                }
            }
            // code goes here  
            return result.ToString();

        }

        static void Main()
        {

            // keep this function call here
            string ChallengeToken = "t81vhme7d60"; // ChallengeToken provided
            int num = Convert.ToInt32(Console.ReadLine());
            string anwer = ArrayChallenge(num) + ChallengeToken;
            for(int i = 0;i < anwer.Length;i++)
            {
                if ((i + 1) % 4 == 0)
                {
                    Console.Write('_');
                }
                else
                {
                    Console.Write(anwer[i]);
                }
            }
            Console.ReadKey();

        }
    }
}
