using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesTasks.Interfaces
{
    public interface IPayment
    {
        public void ProcessPayment(decimal amount);
    }
}
