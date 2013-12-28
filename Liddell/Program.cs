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
                    tokens = Tokenizer.Tokenize(new System.IO.StringReader(line)).ToList(); // do not lazy!
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
                    Console.WriteLine("--> Tree:  " + root.ToString());
                    Console.WriteLine("--> Value: " + root.Evaluate());
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("!!> PARSE FAILED: " + e.Message);
                    continue;
                }

                try
                {
                    var codes = root.Emit(true);
                    var cCode = Generator.Generate(codes, 64);
                    System.IO.File.WriteAllText("output.c", cCode);
                    Console.WriteLine("--> Wrote C code to 'output.c'.");
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("!!> COMPILE FAILED: " + e.Message);
                }
            }
        }
    }
}
