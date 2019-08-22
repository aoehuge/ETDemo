using System;
namespace ETModel
{
    public static class RandomTool
    {
        private static Random random = new Random();

        public static int Random(int min, int max)
        {
            return random.Next(min, max);
        }

        public static double Random(double min, double max)
        {
            return random.NextDouble() * (max - min) + min;
        }
    }
}
