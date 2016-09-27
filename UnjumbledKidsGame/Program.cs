using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace UnjumbledKidsGame
{
    class Program
    {
        private static bool bimus = true;
        public static string apiKey = "501c8e7f-7e3c-4b25-99f4-1fa965e08bcb";
        private static StreamWriter myWriter = new StreamWriter("definition.xml");
        static void Main(string[] args)
        {

            //bool bimus2 = true;
            try
            {
                while (bimus)
                {


                    string[] myReader = File.ReadAllLines("Dictionary.txt");
                    

                    Random myRandom = new Random();
                    Random myOtherRandom = new Random();

                    int shnd = myReader.Length - 1;
                    var randomIndex = myRandom.Next(0, shnd);
                    var randomIndex2 = 0;



                    string genWord = myReader[randomIndex];


                    while (genWord.Length < 4)
                    {
                        randomIndex = myRandom.Next(0, shnd);
                        genWord = myReader[randomIndex];
                    }
                    Console.WriteLine("{0}\n", genWord);
                    char[] strayWord = genWord.ToCharArray();

                    for (int i = 0; i < strayWord.Length * 100; i++)
                    {
                        randomIndex = myRandom.Next(0, strayWord.Length - 1);
                        randomIndex2 = myOtherRandom.Next(0, strayWord.Length - 1);

                        while (randomIndex2 == randomIndex)
                        {
                            randomIndex2 = myOtherRandom.Next(0, strayWord.Length - 1);
                        }
                        var temp = strayWord[randomIndex];
                        strayWord[randomIndex] = strayWord[randomIndex2];
                        strayWord[randomIndex2] = temp;
                    }
                    Console.Write("Guess what word ");
                    foreach (var item in strayWord)
                    {
                        Console.Write(item);
                    }


                    Console.WriteLine(" is\n");
                    getDef(genWord);
                    string guess = Console.ReadLine().ToLower();

                    while (guess != genWord.ToLower())
                    {
                        Console.Write("try again: ");
                        guess = Console.ReadLine();
                    }
                    endGame();



                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //Console.ReadLine();
            }
        }

        private static void endGame()
        {
            

            Console.Write("\tCongrats!\n\t\tDo you wish to continue? y/n: ");
            string playAgain = Console.ReadLine();

            if (playAgain.ToLower() == "y" || playAgain.ToLower() == "yes")
            {
                bimus = true;
            }
            else
            {
                Console.WriteLine("Thanks for playing\n\tHope you enjoyed\n\t\tSee you soon!");
                Console.ReadLine();
                bimus = false;
            }
        }

        public static void getDef(string wordQuery)
        {
            WebClient client = new WebClient();
            string address = "http://www.dictionaryapi.com/api/v1/references/collegiate/xml/" + wordQuery + "?key=" + apiKey;
            string reply = client.DownloadString(address);

            myWriter.WriteLine(reply);
            //Console.WriteLine(reply);
            myWriter.Close();
        }
    }
}