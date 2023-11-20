using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TP2.Weapon;

namespace TP2
{
    public class BWings : Spaceship
    {
        public BWings() : base(30, 0)
        {
            this.AddWeapon(new Weapon("Hammer", 1, 8, EWeaponType.Explosive, 2));
        }

        public override void ShootTarget(Spaceship target)
        {
            foreach (var weapon in Weapons)
            {
                if (weapon.Type == Weapon.EWeaponType.Explosive)
                {
                    weapon.ResetReloadTime();
                }

                int damage = weapon.Shoot();
                target.TakeDamages(damage);
            }
        }
    }
}
