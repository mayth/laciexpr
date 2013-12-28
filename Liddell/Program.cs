using System;
using System.Linq;
using Laciexpr;

namespace liddell
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                try
                {
                    var tokens = Tokenizer.Tokenize(new System.IO.StringReader(line));
                    Console.WriteLine("--> " + string.Join(" ", tokens));
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("!!> " + e.Message);
                }
            }
        }
    }
}
