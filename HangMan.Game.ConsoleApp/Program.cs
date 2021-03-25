using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HangMan.Game.ConsoleApp
{
    class Program
    {
        //UI Elements
        #region 
        const string topicNames = "NAMES";
        const string topicCities = "CITIES IN LITHUANIA";
        const string topicCountries = "COUNTRIES";
        const string topicFurnitures = "FURNITURE";
        const string askForTopicSelectTxt = "Choose topic: ";
        const string wordTxt = "Word: ";
        const string msgIncorrectTopic = "Input correct topic number";
        const string txtTopic = "Topic: - ";
        const string askReplayTxt = "Do you want to replay Y/N ?";
        const string guessLetterOrFullWordTxt = "Guess letter or full word: ";
        const string guessedLettersTxt = "\nGuessed letters: ";
        const string txtNoMoreWord = "There are  no more words left in this topic";
        static string winMessageTxt = @"!!! CONGRATULATION !!!! WORD IS CORRECT :)            
            The word: ";
        #endregion
        const int numberOfAttempts = 7;
        readonly static List<string> topics = new List<string> { topicNames, topicCities, topicCountries, topicFurnitures };
        readonly static List<string> names = new List<string> { "Mindaugas", "Gediminas", "Vytautas", "Kestutis", "Algirdas", "Žygimantas", "Birute", "Barbora", "Augustas", "Morta" };
        readonly static List<string> cities = new List<string> { "Vilnius", "Klaipeda", "Ukmerge", "Taurage", "Alytus", "Palanga", "Utena", "Varena", "Kaunas", "Raseiniai" };
        readonly static List<string> countries = new List<string> { "Kinija", "Prancuzija", "Estija", "Norvegija", "Taivanas", "Indija", "Meksika", "Suomija", "Argentina", "Portugalija" };
        readonly static List<string> furniture = new List<string> { "Stalas", "Kede", "Spinta", "Lova", "Suolas", "Sofa", "Lempa", "Durys", "Kilimas", "Veidrodis" };
        readonly static List<List<string>> listOfWordsList = new List<List<string>> { names, cities, countries, furniture };
        static Dictionary<string, List<string>> usedWords = new Dictionary<string, List<string>>();

        static void Main(string[] args)
        {
            HangMan();

        }
        static void HangMan()
        {
            bool replay = true;
            while (replay)
            {
                Console.Clear();

                List<KeyValuePair<string, string>> kvpOfAllWords = new List<KeyValuePair<string, string>>();
                var topic = TopicSelection();
                var word = RandomWordGenerator(topic, GetKVPOfAllWords(kvpOfAllWords));
                if (word == null)
                {
                    Console.WriteLine(txtNoMoreWord);
                }
                else
                {
                    PlayGame(topic, word);
                }
                replay = (Console.ReadKey().KeyChar.ToString().ToUpper() == "T");
            }
        }

        static string TopicSelection()
        {
            Console.WriteLine(askForTopicSelectTxt);
            var topicNumber = 0;
            DisplayTopicNames();
            while (topicNumber > topics.Count || topicNumber == 0)
            {
                var topicInput = Console.ReadKey().KeyChar;
                int.TryParse(topicInput.ToString(), out topicNumber);
                if (topicNumber > topics.Count || topicNumber == 0)
                {
                    Console.WriteLine(msgIncorrectTopic);
                }
            }
            return topics[topicNumber - 1];
        }
        static void DisplayTopicNames()
        {
            for (int i = 1; i <= topics.Count; i++)
            {
                Console.Write("\n {0} - {1}: = {2}", txtTopic, i, topics[i - 1]);
            }
            Console.WriteLine();
        }
        static string RandomWordGenerator(string topic, List<KeyValuePair<string, string>> kvpOfAllWords)
        {
            var newShortKVPList = new List<KeyValuePair<string, string>>();
            var wordFromKVP = new KeyValuePair<string, string>();

            var rnd = new Random();

            foreach (var kvp in kvpOfAllWords)
            {
                if (kvp.Key == topic)
                {
                    wordFromKVP = kvp;
                    Console.WriteLine($"kvp is = {kvp}"); //Display all pairs from selected topic (in this case 10)
                }
            }
            newShortKVPList.Add(wordFromKVP);
            var rndNumber = rnd.Next(0, newShortKVPList.Count);

            return newShortKVPList;
        }
        static List<KeyValuePair<string, string>> GetKVPOfAllWords(List<KeyValuePair<string, string>> kvpOfAllWords)
        {
            for (int i = 0; i < listOfWordsList.Count; i++)
            {
                foreach (var word in listOfWordsList[i])
                {
                    kvpOfAllWords.Add(new KeyValuePair<string, string>(topics[i], word));//all topics and words paired
                }
            }
            return kvpOfAllWords;
        }
        static void PlayGame(string topic, string word)
        {
            var incorrectGuesses = new List<string>();
            var correctGuesses = new string[word.Length];

            FillUsedWordsList(topic, word);

            StartingPicture();
            WordGuessField(correctGuesses);
            bool guessingAllowed = true;
            while (guessingAllowed)
            {
                string guess = DisplayLetterOrWordGuessing();
                bool wasItWordGuess = guess.Length > 1;
                if (wasItWordGuess)
                {
                    WordGuesssing(guessingAllowed, word, guess);
                }
                else
                {
                    LetterGuessing(incorrectGuesses, correctGuesses, guessingAllowed, guess, word);
                }
                Console.WriteLine(askReplayTxt);
            }
        }
        static void FillUsedWordsList(string topic, string word)
        {
            if (usedWords.ContainsKey(topic)) usedWords[topic].Add(word);
            else usedWords.Add(topic, new List<string> { word });
        }

        static void WordGuessField(string[] correctGuesses)
        {
            Console.WriteLine();
            var sb = new StringBuilder(wordTxt);
            foreach (var letter in correctGuesses)
            {
                if (string.IsNullOrWhiteSpace(letter)) sb.Append("_ ");
                else sb.Append($"{letter} ");
            }
            var result = sb.ToString();
            Console.WriteLine(result);
        }
        static string DisplayLetterOrWordGuessing()
        {
            Console.WriteLine("\n\n{0}", guessLetterOrFullWordTxt);
            return Console.ReadLine();
        }
        static void WordGuesssing(bool guessingAllowed, string guess, string word)
        {
            bool wasItWord = word == guess;

            if (wasItWord)
            {
                DisplayWinMessage(word);
            }
            else
            {
                DisplayWithLeg2(word);
            }
            guessingAllowed = false;
        }
        static void LetterGuessing(List<string> incorrectGuesses, string[] correctGuesses, bool guessingAllowed, string guess, string word)
        {
            bool wasItLetter = incorrectGuesses.Contains(guess);
            if (!wasItLetter)
            {
                var letterIndexes = CheckLettersAndReturnIndexes(word, guess);
                if (letterIndexes.Count == 0)
                {
                    incorrectGuesses.Add(guess);
                }
                else
                {
                    PlaceLetterToItsIndex(guess, letterIndexes, ref correctGuesses);
                }
            }
            if (incorrectGuesses.Count == numberOfAttempts)
            {
                DisplayWithLeg2(word);
                guessingAllowed = false;
            }
            else
            {
                HangerPictureSelection(incorrectGuesses);
                DisplayIncorrectlyGuessedLetters(incorrectGuesses);
                WordGuessField(correctGuesses);
                bool a = WasWordGuessed(correctGuesses, word);
                if (a == true)
                {
                    DisplayWinMessage(word);
                    guessingAllowed = false;
                }
            }
        }
        static bool WasWordGuessed(string[] correctGuesses, string word)
        {
            string a = string.Join("", correctGuesses);
            return a.ToUpper() == word.ToUpper();
        }
        static List<int> CheckLettersAndReturnIndexes(string word, string guess)
        {
            var wordArray = word.ToCharArray();
            var result = new List<int>();
            for (int i = 0; i < word.Length; i++)
            {
                if (wordArray[i].ToString().ToUpper() == guess.ToUpper()) result.Add(i);
            }
            return result;
        }
        static void PlaceLetterToItsIndex(string spejimas, List<int> raidesIndeksai, ref string[] teisingiSpejimai)
        {
            foreach (int indeksas in raidesIndeksai)
            {
                teisingiSpejimai[indeksas] = spejimas;
            }
        }
        static void DisplayIncorrectlyGuessedLetters(List<string> incorrectGuesses)
        {
            Console.WriteLine(guessedLettersTxt);
            foreach (var incorrectGuess in incorrectGuesses)
            {
                Console.Write($"[{incorrectGuess}] ");
            }
        }
        static void DisplayWinMessage(string word)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(winMessageTxt + word);
        }
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