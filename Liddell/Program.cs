using System;
using System.Collections.Generic;
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
                IEnumerable<Token> tokens;
                try
                {
                    tokens = Tokenizer.Tokenize(new System.IO.StringReader(line)).ToList();
                    Console.WriteLine("--> " + string.Join(" ", tokens));
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("!!> " + e.Message);
                    continue;
                }
                var node = Parser.Parse(tokens);
                Console.WriteLine("--> " + node.Evaluate());
            }
        }
    }
}
