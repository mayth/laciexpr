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
                Node root;
                try
                {
                    tokens = Tokenizer.Tokenize(new System.IO.StringReader(line)).ToList();
                    Console.WriteLine("--> " + string.Join(" ", tokens));
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("!!> TOKENIZE FAILED: " + e.Message);
                    continue;
                }
                try
                {
                    root = Parser.Parse(tokens);
                    Console.WriteLine("--> " + root.ToString());
                    Console.WriteLine("==> " + root.Evaluate());
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("!!> PARSE FAILED:" + e.Message);
                }
            }
        }
    }
}
