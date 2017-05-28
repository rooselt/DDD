using System;

namespace Helpers
{
    public static class Utils
    {
        public static string GereneteRandomCode()
        {
            var random = new Random();

            return random.Next(10000, 99999).ToString();
        }
    }
}
