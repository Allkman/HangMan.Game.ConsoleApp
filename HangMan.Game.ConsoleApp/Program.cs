using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan.Game.ConsoleApp
{
    class Program
    {
        const string topicNames = "NAMES";
        const string topicCities = "CITIES IN LITHUANIA";
        const string topicCountries = "COUNTRIES";
        const string topicFurnitures = "FURNITURE";
        const int numberOfAttempts = 7;

        readonly static List<string> topics = new List<string> { topicNames, topicCities, topicCountries, topicFurnitures };
        readonly static List<string> names = new List<string> { "Mindaugas", "Gediminas", "Vytautas", "Kestutis", "Algirdas", "Žygimantas", "Birute", "Barbora", "Augustas", "Morta" };
        readonly static List<string> cities = new List<string> { "Vilnius", "Klaipeda", "Ukmerge", "Taurage", "Alytus", "Palanga", "Utena", "Varena", "Kaunas", "Raseiniai" };
        readonly static List<string> countries = new List<string> { "Kinija", "Prancuzija", "Estija", "Norvegija", "Taivanas", "Indija", "Meksika", "Suomija", "Argentina", "Portugalija" };
        readonly static List<string> furniture = new List<string> { "Stalas", "Kede", "Spinta", "Lova", "Suolas", "Sofa", "Lempa", "Durys", "Kilimas", "Veidrodis" };
        //Dictionary for used words so they wont repeat when replaying
        //static Dictionary<string, List<string>> usedWords = new Dictionary<string, List<string>>();
        public Random rnd = new Random();

        static void Main(string[] args)
        {

            //    HangMan();

            //TODO 1. Create a method bellow to display Topics selection. Enter number 1-4. +DONE

            //Bellow code is for testing purposes only.. I will remove it once all mechanics are done.
            var topic = TopicSelection();
            Console.WriteLine();
            //Console.Clear();
            var word = RandomWordGenerator(topic, GetTopicAndWordsPaired(topic));


            Console.WriteLine($"Number of word in selected topic: {word}");

            Console.WriteLine();

            var incorrectGuesses = new List<string>(); //adding incorrect guesses to a List, so that later i could compare it to number of attempts
                                                       //var correctGuesses = new string[word.Length];

            StartingPicture();

            //replay = (Console.ReadKey().KeyChar.ToString().ToUpper() == "T");

            //TODO 2. After Topic was selected, pick a word from a List randomly
            //TODO 3 Display UI elements for a game
            //TODO 3a. Allow user to enter letters.
            //TODO 3b. Dislay Hanger
            //TODO 3c. Update Hanger if user entred wrong letter(s)
            //TODO 3d. Display wrongly guessed letters. This is needed to user, to be able to see what letters have been guessed. Restrict guessing to 7 times( 7 lives on Hanger)
            //TODO 3e. Place correctly guessed letter into a UI: _ _ _ _ _ A _.
            //TODO 4. If when the word guess
            //TODO

            Console.ReadKey();
        }

        //TODO GamePlay Method
        static void HangMan()
        {
            //var topic = TopicSelection();
            // var playWord = RandomWordGenerator();
        }

        //TODO Game mechanics
        //TODO I - Show Topics and let user select topic from list of topics

        static string TopicSelection()
        {
            Console.WriteLine("Choose one of the following topics: ");
            var topicNumber = 0;
            DisplayTopicNames();
            while (topicNumber > topics.Count || topicNumber == 0)
            {
                var topicInput = Console.ReadKey().KeyChar;
                int.TryParse(topicInput.ToString(), out topicNumber);
                if (topicNumber > topics.Count || topicNumber == 0)
                {

                    Console.WriteLine("Please enter a number representing a topic number");
                }

            }
            return topics[topicNumber - 1];
        }
        static void DisplayTopicNames()
        {
            for (int i = 1; i <= topics.Count; i++)
            {

                Console.Write("\n Topic - {0}: = {1}", i, topics[i - 1]);
            }
            Console.WriteLine();
        }
        //TODO II. A Method to get randomly selected word for selected topic
        static string RandomWordGenerator(string topicForKvp, KeyValuePair<string, string> kvpTopicAndWords)
        {

            Random rnd = new Random();
            var randomSelect = topicForKvp;

            randomSelect = rnd.Next(0, kvpTopicAndWords.Value.Length).ToString();


            return randomSelect;

        }

        static KeyValuePair<string, string> GetTopicAndWordsPaired(string topicForKvp)
        {
            var topicIndex = topicForKvp;
            List<List<string>> listOfWordsLists = new List<List<string>> { names, cities, countries, furniture };

            foreach (var list in listOfWordsLists)
            {
                for (int i = 0; i < listOfWordsLists.Count; i++)
                {
                    topicIndex = list[i];
                }
            }
            var kvpWords = new KeyValuePair<string, string>();
            foreach (var words in listOfWordsLists)
            {

                for (int i = 0; i < words.Count; i++)
                {
                    kvpWords = new KeyValuePair<string, string>((string)topicForKvp, words[i]);
                }
            }
            Console.WriteLine($"Selected Topic: {topicForKvp}");
            return kvpWords;
        }

        //TODO III. A Method
        //TODO IV. A Method to place Words based on their Topic into a Dictionary. For Word that havent beed used yet.
        //TODO V. A Method to place used word into a List


        //static List<string> PutUsedWordsToList(List<string> inputOfUsedWord, string topic)
        //{
        //    var result = new List<string>();
        //    foreach (var word in inputOfUsedWord)
        //    {
        //        if (usedWords.ContainsKey(topic))
        //        {
        //            result.Add(word);
        //        }
        //    }
        //    return result;
        //}

        static void WordGuessField(string[] word)
        {
            Console.WriteLine();
            StringBuilder displayToPlayer = new StringBuilder(word.Length);
            for (int i = 0; i < word.Length; i++)
                displayToPlayer.Append('_');
        }



        //TODO VI. A Method to create UI to display Word guessing field. (String builder)
        //TODO VII. A Method to let write  a Letter
        //TODO VIII. A Method to check if a given word has a letter.
        //TOTO IX. A Method to place written letter into a correct place in a given word 
        //TODO X. A Method to display all wrongly guessed letter.
        //TODO XI. A Method to check if a word was guessed.
        //TODO XII. A Method to display WIN message (+ a word)

        //TOTO XIII. A Method to select Hangman UI + UI elements                                                               +DONE
        static void HangerPictureSelection(List<string> incorrectGuesses)
        {
            Console.Clear();
            switch (incorrectGuesses.Count)
            {
                case 0:
                    StartingPicture();
                    break;
                case 1:
                    DisplayWithHead();
                    break;
                case 2:
                    DisplayWithNeck();
                    break;
                case 3:
                    DisplayWithBody();
                    break;
                case 4:
                    DisplayWithHand1();
                    break;
                case 5:
                    DisplayWithHand2();
                    break;
                case 6:
                    DisplayWithLeg1();
                    break;
            }
        }
        #region Drawings
        static void StartingPicture()
        {
            Console.WriteLine(@"   ---------|    ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"_ _ _ _");
        }
        static void DisplayWithHead()
        {
            Console.WriteLine(@"   ---------|    ");
            Console.WriteLine(@"|           o    ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"_ _ _ _");
        }
        static void DisplayWithNeck()
        {
            Console.WriteLine(@"   ---------|    ");
            Console.WriteLine(@"|           o    ");
            Console.WriteLine(@"|           |    ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"_ _ _ _");
        }
        static void DisplayWithBody()
        {
            Console.WriteLine(@"   ---------|    ");
            Console.WriteLine(@"|           o    ");
            Console.WriteLine(@"|           |    ");
            Console.WriteLine(@"|           O    ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"_ _ _ _");
        }
        static void DisplayWithHand1()
        {
            Console.WriteLine(@"   ---------|    ");
            Console.WriteLine(@"|           o    ");
            Console.WriteLine(@"|          \|    ");
            Console.WriteLine(@"|           O    ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"_ _ _ _");
        }
        static void DisplayWithHand2()
        {
            Console.WriteLine(@"   ---------|    ");
            Console.WriteLine(@"|           o    ");
            Console.WriteLine(@"|          \|/   ");
            Console.WriteLine(@"|           O    ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"_ _ _ _");
        }
        static void DisplayWithLeg1()
        {
            Console.WriteLine(@"   ---------|    ");
            Console.WriteLine(@"|           o    ");
            Console.WriteLine(@"|          \|/   ");
            Console.WriteLine(@"|           O    ");
            Console.WriteLine(@"|          /     ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"_ _ _ _");
        }
        static void DisplayWithLeg2(string word)
        {
            Console.Clear();
            Console.WriteLine(@"   ---------|    ");
            Console.WriteLine(@"|           o    ");
            Console.WriteLine(@"|          \|/   ");
            Console.WriteLine(@"|           O    ");
            Console.WriteLine(@"|          / \   ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"|                ");
            Console.WriteLine(@"_ _ _ _");
            Console.WriteLine();
            Console.WriteLine("  YOU HAVE LOST  ");
            Console.WriteLine("The word was: {0} ", word);
        }

        #endregion

    }
}