using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    internal interface IWeapon
    {
        string Name { get; }
        int MinDamage { get; }
        int MaxDamage { get; }
        Weapon.EWeaponType Type { get; }
        int ReloadTime { get; }
        int TimeBeforReload { get; }
        int Shoot();
    }
}
