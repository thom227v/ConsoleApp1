using InterfacesTasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTasks
{
    public class Staff : IWeapon, IUpgradeable
    {
        private int magicPower;

        public int MagicPower
        {
            get { return magicPower; }
            set { magicPower = 20; }
        }


        public int Attack()
        {
            return MagicPower; 
        }

        public void Upgrade()
        {
            MagicPower = 35;
        }
    }
}
