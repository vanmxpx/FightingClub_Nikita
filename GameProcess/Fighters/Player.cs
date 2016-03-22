using System;

namespace GameProcess.Fighters
{
    public class Player
    {
        EventArgsFighter args;
        public event EventHandler<EventArgsFighter> Block;
        public event EventHandler<EventArgsFighter> Wound;
        public event EventHandler<EventArgsFighter> Death;

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
            args = new EventArgsFighter();
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
                if (Wound != null && 0 != HealthPoints) Wound(this, args);
            }
        }

        public void SetBlock(BodyParts _blocked)
        {
            this._blocked = _blocked;
        }
    }
}
