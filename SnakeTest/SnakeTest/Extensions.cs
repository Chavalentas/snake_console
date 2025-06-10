using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public static class Extensions
    {
        public static ConsoleColor GetRandomColor(Random randomGenerator)
        {
            Array colorValues = Enum.GetValues(typeof(ConsoleColor));
            int colorCode = randomGenerator.Next(0, colorValues.Length);
            string colorName = Enum.GetName(typeof(ConsoleColor), colorCode);
            ConsoleColor randomColor;
            Enum.TryParse(colorName, out randomColor);

            return randomColor;
        }

        public static ConsoleColor GetRandomColor(Random randomGenerator, ConsoleColor except)
        {
            ConsoleColor randomColor;

            do
            {
                randomColor = GetRandomColor(randomGenerator);
            }
            while (randomColor == except);

            return randomColor;
        }

        public static ConsoleColor GetRandomColor(Random randomGenerator, IEnumerable<ConsoleColor> except)
        {
            ConsoleColor randomColor;

            do
            {
                randomColor = GetRandomColor(randomGenerator);
            }
            while (except.Contains(randomColor));

            return randomColor;
        }
    }
}
