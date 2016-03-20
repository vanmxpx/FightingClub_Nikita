using System;

namespace FightingClub_Nikita
{
    public class MyEventArgs : EventArgs
    {
        public int HP { get; set; }
        public string Name{ get; set; }
}
    public class Player
    {
        MyEventArgs args;
        public event EventHandler<MyEventArgs> Block;
        public event EventHandler<MyEventArgs> Wound;
        public event EventHandler<MyEventArgs> Death;

        public string Name { get; private set; }
        BodyParts _blocked;
        private int _hp;
        public int HealthPoints
        {
            get { return _hp; }
            private set
            {
                _hp = value;
                if (_hp < 0)
                {
                    _hp = 0;
                    if (Death != null) Death(this, args);
                }
            }
        }

        public Player(String _name, int _hp)
        {
            args = new MyEventArgs();
            args.Name = _name;
            args.HP = HealthPoints;
            Name = _name;
            HealthPoints = _hp;
        }

        public void GetHit(BodyParts _hited, int _dmg)
        {
            if (_hited == _blocked)
            {
                if (Block != null) Block(this, args);
            }
            else
            {
                HealthPoints -= _dmg;
                args.HP = HealthPoints;
                if (Wound != null) Wound(this, args);
            }
        }

        public void SetBlock(BodyParts _blocked)
        {
            this._blocked = _blocked;
        }
    }
}
