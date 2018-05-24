using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineClass2.Common
{
    public static class Code
    {
        public static string MakeCode()
        {
            string code = "";
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            code = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
            return code;
        }
    }
}