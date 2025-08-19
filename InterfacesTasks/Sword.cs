using InterfacesTasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTasks
{
    public class Sword : IWeapon, IUpgradeable
    {
        public int AttackDamage { get; set; } = 10;

        public int Attack()
        {
            return AttackDamage;
        }

        public void Upgrade()
        {
            AttackDamage = 25;
        }
    }
}
