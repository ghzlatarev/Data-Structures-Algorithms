using System;
using System.Collections.Generic;
using System.Linq;

namespace Jedi_Meditation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            string[] jedis = Console.ReadLine().Split(' ');
            List<string> mList = new List<string>();
            List<string> kList = new List<string>();
            List<string> pList = new List<string>();

            foreach(string jedi in jedis)
            {
                if(jedi[0] == 'M') mList.Add(jedi);
                else if(jedi[0] == 'K') kList.Add(jedi);
                else pList.Add(jedi);
            }
            Console.WriteLine("{0} {1} {2}", string.Join(" ", mList), string.Join(" ", kList), string.Join(" ", pList));
        }
    }
}
