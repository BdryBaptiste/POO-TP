using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public abstract class Spaceship : ISpaceship
    {
        public string Name { get; set; }
        public double Structure { get; set; }
        public double Shield { get; set; }
        public double CurrentStructure { get; set; }
        public double CurrentShield { get; set; }
        public bool IsDestroyed { get; }
        public int MaxWeapons { get; }
        public double AverageDamages { get { return AverageDamage(); } }
        public bool BelongsPlayer { get; }

        public List<Weapon> Weapons { get; }

        public Spaceship(int _maxStructure, int _maxShield)
        {
            Structure = _maxStructure;
            Shield = _maxShield;
            CurrentStructure = Structure;
            CurrentShield = Shield;
            Weapons = new List<Weapon>();
        }

        public void AddWeapon(Weapon weapon)
        {
            if (Weapons.Count < 3)
            {
                Weapons.Add(weapon);
            }
            else
            {
                Console.WriteLine("This ship cannot carry more than 3 weapons.");
            }
        }

        public void ViewShip()
        {
            Console.WriteLine($"Max structure points : {Structure}");
            Console.WriteLine($"Max shield points: {Shield}");
            Console.WriteLine($"Current structure points : {CurrentStructure}");
            Console.WriteLine($"Current shield points : {CurrentShield}");
            ViewWeapons();
        }

        public void RemoveWeapon(Weapon oWeapon)
        {
            Weapons.Remove(oWeapon);
        }

        public void ClearWeapons()
        {
            Weapons.Clear();
        }

        public void ViewWeapons()
        {
            Console.WriteLine("Equipped weapons :");
            foreach (var weapon in Weapons)
            {
                Console.WriteLine($"Name: {weapon.Name}, Type: {weapon.Type}, Damage: {weapon.MinDamage}-{weapon.MaxDamage}");
            }
        }

        public double AverageDamage()
        {
            if (Weapons.Count == 0)
            {
                return 0;
            }

            int totalDamage = 0;
            foreach (var weapon in Weapons)
            {
                totalDamage += (weapon.MinDamage + weapon.MaxDamage) / 2;
            }

            return (double)totalDamage / Weapons.Count;
        }

        public virtual void TakeDamages(double damages)
        {
            if (CurrentShield > 0)
            {
                double shieldDamage = Math.Min(CurrentShield, damages);
                CurrentShield -= shieldDamage;
                damages -= shieldDamage;
            }

            CurrentStructure -= damages;
        }

        public virtual void ShootTarget(Spaceship target)
        {
            
        }

        public void ReloadWeapons()
        {

        }

        public void RepairShield(double repair)
        {
            if (CurrentShield < Shield)
            {
                CurrentShield += repair;
                if (CurrentShield > Shield)
                {
                    CurrentShield = Shield;
                }
            }
        }
    }
}
