using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class Dart : Spaceship
    {
        public Dart(string _name) : base(10, 3, _name)
        {
            Name = _name;
            this.AddWeapon(new Weapon("Laser", 2, 3, Weapon.EWeaponType.Direct, 0));
        }

        public override void ShootTarget(Spaceship target)
        {
            foreach (var weapon in Weapons)
            {
                if (weapon.Type == Weapon.EWeaponType.Direct)
                {
                    weapon.ResetReloadTime();
                }

                int damage = weapon.Shoot();
                target.TakeDamages(damage);
            }
        }
    }
}
