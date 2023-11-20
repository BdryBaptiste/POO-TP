
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class Weapon : IWeapon
    {
        public string Name { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public EWeaponType Type { get; set; }
        public int ReloadTime { get; set; }
        public int TimeBeforReload { get; set; }

        public enum EWeaponType
        {
            Direct,
            Explosive,
            Guided
        }

        public Weapon(string _name, int _minDamage, int _maxDamage, EWeaponType _weaponType,  int _reloadTime)
        {
            Name = _name;
            MinDamage = _minDamage;
            MaxDamage = _maxDamage;
            Type = _weaponType;
            ReloadTime = _reloadTime;
            TimeBeforReload = 0;
        }
        public int Shoot()
        {
            if (TimeBeforReload == 0)
            {
                TimeBeforReload = ReloadTime;

                Random random = new Random();
                int chance = random.Next(1, 101);

                int damage = random.Next(MinDamage, MaxDamage + 1);

                switch (Type)
                {
                    case EWeaponType.Direct:
                        if (chance <= 10) return 0;
                        break;
                    case EWeaponType.Explosive:
                        if (chance <= 25) return 0;
                        damage *= 2;
                        TimeBeforReload = ReloadTime * 2;
                        break;
                    case EWeaponType.Guided:
                        damage = MinDamage;
                        break;
                }

                return damage;
            }
            return 0;

        }

        public void ResetReloadTime()
        {
            if (this.Type == EWeaponType.Direct)
            {
                this.TimeBeforReload = 0;
            }
        }
    }

}

