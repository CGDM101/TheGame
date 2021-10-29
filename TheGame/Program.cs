using System;
using System.Collections.Generic;
using System.Threading;

namespace TheGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            Menu();
            // Game x = new Game();
        }

        public static void Menu()
        {
            Welcome();
            List<Player> allPlayers = CreatePlayerAndAddToList();
            //Player o = CreatePlayerAndAddToList();
            //List<Player> allPlayers = CreateListOfPlayers(o);
            int userChoice = SelectionMenu();
            UserChoiceHandled(userChoice, allPlayers);
        }

        #region obsolete
        private static List<Player> CreateListOfPlayers(Player x)
        {
            List<Player> list = new List<Player>();
            list.Add(x);
            return list;
        }
        #endregion

        private static int SelectionMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Go adventuring");
            Console.WriteLine("2. Show details about your character");
            Console.WriteLine("3. Exit game");
            int userChoice = int.Parse(Console.ReadLine());
            return userChoice;
        }

        private static void UserChoiceHandled(int userChoice, List<Player> l)
        {
            switch (userChoice)
            {
                case 1:
                    GoAdventuring();
                    break;
                case 2:
                    ShowDetailsAboutYourCharacter(l);
                    break;
                case 3:
                    ExitMessage();                    
                    break;
                default:
                    Console.WriteLine("Choose option 1, 2 or 3!");
                    break;
            }
        }

        private static void ExitMessage()
        {
            string[] smileyArray = new string[10] { ":'( ", ":'( " , ":'( ", ":'( ", ":'( ", ":'( ", ":'( ", ":'( ", ":'( ", ":'( ", };
            //ConsoleColor[] colourArray = new ConsoleColor[2] { ConsoleColor.Red, ConsoleColor.Blue };
            for (int i = 0; i < smileyArray.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(smileyArray[i] + " ");
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.Gray;

                //if (smileyArray.Length % i == 0)
                //{
                //    Console.ForegroundColor = ConsoleColor.DarkCyan;
                //    Console.Write(smileyArray[i] + " ");
                //    Thread.Sleep(500);
                //}
                //else if (smileyArray.Length % i != 0)
                //{
                //    Console.ForegroundColor = ConsoleColor.DarkYellow;
                //    Console.Write(smileyArray[i] + " ");
                //    Thread.Sleep(500);
                //}
            }

            Console.WriteLine("Sad to see you leave but you are welcome back!");
        }

        private static void ShowDetailsAboutYourCharacter(List<Player> lst)
        {
            foreach (var item in lst)
            {
                Console.WriteLine("Name: " + item.Name);
                Console.WriteLine("Hp: " + item.Hp);
                Console.WriteLine("Level: " + item.Level);
                Console.WriteLine("Xp: " + item.Xp);
            }
        }

        private static void GoAdventuring()
        {
            Random rnd = new Random();
            int outcome = rnd.Next(1, 3); // 11 (10% chans monstret anfaller)
            if (outcome == 1)
            {
                Console.WriteLine("Jäklar");
                BattleBegins();
            }
            else if (outcome != 1)
            {
                Console.WriteLine("inget hände");
                // fortsätt spelet.
            }
        }

        private static Game BattleBegins()
        {
            Random rnd = new Random();
            int chance = rnd.Next(1, 3); // Varannan gång = 50%
            if (chance == 1)
            {
                Game g = MonsterHitsPlayer();
                return g;
            }
            else if(chance == 2)
            {
                Game gg = HitMonster();
                return gg;
            }
            else
            {
                Game ggg = new Game();
                return ggg;
            }
        }

        private static Game MonsterHitsPlayer()
        {
            Console.WriteLine("The monster hit you, dealing 1 damage");
            Console.WriteLine("Player Hp: ");
        }

        private static Game HitMonster()
        {
            Console.WriteLine("You hit the monster, dealing 1 damage.");
            Console.WriteLine("Monster Hp:");
        }

        public static void GameOver()
        {
            Console.WriteLine("Någon dog");
        }

        private static List<Player> CreatePlayerAndAddToList() // EnterName() earlier.
        {
            Console.Write("Enter your name: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string userInput = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Player p = new Player { Name = userInput };
            List<Player> list = new List<Player>();
            list.Add(p);
            return list;
        }

        private static void Welcome()
        {
            Console.WriteLine("***********************");
            Console.WriteLine("* Welcome to the game *");
            Console.WriteLine("***********************");
        }
    }
}
