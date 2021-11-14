using System;
using System.Collections.Generic;
using System.Threading;

namespace TheGame
{
    public class Game  // ?
    {
        //public void GameOver()
        //{
        //    Console.WriteLine("Du dog. Spelet är slut.");
        //}
        public void GameMenu()
        {
            // ?   
        }
    }
    public class Program
    {   
        // För varje monster man dödar får man experience points. När man når level 10 avslutas spelet.
        static void Main(string[] args)
        {
            // Saker som har med Game-klassen att göraQ.
            Game g = new Game();
            g.GameMenu();

            Monster m1 = new Monster { Name = "m1" };
            SpecificMonster sm1 = new SpecificMonster { Name = "sp1", Hp = 101, Xp = 0 };
            List<Monster> monsterList = new List<Monster> { m1, sm1 };
            //


            Menu();
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
                    GoAdventuring();  // TODO: Till spelaren dör eller når level 10.
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
            string[] smileyArray = new string[10] { ":'( ", ":'( ", ":'( ", ":'( ", ":'( ", ":'( ", ":'( ", ":'( ", ":'( ", ":'( ", };
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

        private static void GoAdventuring() // WIP
        {
            Random rnd = new Random();
            int outcome = rnd.Next(1, 3); // ÄNDRA TILL 11 SEDAN! (10% chans monstret anfaller och spelet börjar)
            if (outcome == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Jäklar!"); Thread.Sleep(750);
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine(" - Du mötte monstret!"); // TODO: Vilket av dem?
                Console.WriteLine();
                Thread.Sleep(300);
                BattleBegins(); // ============================= BATTLE BEGINS ==================================== >

            }
            else if (outcome != 1) // 90 % chans
            {
                Console.WriteLine("Inget hände, lugnt och skönt i skogen.");
                Thread.Sleep(750);
                Console.WriteLine("Nu går vi vidare in i skogen!");
                Thread.Sleep(750);
                GoAdventuring(); // Fortsätter tills outcome blir 1.
            }
        }

        private static void BattleBegins()  // WIP:  ========================================================
        {
            Player p = new Player();

            // =========================================== WIP: =============================================
            SpecificMonster m = new SpecificMonster();
            SpecificMonster n = new SpecificMonster();
            SpecificMonster o = new SpecificMonster();
            List<SpecificMonster> monsters = new List<SpecificMonster> { m, n, o };
            Random monsterGenerator = new Random();
            int monster = monsterGenerator.Next(1, 4);
            switch (monster)
            {
                case 1:
                    // m kommer mot spelaren.
                    break;
                case 2:
                    // n kommer mot spelaren.
                    break;
                case 3:
                    // o kommer mot spelaren.
                    break;
                default:
                    Console.WriteLine("Något gick fel?");
                    break;
            } // ===========================================================================================


            Random rnd = new Random();
            int chance = rnd.Next(1, 3); // Varannan gång = 50%


            if (chance == 1) // Hit player.
            {
                while (p.Hp > 0 && m.Hp > 0)
                {
                    Console.WriteLine("Attans - Monstret slog dig!");
                    p.Hp -= 1;
                    Console.WriteLine("Du förlorade en Hp och har nu " + p.Hp + " Hp.");
                    Console.WriteLine();

                    if (p.Hp == 0)
                    {
                        //Game g = new Game();
                        //g.GameOver();

                        GameOver(); // statisk metod.
                    }
                }
            }

            //HitPlayer();

            else if (chance == 2) // Hit monster.
            {
                while (p.Hp > 0 && m.Hp > 0)
                {
                    Console.WriteLine("Du slog monstret - bra!");
                    p.Hp += 1;
                    m.Hp -= 1;
                    Console.WriteLine("Din Hp är nu " + p.Hp + " Hp. Kämpa på!");
                    Console.WriteLine("Monstrets Hp är nu: " + m.Hp + " Hp. Slå han mer!");
                    Console.WriteLine();

                    if (m.Hp == 0)
                    {
                        p.Xp += 1; // Spaleren får en xp när monster dör.
                        Console.WriteLine("Du får 1 Xp eftersom du dödade monstret.");
                        p.Level += 1;
                        Console.WriteLine("Du nådde level: " + p.Level);

                        // TDOD: LEVEL++ TILLS == 10, ==========================================================
                        // TODO: player hp, xp och LEVEL ska finnas kvar i omgång två ==========================
                        GoAdventuring();
                        if (p.Level == 10 || p.Hp == 0)
                        {
                            break; // Spelet slutar om spelaren dör eller når level 10.
                        }
                        // =====================================================================================

                        //LevelUp(); ??
                    }
                    //HitMonster();
                }
            }
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
        public static void GameOver()
        {
            Console.WriteLine("Du dog. Spelet är slut.");
        }

    }
}

