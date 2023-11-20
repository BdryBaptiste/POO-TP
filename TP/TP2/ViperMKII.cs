using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TP2.Weapon;

namespace TP2
{
    public class ViperMKII : Spaceship
    {
        public ViperMKII(string _name) : base(10, 15, _name)
        {
            Name = _name;
            this.AddWeapon(new Weapon("EMG", 1, 10, EWeaponType.Explosive, 2));
            this.AddWeapon(new Weapon("Mitrailleuse", 6, 15, EWeaponType.Direct, 1));
            this.AddWeapon(new Weapon("Missile", 25, 100, EWeaponType.Guided, 4));
        }

        public override void ShootTarget(Spaceship target)
        {
            foreach (var weapon in Weapons)
            {
                if (weapon.TimeBeforReload > 0)
                {
                    weapon.TimeBeforReload--;
                }
            }

            var rechargedWeapons = Weapons.Where(w => w.TimeBeforReload == 0).ToList();
            if (rechargedWeapons.Any())
            {
                var weaponToShoot = rechargedWeapons[new Random().Next(rechargedWeapons.Count)];
                Console.WriteLine($"{this.Name} shoots {weaponToShoot.Name} at {target.Name}.");
                int damage = weaponToShoot.Shoot();
                Console.WriteLine($"{weaponToShoot.Name} deals {damage} damages.");
                target.TakeDamages(damage);
            }
        }
    }
}
