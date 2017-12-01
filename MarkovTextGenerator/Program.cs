using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MarkovTextGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Chain chain = new Chain();

            Console.WriteLine("Welcome to Marky Markov's Random Text Generator!");

            //Console.WriteLine("Enter some text I can learn from (enter single ! to finish): ");

            int counter = 0;
            String line;
            
            StreamReader file = new StreamReader("../../SourceTexts/Trump.txt");
            while ((line = file.ReadLine()) != null)
            {
                chain.AddString(line);
                counter++;
            }

            file.Close();

            /*while (true)
            {
                Console.Write("> ");

                String line = Console.ReadLine();
                if (line == "!")
                    break;

                chain.AddString(line);  // Let the chain process this string
            } */

            // Now let's update all the probabilities with the new data
            chain.UpdateProbabilities();

            Console.WriteLine("Done learning! ");

            while(true)
            {
                // Okay now for the fun part
                //Console.WriteLine("Now give me a word and I'll tell you what comes next.");
                //Console.Write("> ");

                String word = chain.GetRandomStartingWord();
                while(word != "")
                {
                    Console.Write(word + " ");
                    word = chain.GetNextWord(word);
                }
                // Console.WriteLine("I predict the next word will be " + nextWord);
                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }
}
