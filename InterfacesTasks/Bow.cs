using InterfacesTasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTasks
{
    public class Bow : IWeapon, IUpgradeable
    {
        public int Damage { get; set; }
        public int Attack()
        {
            Random random = new Random();
            return random.Next(5, 16); 
        }

        public void Upgrade()
        {
            Damage = 15;
        }
    }
}
