using System;

namespace NumbersToString.Resources
{
    public class NumbersToString
    {
        readonly string[] first =
        {
            "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine",
            "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
            "Seventeen", "Eighteen", "Nineteen"
        };

        readonly string[] tens =
        {
            "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety",
        };

        public string Convert(double n)
        {
            var subString = string.Empty;
            var convertedValue = string.Empty;

            var decimalValue = ((decimal)n % 1);
            var num = (int)Math.Truncate(n);
            try
            {
                if (decimalValue > 0)
                {
                    var toString = decimalValue.ToString();
                    if (toString.Length == 3) //0.2
                    {
                        subString = toString.Substring(toString.IndexOf("."), 2);
                    }
                    else if (toString.Length == 4) //0.02
                    {
                        subString = toString.Substring(toString.IndexOf("."), 3);
                    }
                    else
                    {
                        return "To many numbers after decimal.";
                    }
                    convertedValue = $"{ToSentence(num)} and {subString.Replace(".", "")}/100."; ;
                }
                else
                {
                    convertedValue = $"{ToSentence(num)}";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return convertedValue;
        }
        private string ToSentence(int n)
        {
            return n == 0 ? first[n] : Step(n);
        }
        // traverse the number recursively
        private string Step(int n)
        {
            return n < 0 ? "Minus " + Step(-n) :
                   n == 0 ? "" :
                   n <= 19 ? first[n] :
                   n <= 99 ? tens[n / 10 - 2] + " " + Step(n % 10) :
                   n <= 199 ? "One Hundred " + Step(n % 100) :
                   n <= 999 ? Step(n / 100) + " Hundred " + Step(n % 100) :
                   n <= 1999 ? "One Thousand " + Step(n % 1000) :
                   n <= 999999 ? Step(n / 1000) + " Thousand " + Step(n % 1000) :
                   n <= 1999999 ? "One Million " + Step(n % 1000000) :
                   n <= 999999999 ? Step(n / 1000000) + " Million " + Step(n % 1000000) :
                   n <= 1999999999 ? "One Billion " + Step(n % 1000000000) :
                                      Step(n / 1000000000) + " Billion " + Step(n % 1000000000);
        }
    }
}
