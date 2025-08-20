using DependencyInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class GameRunner
    {
        private readonly IGameEngine gameEngine;

        public GameRunner(IGameEngine gameEngine)
        {
            this.gameEngine = gameEngine;
            gameEngine.Play();
        }
    }
}
