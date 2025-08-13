using System;
using System.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    public class Mozart
    {
        public static string GetCorrectInstrument()
        {
            // Use Yatzy data directory instead of ReadDataFolder
            string directory = Path.Combine(Directory.GetCurrentDirectory(), "Yatzy", "Data");
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
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
                    return GetCorrectInstrument();
            }
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