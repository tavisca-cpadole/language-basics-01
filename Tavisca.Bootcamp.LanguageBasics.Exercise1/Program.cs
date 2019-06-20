using System;
using System.Linq;
namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            string[] arr = equation.Split(new Char[] { '=', '*'});
            if (arr[0].Contains('?')){
                return CheckDigit(arr[0], arr[1],arr[2],arr[0].IndexOf('?'));
            }
            else if (arr[1].Contains('?'))
            {
                return CheckDigit(arr[1], arr[0], arr[2], arr[1].IndexOf('?'));
            }
            else {
                return CheckDigit(arr[0], arr[1], arr[2], arr[2].IndexOf('?'), 1);
            }
        }

        public static int CheckDigit(string a,string b,string c,int pos,int op=-1) {
            if (op == 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (pos == 0 && i==0)
                        continue;
                    char[] ch = c.ToCharArray();
                    ch[pos] = Convert.ToChar(i.ToString());
                    string newstring = new string(ch);
                    int x = Convert.ToInt32(newstring);
                    if (Int32.Parse(b) * Int32.Parse(a) == x)
                    {
                        return i;
                    }
                }
                return -1;
            }
            else {
                for (int i = 0; i < 10; i++)
                {
                    if (pos == 0 && i == 0)
                        continue;
                    char[] ch = a.ToCharArray();
                    ch[pos] = Convert.ToChar(i.ToString());
                    string newstring = new string(ch);
                    int x = Convert.ToInt32(newstring);
                    if (Int32.Parse(b) * x== Int32.Parse(c))
                    {
                        return i;
                    }
                }
                return -1;
            }
        }
    }
}
