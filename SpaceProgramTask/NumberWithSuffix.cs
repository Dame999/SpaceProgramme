using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceProgramTask
{
    public class NumberWithSuffix
    {
        public NumberWithSuffix() { }
        public string SuffixNumber(int number) 
        {
            string suffix;
            if (number % 100 >= 11 && number % 100 <= 13) 
            {
                suffix = "th";
            }
            else
            {
                switch (number % 10)
                {
                    case 1:
                        suffix = "st";
                        break;
                    case 2:
                        suffix = "nd";
                        break;
                    case 3:
                        suffix = "rd";
                        break;
                    default:
                        suffix = "th";
                        break;
                }
            }
            
            return number.ToString() + suffix;
        }
    }
}
