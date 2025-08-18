using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Models
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public abstract int Attack();
    }
}
