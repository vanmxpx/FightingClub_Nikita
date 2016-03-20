using FightingClub_Nikita;
using System;

namespace GameProcess
{
    public class CPUPlayer : Player
    {
        static Random rnd;

        public CPUPlayer(int _hp)
            : base("CPU",_hp)
        {
            rnd = new Random();
        }

        public BodyParts MakeHit()
        {
            return (BodyParts)rnd.Next(0, 4);
        }

        public void MakeBlock()
        {
            SetBlock((BodyParts)rnd.Next(0,4));
        }
    }
}
