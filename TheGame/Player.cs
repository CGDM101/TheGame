namespace TheGame
{
    public class Player
    {
        private int xp = 0;
        private int hp = 10;

        public string Name { get; set; }
        public int Level { get; set; }
        public int Xp { get => xp; set => xp = value; }
        public int Hp { get => hp; set => hp = value; }
    }
}
