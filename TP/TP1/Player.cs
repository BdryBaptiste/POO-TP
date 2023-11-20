using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Player
    {
        private string _firstName;
        private string _lastName;
        public string Alias { get; set; }
        public string Name { get { return $"{_firstName} {_lastName}"; } }
        public Spaceship Spaceship { get; }

        public Player(string firstName, string lastName, string alias)
        {
            _firstName = FormatName(firstName);
            _lastName = FormatName(lastName);
            Alias = alias;
            Spaceship = new Spaceship(1000,1000);
        }

        public Player(string firstName, string lastName, string alias, Spaceship spaceship)
        {
            _firstName = FormatName(firstName);
            _lastName = FormatName(lastName);
            Alias = alias;
            Spaceship = spaceship;
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

            if (otherPlayer.Alias == this.Alias)
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