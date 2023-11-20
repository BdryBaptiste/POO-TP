using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TP2.Weapon;

namespace TP2
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
            AddWeapon("Laser", 2, 3, EWeaponType.Direct, 2);
            AddWeapon("Hammer", 1, 8, EWeaponType.Explosive, 2);
            AddWeapon("Torpille", 3, 3, EWeaponType.Guided, 2);
            AddWeapon("Mitrailleuse", 6, 8, EWeaponType.Direct, 1);
            AddWeapon("EMG", 1, 7, EWeaponType.Explosive, 2);
            AddWeapon("Missile", 4, 100, EWeaponType.Guided, 4);
        }

        public void ViewArmory()
        {
            int i = 1;
            Console.WriteLine("----- Armory -----");
            foreach (var weapon in weapons)
            {
                Console.WriteLine(i + $"- Name: {weapon.Name}, Type: {weapon.Type}, Damages: {weapon.MinDamage}-{weapon.MaxDamage}");
                i++;
            }
            Console.WriteLine("---------------------");
        }

        public void AddWeapon(string name, int minDamage, int maxDamage, Weapon.EWeaponType weaponType, int reloadTime)
        {
            weapons.Add(new Weapon(name, minDamage, maxDamage, weaponType, reloadTime));
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
