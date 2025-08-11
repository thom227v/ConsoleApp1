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
        public static string GetCorrectInstrument()
        {
            string directory = Context.GetDataDirectory();
            Console.Write("Hello dear user, please choose wisely which instrument you wise to play, 1 for clarient, 2 for flute-harp, 3 mbira or 4 for piano: ");
            switch (Console.ReadLine())
            {
                case "1":
                    return Path.Combine(directory, "clarinet");
                case "2":
                    return Path.Combine(directory, "flute-harp");
                case "3":
                    return Path.Combine(directory, "mbira");
                case "4":
                    return Path.Combine(directory, "piano");
                default:
                    GetCorrectInstrument();
                    break;
            }

            return Path.Combine(directory, "piano"); //unreachable code, but needed to satisfy the compiler
        }


        public static void PlaySpecificFile()
        {
            string directory = GetCorrectInstrument();

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