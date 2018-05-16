using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineClass2.Common
{
    public static class Meta
    {
        public static string ToMeta(string inputString)
        {
            string[] VietnameseSigns =
            {

                "aAeEoOuUiIdDyY",

                "áàạảãâấầậẩẫăắằặẳẵ",

                "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

                "éèẹẻẽêếềệểễ",

                "ÉÈẸẺẼÊẾỀỆỂỄ",

                "óòọỏõôốồộổỗơớờợởỡ",

                "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

                "úùụủũưứừựửữ",

                "ÚÙỤỦŨƯỨỪỰỬỮ",

                "íìịỉĩ",

                "ÍÌỊỈĨ",

                "đ",

                "Đ",

                "ýỳỵỷỹ",

                "ÝỲỴỶỸ"
            };

            inputString = inputString.ToLower();

            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    inputString = inputString.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }

            inputString = inputString.Replace(" ", "-");
            inputString = inputString.Replace(":", "-");
            inputString = inputString.Replace(".", "-");

            return inputString;
        }
    }
}