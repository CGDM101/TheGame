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

        public void HitMonster(SpecificMonster m, Player p)
        {
            // if m.hp mer än 1.
            m.Hp -= 1;
            p.hp += 1;
            p.Level += 1;
            // else m dör
        }
    }
}
