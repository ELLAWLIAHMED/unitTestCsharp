using System;
using System.Collections.Generic;
using System.Text;

namespace Accounts_Core
{
    public class Utils
    {
        public static long GenerateRandomRib(int length)
        {
            byte[] bytes = new byte[length];
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                bytes[i] = (byte) random.Next(0, 10);
            }

            return BitConverter.ToInt32(bytes, 0);

        }
    }
}
