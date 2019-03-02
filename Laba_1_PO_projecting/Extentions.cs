using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_1_PO_projecting
{
    static class Extentions
    {
        private static Random rand = new Random();

        private static ConsoleKey ChoseNotThose(ConsoleKey key1, ConsoleKey key2)
        {
            ConsoleKey result = (ConsoleKey)rand.Next(0, 255);
            while (result == key1 && result == key2)
                result = (ConsoleKey)rand.Next(0, 255);
            return result;
        }

        private static bool Equal(ConsoleKey key1, ConsoleKey key2, ConsoleKey _key1, ConsoleKey _key2)
        {
            if (key1 == _key1 && key2 == _key2 || key1 == _key2 && key2 == _key1) return true;
            return false;
        }

        //public static string _ReadUntil(ConsoleKey key1, ConsoleKey key2)
        //{
        //    ConsoleKey temp1 = ChoseNotThose(key1, key2);
        //    ConsoleKey temp2 = temp1;
        //    StringBuilder sb = new StringBuilder();
        //    while (!Equal(temp1, temp2, key1, key2))
        //    {
        //        var key = Console.ReadKey();
        //        key.Modifiers.HasFlag(ConsoleModifiers.Control);
        //        sb.Append();
        //    }
        //    return sb.ToString();
        //}

        private static List<ConsoleKeyInfo> ReadStr()
        {
            var key = Console.ReadKey();
            List<ConsoleKeyInfo> list = new List<ConsoleKeyInfo>();
            while (key.Key != ConsoleKey.Enter)
            {
                list.Add(key);
                key = Console.ReadKey();
            }
            return list;
        }

        private static bool HasCTRL(List<ConsoleKeyInfo> info)
        {
            foreach (var e in info) if (e.Modifiers.HasFlag(ConsoleModifiers.Control)) return true;
            return false;
        }

        //public static string ReadUntilCTRL()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    var key = Console.ReadKey();
        //    while (!key.Modifiers.HasFlag(ConsoleModifiers.Control) && key.Key == ConsoleKey.Enter)
        //    {
        //        sb.Append(key.KeyChar);
        //        key = Console.ReadKey();
        //    }
        //    return sb.ToString(); 
        //}

        public static string ReadUntilCTRL()
        {
            StringBuilder sb = new StringBuilder();
            var key = Console.ReadKey();
            while (!key.Modifiers.HasFlag(ConsoleModifiers.Control) && key.Key == ConsoleKey.Enter)
            {
                sb.Append(key.KeyChar);
                key = Console.ReadKey();
            }
            return sb.ToString();
        }
    }
}
