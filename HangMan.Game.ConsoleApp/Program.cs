using System;
using System.Collections.Generic;

namespace HangMan.Game.ConsoleApp
{
    class Program
    {
        const string temaVardai = "VARDAI";
        const string temaMiestai = "LIETUVOS MIESTAI";
        const string temaValstybes = "VALSTYBES";
        const string temaBaldai = "BALDAI";
        const int gyvybiuKiekis = 7;

        readonly static List<string> temos = new List<string> { temaVardai, temaMiestai, temaValstybes, temaBaldai };
        readonly static List<string> vardai = new List<string> { "Mindaugas", "Gediminas", "Vytautas", "Kestutis", "Algirdas", "Žygimantas", "Birute", "Barbora", "Augustas", "Morta" };
        readonly static List<string> miestai = new List<string> { "Vilnius", "Klaipeda", "Ukmerge", "Taurage", "Alytus", "Palanga", "Utena", "Varena", "Kaunas", "Raseiniai" };
        readonly static List<string> valstybes = new List<string> { "Kinija", "Prancuzija", "Estija", "Norvegija", "Taivanas", "Indija", "Meksika", "Suomija", "Argentina", "Portugalija" };
        readonly static List<string> baldai = new List<string> { "Stalas", "Kede", "Spinta", "Lova", "Suolas", "Sofa", "Lempa", "Durys", "Kilimas", "Veidrodis" };
        //panaudotus žodžius dėti į atskirą žodyną tam tam kad jie nebesikartotų paduodant naują žodį
        static Dictionary<string, List<string>> panaudotiZodziai = new Dictionary<string, List<string>>();
        static void Main(string[] args)
        {
            //TODO 1. Create a method bellow to display Topics selection. Enter number 1-4.
            //TODO 2. After Topic was selected, pick a word from a List randomly
            //TODO 3 Display UI elements for a game
            //TODO 3a. Allow user to enter letters.
            //TODO 3b. Dislay Hanger
            //TODO 3c. Update Hanger if user entred wrong letter(s)
            //TODO 3d. Display wrongly guessed letters. This is needed to user, to be able to see what letters have been guessed. Restrict guessing to 7 times( 7 lives on Hanger)
            //TODO 3e. Place correctly guessed letter into a UI: _ _ _ _ _ A _.
            //TODO 4. If when the word guess
            //TODO
        }
        //TODO Game mechanics
        static void TopicSelection()
        {
            //TODO I - Show Topics and let user select topic from list of topics
        }

        //TODO II. A Method to get randomly selected word
        //TODO III. A Method
        //TODO IV. A Method to place Words based on their Topic into a Dictionary. For Word that havent beed used yet.
        //TODO V. A Method to place used word into a List
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
        #region Piesiniai
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