using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UnjumbledKidsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool bimus = true;
            
            
            while (bimus)
            {
                
                string[] myReader = File.ReadAllLines("Dictionary.txt");

                Random myRandom = new Random();
                Random myOtherRandom = new Random();

                int shnd = myReader.Length - 1;
                var randomIndex = myRandom.Next(0, shnd);
                var randomIndex2 = 0;
                

                
                string genWord = myReader[randomIndex];

                
                while (genWord.Length<4)
                {
                    randomIndex = myRandom.Next(0, shnd);
                    genWord = myReader[randomIndex];
                }
                Console.WriteLine("{0}\n", genWord);
                Console.ReadLine();
                char[] strayWord = genWord.ToCharArray();

                for (int i = 0; i < strayWord.Length * 100; i++)
                {
                    randomIndex = myRandom.Next(0, strayWord.Length-1);
                    randomIndex2 = myOtherRandom.Next(0, strayWord.Length - 1);

                    while (randomIndex2==randomIndex)
                    {
                        randomIndex2 = myOtherRandom.Next(0, strayWord.Length - 1);
                    }
                    var temp = strayWord[randomIndex];
                    strayWord[randomIndex] = strayWord[randomIndex2];
                    strayWord[randomIndex2] = temp;
                }

                foreach (var item in strayWord)
                {
                    Console.Write(item);
                }

                Console.WriteLine("");
                Console.ReadLine();
            }
        }
    }
}
