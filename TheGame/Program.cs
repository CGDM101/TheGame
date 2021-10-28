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
        }

        public static void Menu()
        {
            Welcome();
            Player o = EnterName();
            List<Player> allPlayers = CreateListOfPlayers(o);
            int userChoice = SelectionMenu();
            UserChoiceHandled(userChoice);
        }

        private static List<Player> CreateListOfPlayers(Player x)
        {
            List<Player> list = new List<Player>();
            list.Add(x);
            return list;
        }

        private static int SelectionMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Go adventuring");
            Console.WriteLine("2. Show details about your character");
            Console.WriteLine("3. Exit game");
            int userChoice = int.Parse(Console.ReadLine());
            return userChoice;
        }

        private static void UserChoiceHandled(int userChoice)
        {
            switch (userChoice)
            {
                case 1:
                    GoAdventuring();
                    break;
                case 2:
                    //ShowDetailsAboutYourCharacter();
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
            foreach (var item in lst) // List is not set to a reference
            {
                Console.WriteLine(item.Name);
            }
        }

        private static void GoAdventuring()
        {
            throw new NotImplementedException();
        }

        private static Player EnterName()
        {
            Console.Write("Enter your name: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string userInput = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Player p = new Player { Name = userInput };
            return p; // Denna ska gå in i listan
        }

        private static void Welcome()
        {
            Console.WriteLine("***********************");
            Console.WriteLine("* Welcome to the game *");
            Console.WriteLine("***********************");
        }
    }
}
