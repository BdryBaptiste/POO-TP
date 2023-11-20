using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Weapon
    {
        public string Name { get; private set; }
        public int MinDamage { get; private set; }
        public int MaxDamage { get; private set; }
        public EWeaponType WeaponType { get; private set; }

        public enum EWeaponType
        {
            Direct,
            Explosive,
            Guided
        }

        public Weapon(string name, int minDamage, int maxDamage, EWeaponType weaponType)
        {
            Name = name;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            WeaponType = weaponType;
        }
    }
}
