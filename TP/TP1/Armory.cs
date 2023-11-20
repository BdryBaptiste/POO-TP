using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Armory
    {
        private List<Weapon> weapons;

        public Armory()
        {
            weapons = new List<Weapon>();
            Init();
        }

        private void Init()
        {
            weapons.Add(new Weapon("Gauss", 10, 30, Weapon.EWeaponType.Direct));
            weapons.Add(new Weapon("Heavy Cannon", 30, 50, Weapon.EWeaponType.Explosive));
            weapons.Add(new Weapon("Anti-Matter Missile", 50, 80, Weapon.EWeaponType.Guided));
        }

        public void ViewArmory()
        {
            int i = 1;
            Console.WriteLine("----- Armory -----");
            foreach (var weapon in weapons)
            {
                Console.WriteLine(i + $"- Name: {weapon.Name}, Type: {weapon.WeaponType}, Damages: {weapon.MinDamage}-{weapon.MaxDamage}");
                i++;
            }
            Console.WriteLine("---------------------");
        }

        public void AddWeapon(string name, int minDamage, int maxDamage, Weapon.EWeaponType weaponType)
        {
            weapons.Add(new Weapon(name, minDamage, maxDamage, weaponType));
        }

        public Weapon GetWeapon(string weaponName)
        {
            foreach (var weapon in weapons)
            {
                if (weapon.Name.Equals(weaponName))
                {
                    return weapon;
                }
            }
            return null;
        }

        public bool RemoveWeapon(string weaponName)
        {
            Weapon weaponToRemove = GetWeapon(weaponName);
            if (weaponToRemove != null)
            {
                weapons.Remove(weaponToRemove);
                return true;
            }
            return false;
        }

        public void ClearArmory()
        {
            weapons.Clear();
        }

    }
}
