using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    class Player : IPlayer
    {
        private string _firstName;
        private string _lastName;
        public string Alias { get; set; }
        public string Name { get { return $"{_firstName} {_lastName}"; } }
        public Spaceship BattleShip { get; set; }

        public Player(string firstName, string lastName, string alias)
        {
            _firstName = FormatName(firstName);
            _lastName = FormatName(lastName);
            Alias = alias;
        }

        public Player(string firstName, string lastName, string alias, Spaceship spaceship)
        {
            _firstName = FormatName(firstName);
            _lastName = FormatName(lastName);
            Alias = alias;
            BattleShip = spaceship;
        }

        private string FormatName(string name)
        {
            return name = char.ToUpper(name[0]) + name.Substring(1).ToLower();
        }



        public override string ToString()
        {
            return $"{Alias} ({_firstName} {_lastName})";
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Player))
            {
                return false;
            }

            Player otherPlayer = (Player)obj;

            if (otherPlayer.Alias == Alias)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}