using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame_Assignment
{
    // Class responsible for drawing a random element from 
    // string list.
    static class RandomString
    {
        // Draw method.
        public static string Draw(List<string> texts)
        {
            Random random = new Random();
            int randomIndex = random.Next(texts.Count);
            return texts[randomIndex];
        }
    }
}
