using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Spaceship
    {
        public int MaxStructure { get; private set; }
        public int MaxShield { get; private set; }
        public int CurrentStructure { get; private set; }
        public int CurrentShield { get; private set; }
        public bool IsDestroyed { get { return CurrentStructure <= 0; }}

        private List<Weapon> weapons;

        public Spaceship(int maxStructure, int maxShield)
        {
            MaxStructure = maxStructure;
            MaxShield = maxShield;
            CurrentStructure = MaxStructure;
            CurrentShield = MaxShield;
            weapons = new List<Weapon>();
        }

        public void AddWeapon(Weapon weapon)
        {
            if (weapons.Count < 3)
            {
                weapons.Add(weapon);
            }
            else
            {
                Console.WriteLine("This ship cannot carry more than 3 weapons.");
            }
        }

        public void ViewShip()
        {
            Console.WriteLine($"Max structure points : {MaxStructure}");
            Console.WriteLine($"Max shield points: {MaxShield}");
            Console.WriteLine($"Current structure points : {CurrentStructure}");
            Console.WriteLine($"Current shield points : {CurrentShield}");
            ViewWeapons();
        }

        public void RemoveWeapon(Weapon weapon)
        {
            weapons.Remove(weapon);
        }

        public void ClearWeapons()
        {
            weapons.Clear();
        }

        public void ViewWeapons()
        {
            Console.WriteLine("Equipped weapons :");
            foreach (var weapon in weapons)
            {
                Console.WriteLine($"Name: {weapon.Name}, Type: {weapon.WeaponType}, Damage: {weapon.MinDamage}-{weapon.MaxDamage}");
            }
        }

        public double AverageDamages()
        {
            if (weapons.Count == 0)
            {
                return 0;
            }

            int totalDamage = 0;
            foreach (var weapon in weapons)
            {
                totalDamage += (weapon.MinDamage + weapon.MaxDamage) / 2;
            }

            return (double)totalDamage / weapons.Count;
        }
    }
}
