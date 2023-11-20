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
        public ViperMKII() : base(10, 15)
        {
            this.AddWeapon(new Weapon("EMG", 1, 7, EWeaponType.Explosive, 2));
            this.AddWeapon(new Weapon("Mitrailleuse", 6, 8, EWeaponType.Direct, 1));
            this.AddWeapon(new Weapon("Missile", 4, 100, EWeaponType.Guided, 4));
        }

        public override void ShootTarget(Spaceship target)
        {
            var rechargedWeapons = Weapons.Where(w => w.ReloadTime == 0).ToList();
            if (rechargedWeapons.Any())
            {
                var weaponToShoot = rechargedWeapons[new Random().Next(rechargedWeapons.Count)];
                int damage = weaponToShoot.Shoot();
                target.TakeDamages(damage);
            }
        }
    }
}
