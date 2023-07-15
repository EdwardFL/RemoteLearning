using System;

namespace HashtableImplementation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BasicHashTable<string, string> hash = new BasicHashTable<string, string>(5);

            hash.Put("unu", "doi");
            hash.Put("doi", "trei");
            hash.Put("trei", "patru");
            hash.Put("patru", "unu");
            hash.Put("patru", "unu");
            hash.Put("doi", "patru");
            Console.WriteLine(hash["unu"]);
            hash["unu"] = "trei";
            Console.WriteLine(hash["unu"]);

            Console.WriteLine(hash.ContainsKey("string"));
            Console.WriteLine(hash.ContainsKey("unu"));
            Console.WriteLine(hash.ContainsKey("doi"));

            Console.WriteLine(hash.Count());

            Console.WriteLine(hash.Get("patru"));

            Console.WriteLine(hash.GetHash("unu"));

            hash.Remove("trei");
            Console.WriteLine(hash.ContainsKey("trei"));
            Console.WriteLine(hash.Count());

            Console.ReadLine();
        }
    }
}