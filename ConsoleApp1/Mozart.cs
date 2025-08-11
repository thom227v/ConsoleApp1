using System;
using System.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Mozart
    {
        public static void PlaySpecificFile()
        {

            string directory = Context.GetDataDirectory();

            for (int i = 0; i < 15; i++)
            {
                Die die = new Die(2);
                string fileName = Path.Combine(directory, $"minuet{i}-{die.CombinedRoll}.wav");
                using SoundPlayer player = new SoundPlayer(fileName);
                player.PlaySync();
            }

            for (int i = 0; i < 15; i++)
            {
                Die dice = new Die();
                string fileName = Path.Combine(directory, $"trio{i}-{dice.CombinedRoll}.wav");
                using SoundPlayer player = new SoundPlayer(fileName);
                player.PlaySync();
            }
        }
    }
}