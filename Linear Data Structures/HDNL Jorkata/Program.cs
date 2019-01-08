using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace HDNLToy
{
    public class HDNLToy
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var tags = new List<string>(n);
            for (int i = 0; i < n; i++) { tags.Add(Console.ReadLine()); }
            var stackOpen = new Stack<string>();
            var res = new List<string>();
            stackOpen.Push(TransformToOpening(tags.First()));
            res.Add(TransformToOpening(tags.First()));
            for (int i = 1; i < tags.Count; i++)
            {
                var currnetLvl = GetNestedLevel(tags[i]);
                var prevLvl = GetNestedLevel(tags[i - 1]);
                if (currnetLvl > prevLvl)
                {
                    stackOpen.Push(TransformToOpening(tags[i]));
                    res.Add(stackOpen.Peek());
                }
                else
                {
                    while (currnetLvl <= GetNestedLevel(stackOpen.Peek()))
                    {
                        res.Add(TransformFromOpeningToClosing(stackOpen.Pop()));
                        if (stackOpen.Count() == 0) { break; }
                    }
                    stackOpen.Push(TransformToOpening(tags[i]));
                    res.Add(stackOpen.Peek());
                }
            }
            int stackCount = stackOpen.Count();
            for (int i = 0; i < stackCount; i++)
            {
                res.Add(TransformFromOpeningToClosing(stackOpen.Pop()));
            }
            for (int i = 0; i < res.Count; i++)
            {
                Console.WriteLine(res[i]);
            }
        }
        public static short GetNestedLevel(string tag)
        {
            return short.Parse(Regex.Match(tag, @"\d+").Value);
        }
        public static string TransformFromOpeningToClosing(string tag)
        {
            return tag.Insert(1, "/");
        }
        public static string TransformToOpening(string tag)
        {
            return $"<{tag}>";
        }
    }
}