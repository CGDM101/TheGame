namespace TheGame
{
    public class Player
    {
        private int xp = 0;
        private int hp = 10;
        private int level = 1;

        public string Name { get; set; }
        public int Level { get => level; set => level = value; }
        public int Xp { get => xp; set => xp = value; }
        public int Hp { get => hp; set => hp = value; }
    }
}
