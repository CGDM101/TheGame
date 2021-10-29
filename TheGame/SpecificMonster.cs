namespace TheGame
{
    public class SpecificMonster : Monster
    {
        private int xp = 0;
        private int hp = 10;

        public int Xp { get => xp; set => xp = value; }
        public int Hp { get => hp; set => hp = value; }
    }
}
