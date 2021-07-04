using System;
using System.Linq;

namespace API.Helpers.Utilities
{
    public class StringUtilities
    {
        public string GetRandomString(int length)
        {
            Random random = new Random();
            const string chars = "abcdefgh1jklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
