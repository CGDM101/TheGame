namespace TheGame
{
    public class Monster
    {
        public string Name { get; set; }

        public void HitPlayer(Player p, SpecificMonster m)
        {
            // if p.hp minst 1.
            p.Hp -= 1;
            m.Hp += 1;
            p.Level += 0;
            // else p dör.
        }
    }
}
