using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TP2.Weapon;

namespace TP2
{
    public class Rocinante : Spaceship
    {
        public Rocinante() : base(3, 5)
        {
            this.AddWeapon(new Weapon("Torpille", 3, 3, EWeaponType.Guided, 2));
        }

        public override void TakeDamages(double damage)
        {
            if (AttemptEvasion())
            {
                Console.WriteLine("Rocinante evaded the attack!");
                return;
            }

            base.TakeDamages(damage);
        }

        private bool AttemptEvasion()
        {
            Random random = new Random();
            return random.Next(1, 7) <= 2;
        }
    }
}
