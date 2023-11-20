using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class F18 : Spaceship, IAbility
    {
        public F18(string _name) : base(15, 0, _name) 
        {
            Name= _name;
        }

        public override void UseAbility(List<Spaceship> spaceships)
        {
            int playerPosition = spaceships.FindIndex(s => s is ViperMKII);
            if (playerPosition >= 0 && (playerPosition == 0 || playerPosition == 2))
            {
                Console.WriteLine("Dodge This. *F18 blows up*");
                spaceships[playerPosition].TakeDamages(10);

                int thisDamage = (int)Math.Ceiling(this.Structure);

                this.TakeDamages(thisDamage);
            }
        }
    }

}
