namespace TheGame
{
    public class Player
    {
        private int xp;
        private int hp = 10;

        public string Name { get; set; }
        public int Level { get; set; }
        public int Xp { get => xp; set => xp = 0; }
        public int Hp { get => hp; set => hp = 10; }
    }
}
